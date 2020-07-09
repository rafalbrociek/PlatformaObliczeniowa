using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaObliczeniowa.ViewModele.BaseClasses
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Zdarzenie uruchamiane, gdy dowolna właściwość zmienia swoją wartość
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
