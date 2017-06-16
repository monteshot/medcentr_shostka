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

        #region Data_page1

        public string CodeZYCD { get; set; }
        public string CodeZKPO { get; set; }
        public string CodePacient { get; set; }
        #endregion
        #region Helpers method

        public void Setter()
        {
            CodeZYCD = "fasfasf";
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
