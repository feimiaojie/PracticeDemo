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

        private string modelName;
        public string ModelName { get => modelName;
            set {
                modelName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ModelName"));
            }
        }

        private decimal unitCost;
        public decimal UnitCost { get => unitCost;
            set {
                if (value < 0)
                {
                    throw new ArgumentException("UnitCost cannot be negative.");
                }
                else
                {
                    unitCost = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("UnitCost"));
                }
            } }

        public string Description { get; set; }

        public Product(string modelNumber, string modelName, decimal unitCost, string description)
        {
            ModelNumber = modelNumber;
            ModelName = modelName;
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
