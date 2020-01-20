using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.DB
{
    public class Product:INotifyPropertyChanged,INotifyDataErrorInfo
    {
        private string modelNumber;
        public string ModelNumber { get => modelNumber;
            set {
                modelNumber = value;

                bool valid = true;
                foreach (char c in modelNumber)
                {
                    if (!Char.IsLetterOrDigit(c))
                    {
                        valid = false;
                        break;
                    }
                }
                if (!valid)
                {
                    List<string> errors = new List<string>();
                    errors.Add("The ModelNumber can only contain letters and numbers.");
                    SetErrors("ModelNumber", errors);
                }
                else
                {
                    ClearErrors("ModelNumber");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("ModelNumber"));
            } }

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


        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        public bool HasErrors
        {
            get { return errors.Any(); }
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return errors.Values;
            }
            else
            {
                if (errors.ContainsKey(propertyName))
                {
                    return errors[propertyName];
                }
                else
                {
                    return null;
                }
            }
        }

        private void SetErrors(string propertyName, List<string> propertyErrors)
        {
            errors.Remove(propertyName);

            errors.Add(propertyName, propertyErrors);

            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        private void ClearErrors(string propertyName)
        {
            errors.Remove(propertyName);
            
            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
    }
}
