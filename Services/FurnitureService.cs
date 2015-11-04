using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Ikinea.Rest;

namespace IKinea.Services
{
    public class FurnitureService
    {
        private IEnumerable<productsProduct> _furnitures;
        public void LoadData()
        {
            string furnituresFile = ConfigurationManager.AppSettings["Furnitures"];
            XmlSerializer serializer = new XmlSerializer(typeof(ikearest));

            StreamReader reader = new StreamReader(furnituresFile);
            ikearest ikeaRest = (ikearest)serializer.Deserialize(reader);
            _furnitures = ikeaRest.products.Distinct().OrderByDescending(p => p.items.item.Volume);
            reader.Close();
            //SaveAllImages();
        }

        public IEnumerable<productsProduct> AllFurnitures
        {
            get
            {
                return _furnitures;
            }
        }

        //private static string BuildDimensionsPattern(int w, int d, int h)
        //{
        //    string dimensions = "";
        //    dimensions += w.ToString();
        //    if (d != 0) dimensions += "x" + d.ToString();
        //    if (h != 0) dimensions += "x" + h.ToString();
        //    dimensions += " cm";
        //    return dimensions;
        //}

        //private static bool IsDimensionsMatched(string dimensions, productsProduct product)
        //{
        //    string paDim = product.items.item.Dimensions;
        //    if (string.IsNullOrEmpty(paDim))
        //        return false;
        //    else
        //        return paDim == dimensions;
        //}

        public IEnumerable<productsProduct> SelectByDimensions(int w, int d, int h, int doors, int shelves)
        {
            //string dimensions = BuildDimensionsPattern(w, d, h);
            return AllFurnitures.Where(p =>
            {
                return p.items.item.DimensionsTuple.Item1 <= w && p.items.item.DimensionsTuple.Item3 <= h
                    && (doors == 0 || p.items.item.portes == doors)
                    && (shelves == 0 || p.items.item.etageres == shelves)
                    ;
                //&& p.items.item.DimensionsTuple.Item2 <= d;
            }).OrderByDescending(p => p.items.item.Volume); ;
        }

        public void SaveAllImages()
        {
            if (!Directory.Exists("Ikea\\jpg"))
                Directory.CreateDirectory("Ikea\\jpg");
            using (WebClient webClient = new WebClient())
            {
                foreach (productsProduct product in _furnitures)
                {
                    string local = product.items.item.ImageZoom.Replace("png", "jpg");
                    try
                    {
                        webClient.DownloadFile(product.items.item.images.zoom[0].Value, local);
                    }
                    catch (WebException ex1)
                    {
                        try
                        {
                            webClient.DownloadFile(product.items.item.images.large[0].Value, local);
                        }
                        catch (WebException ex2)
                        {
                            webClient.DownloadFile(product.items.item.images.normal[0].Value, local);

                        }
                    }
                }
            }
        }

    }
}
