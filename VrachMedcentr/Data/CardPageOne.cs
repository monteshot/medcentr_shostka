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
        #region Helpers Class Object
        private DateTime thisDay = DateTime.Today;

        #endregion
        #region Data_page1

        public string CodeZYCD { get; set; }
        public string CodeZKPO { get; set; }
        public string NumberPacient { get; set; }
        public string CodePacient { get; set; }
        // public DateTime DateCardWriten { get; set; }
        public DateTime DateCardWriten { get => thisDay; set => thisDay = value; }
        public string Sername { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public bool SexFaMale { get; set; }
        #endregion
        #region Helpers method

        public void Setter()
        {
            CodeZYCD = "fasfasf";
            // DateTime Now = new DateTime();
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
