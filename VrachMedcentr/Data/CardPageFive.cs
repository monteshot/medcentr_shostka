﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using kepkaSQL;
namespace VrachMedcentr
{
    class CardPageFive : INotifyPropertyChanged
    {
        public DataView page5 { get; set; }
        public string DataZvern { get; set; }

        connect con = new connect();
        private RelayCommand addCommand;
        public RelayCommand AddCommand5
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {

                      page5 = con.Dpage5("SELECT * FROM diary");

                  }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) =>
        {
        };
    }
}