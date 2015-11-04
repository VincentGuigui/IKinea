using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikinea.Rest;
using IKinea.Services;

namespace IKinea.ViewModels
{
    public class FurnitureViewModel : ViewModelBase
    {
        FurnitureService _furnitureService;
        public FurnitureViewModel()
        {
            _furnitureService = new FurnitureService();
        }
        
        ObservableCollection<productsProduct> _products = new ObservableCollection<productsProduct>();

        public ObservableCollection<productsProduct> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        public void LoadFurnitures()
        {
            _furnitureService.LoadData();
        }

        public ObservableCollection<productsProduct> SelectAll()
        {
            Products = new ObservableCollection<productsProduct>(_furnitureService.AllFurnitures);
            return Products;
        }

        public ObservableCollection<productsProduct> SelectByDimensions(int w, int d, int h, int doors, int shelves)
        {
            Products = new ObservableCollection<productsProduct>(_furnitureService.SelectByDimensions(w, d, h, doors, shelves).Take(5));
            return Products;
        }

    }
}
