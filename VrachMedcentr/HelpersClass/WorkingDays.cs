using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VrachMedcentr.HelpersClass.MyHalpers
{

    public  class HolidayHelper
    {
        static ObservableCollection<DateTime> temp = new ObservableCollection<DateTime>();
        static ObservableCollection<DependencyObject> tempDP = new ObservableCollection<DependencyObject>();
        public static ObservableCollection<DateTime> GetList(DependencyObject obj)
        {
            return (ObservableCollection<DateTime>)obj.GetValue(ListProperty);
        }

        public static void SetList(DependencyObject obj, DateTime value)
        {
            obj.SetValue(ListProperty, value);
        }

        public static readonly DependencyProperty ListProperty =
        DependencyProperty.RegisterAttached("List", typeof(ObservableCollection<DateTime>), typeof(HolidayHelper), new PropertyMetadata { PropertyChangedCallback = ListPropertyChanged });

        private static void ListPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            foreach(var a in tempDP)
            {
                SetIsHoliday(a, false);
            }
            var date = GetList(d);
            temp = date;
            foreach( var a in tempDP)
            {
              if(temp.Contains(GetDate(a)))
                {
                    SetIsHoliday(a, true);
                }
            }
            // PropertyChangedCallback = DatePropertyChanged;
            
        }
        




        public static readonly DependencyProperty DateProperty =
       DependencyProperty.RegisterAttached("Date", typeof(DateTime), typeof(HolidayHelper), 
           new PropertyMetadata { PropertyChangedCallback = DatePropertyChanged });
        

        public static DateTime GetDate(DependencyObject obj)
        {
            return (DateTime)obj.GetValue(DateProperty);
        }

        public static void SetDate(DependencyObject obj, DateTime value)
        {
            obj.SetValue(DateProperty, value);
        }

       

        private static void DatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            tempDP.Add(d);
            SetIsHoliday(d, false);
            var date = GetDate(d);
            
            if (temp.Contains(date))
            {
               SetIsHoliday(d, true);
            }
        }

        public static bool CheckIsHoliday( DateTime date)
        {

            
            return true;

        }
     

        private static readonly DependencyPropertyKey IsHolidayPropertyKey =
        DependencyProperty.RegisterAttachedReadOnly("IsHoliday", typeof(bool), typeof(HolidayHelper), new PropertyMetadata());

        public static readonly DependencyProperty IsHolidayProperty = IsHolidayPropertyKey.DependencyProperty;
       

        public static bool GetIsHoliday(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsHolidayProperty);
        }

        private static void SetIsHoliday(DependencyObject obj, bool value)
        {
            obj.SetValue(IsHolidayPropertyKey, value);
        }
    }

}
