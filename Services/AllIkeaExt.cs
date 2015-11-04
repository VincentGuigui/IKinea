using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikinea.Rest
{

    public partial class productsProduct
    {
        public override bool Equals(object obj)
        {
            return obj != null && this.GetHashCode().Equals(obj.GetHashCode());
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            if (this.name == null || this.items == null || this.items.item == null || this.items.item.facts == null || this.partNumber == null || this.items.item.partNumber == null)
                return "furniture is empty";
            return this.name + " (" + this.items.item.facts + ")" + this.partNumber + "/" + this.items.item.partNumber;
        }
    }

    public partial class productsProductItemsItem
    {
        public string ImageZoom
        {
            get
            {
                return "Ikea\\png\\" + this.partNumber + ".png";
            }
        }

        private string _dimensions = null;
        public string Dimensions
        {
            get
            {
                if (_dimensions == null)
                {
                    //productsProductItemsItemAttributeItem paDim = this.attributesItems.FirstOrDefault(a => a.name == "dimensions");
                    //if (paDim == null)
                    //    _dimensions = "";
                    //else
                    //    _dimensions = paDim.value;
                    string[] measures = this.measure.Split(new string[] { "</m><m>" }, 4, StringSplitOptions.RemoveEmptyEntries);
                    string mw = "1", md = "40", mh = "1";
                    foreach (string measure in measures)
                    {
                        if (measure.Contains("<d>Largeur</d>"))
                            mw = measure.Remove(measure.IndexOf(" cm")).Remove(0, measure.IndexOf("</d><v>")+7);
                        if (measure.Contains("<d>Hauteur</d>"))
                            mh = measure.Remove(measure.IndexOf(" cm")).Remove(0, measure.IndexOf("</d><v>") + 7);
                        if (measure.Contains("<d>Profondeur</d>"))
                            md = measure.Remove(measure.IndexOf(" cm")).Remove(0, measure.IndexOf("</d><v>") + 7);
                    }
                    int w = 1, d = 40, h = 1;
                    int.TryParse(mw, out w);
                    int.TryParse(md, out d);
                    int.TryParse(mh, out h);
                    _dimensionsTuple = new Tuple<int, int, int>(w, d, h);
                    _dimensions = string.Format("{0}x{1}x{2} cm", w, d, h);
                }
                return _dimensions;
            }
        }

        private Tuple<int, int, int> _dimensionsTuple = null;
        public Tuple<int, int, int> DimensionsTuple
        {
            get
            {
                //if (_dimensionsTuple == null)
                //{
                //    int w = 1, d = 1, h = 1;
                //    string[] dimensions = Dimensions.Split('x', ' ');
                //    int.TryParse(dimensions[0], out w);
                //    if (dimensions.Length == 3 && dimensions[2] == "cm")
                //    {
                //        int.TryParse(dimensions[1], out h);
                //        d = 40;
                //    }
                //    if (dimensions.Length == 4 && dimensions[3] == "cm")
                //    {
                //        int.TryParse(dimensions[1], out d);
                //        int.TryParse(dimensions[2], out h);
                //    }
                //    if (w == 0) w = 1;
                //    if (d == 0) d = 1;
                //    if (h == 0) h = 1;
                //    _dimensionsTuple = new Tuple<int, int, int>(w, d, h);
                //}
                return _dimensionsTuple;
            }
        }

        private Tuple<int, int, int> _pictureDimensionsTuple = null;
        public Tuple<int, int, int> PictureDimensionsTuple
        {
            get
            {
                if (_pictureDimensionsTuple == null)
                {
                    int w = 1, d = 1, h = 1;
                    w = (int)(DimensionsTuple.Item1 + Math.Cos(12d * Math.PI / 180d) * DimensionsTuple.Item2 / 3d);
                    d = DimensionsTuple.Item2;
                    h = (int)(DimensionsTuple.Item3 + Math.Sin(12d * Math.PI / 180d) * DimensionsTuple.Item2 / 3d + Math.Sin(7d * Math.PI / 180d) * DimensionsTuple.Item1);
                    _pictureDimensionsTuple = new Tuple<int, int, int>(w, d, h);
                }
                return _dimensionsTuple;
            }
        }

        public int Volume
        {
            get
            {
                if (string.IsNullOrEmpty(this.Dimensions)) return 0;
                return DimensionsTuple.Item1 * DimensionsTuple.Item3;// *DimensionsTuple.Item3;
            }
        }
    }
}
