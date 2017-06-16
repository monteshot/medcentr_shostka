using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VrachMedcentr
{
    class CardPageOne : INotifyPropertyChanged
    {

        public string Title { get; set; }
        #region Helpers method
    
        public void Setter()
        {
            Title = "fasfasf";
        }
      
        #endregion
        #region Event
        /// <summary>
        ///  Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {
        };

        #endregion
    }

}
