using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.DB
{
    public class Product:INotifyPropertyChanged
    {
        public string ModelNumber { get; set; }

        public string ModelName { get; set; }

        private decimal unitCost;
        public decimal UnitCost { get => unitCost;
            set {
                unitCost = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UnitCost"));
            } }

        public string Description { get; set; }

        public Product(string modelNumber, string modelName, decimal unitCost, string description)
        {
            ModelNumber = modelNumber;
            ModelName = ModelName;
            UnitCost = unitCost;
            Description = description;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
