//using Syncfusion.SfPicker.XForms;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Globalization;
//using System.Text;
//using Xamarin.Forms;
//using SelectionChangedEventArgs = Syncfusion.SfPicker.XForms.SelectionChangedEventArgs;

//namespace dnamethod.CustomControls
//{
//    public class CustomDatePicker : SfPicker
//    {
//        #region Public Properties

//        // Months API is used to modify the Day collection as per change in Month
//        internal Dictionary<string, string> Months { get; set; }

//        /// <summary>
//        /// Headers API is holds the column name for every column in date picker   
//        /// </summary>
//        /// <value>The Headers.</value>
//        public ObservableCollection<string> Headers { get; set; }

//        /// <summary>   
//        /// Date is the actual DataSource for SfPicker control which will holds the collection of Day ,Month and Year
//        /// </summary>
//        /// <value>The date.</value>
//        public ObservableCollection<object> Date { get; set; }

//        //Day is the collection of day numbers
//        internal ObservableCollection<object> Day { get; set; }

//        //Month is the collection of Month Names

//        internal ObservableCollection<object> Month { get; set; }

//        //Year is the collection of Years from 1990 to 2042

//        internal ObservableCollection<object> Year { get; set; }
//        #endregion

//        public CustomDatePicker()
//        {
//            Months = new Dictionary<string, string>();
//            Date = new ObservableCollection<object>();
//            Day = new ObservableCollection<object>();
//            Month = new ObservableCollection<object>();
//            Year = new ObservableCollection<object>();
//            PopulateDateCollection();
//            this.ItemsSource = Date;
//            //hook selection changed event
//            this.SelectionChanged += CustomDatePicker_SelectionChanged;
//            Headers = new ObservableCollection<string>();
//            Headers.Add("Month");
//            Headers.Add("Day");
//            Headers.Add("Year");
//            //SfPicker header text
//            HeaderText = "Date Picker";
//            // Column header text collection
//            this.ColumnHeaderText = Headers;
//            //Enable Footer
//            ShowFooter = true;
//            //Enable SfPicker Header      
//            ShowHeader = true;
//            //Enable Column Header of SfPicker
//            ShowColumnHeader = true;
//        }
//        private void CustomDatePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            UpdateDays(Date, e);
//        }
//        public void UpdateDays(ObservableCollection<object> Date, SelectionChangedEventArgs e)
//        {
//            Device.BeginInvokeOnMainThread(() =>
//            {
//                if (Date.Count == 3)
//                {
//                    bool flag = false;
                  
//                    if (e.OldValue != null && e.NewValue != null && (e.OldValue as ObservableCollection<object>).Count == 3 && (e.NewValue as ObservableCollection<object>).Count == 3)
//                    {
//                        if (!object.Equals((e.OldValue as IList)[0], (e.NewValue as IList)[0]))
//                        {
//                            flag = true;
//                        }
//                        if (!object.Equals((e.OldValue as IList)[2], (e.NewValue as IList)[2]))
//                        {
//                            flag = true;
//                        }
//                    }

//                    if (flag)
//                    {

//                        ObservableCollection<object> days = new ObservableCollection<object>();
//                        int month = DateTime.ParseExact(Months[(e.NewValue as IList)[0].ToString()], "MMMM", CultureInfo.InvariantCulture).Month;
//                        int year = int.Parse((e.NewValue as IList)[2].ToString());
//                        for (int j = 1; j <= DateTime.DaysInMonth(year, month); j++)
//                        {
//                            if (j < 10)
//                            {
//                                days.Add("0" + j);
//                            }
//                            else
//                                days.Add(j.ToString());
//                        }
//                        ObservableCollection<object> PreviousValue = new ObservableCollection<object>();

//                        foreach (var item in e.NewValue as IList)
//                        {
//                            PreviousValue.Add(item);
//                        }
//                        if (days.Count > 0)
//                        {
//                            Date.RemoveAt(1);
//                            Date.Insert(1, days);
//                        }

//                        if ((Date[1] as IList).Contains(PreviousValue[1]))
//                        {
//                            this.SelectedItem = PreviousValue;
//                        }
//                        else
//                        {
//                            PreviousValue[1] = (Date[1] as IList)[(Date[1] as IList).Count - 1];
//                            this.SelectedItem = PreviousValue;
//                        }
//                    }
//                }
//            });

//        }
//        private void PopulateDateCollection()
//        {
//            //populate months       
//            for (int i = 1; i < 13; i++)
//            {
//                if (!Months.ContainsKey(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3)))
//                    Months.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3), CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
//                Month.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3));

//            }
//            //populate year
//            for (int i = 1990; i < 2050; i++)
//            {
//                Year.Add(i.ToString());
//            }

//            //populate Days
//            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
//            {
//                if (i < 10)
//                {
//                    Day.Add("0" + i);
//                }
//                else
//                    Day.Add(i.ToString());
//            }

//            Date.Add(Month);

//            Date.Add(Day);

//            Date.Add(Year);

//        }

//    }
//    public class DatePickerViewModel : INotifyPropertyChanged
//    {
//        private ObservableCollection<object> _startdate;

//        public ObservableCollection<object> StartDate
//        {
//            get { return _startdate; }
//            set { _startdate = value; RaisePropertyChanged("StartDate"); }
//        }

//        public DatePickerViewModel()
//        {
//            ObservableCollection<object> todaycollection = new ObservableCollection<object>();

//            //Select today dates
//            todaycollection.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Date.Month).Substring(0, 3));
//            if (DateTime.Now.Date.Day < 10)
//                todaycollection.Add("0" + DateTime.Now.Date.Day);
//            else
//                todaycollection.Add(DateTime.Now.Date.Day.ToString());
//            todaycollection.Add(DateTime.Now.Date.Year.ToString());

//            this.StartDate = todaycollection;
//        }

//        void RaisePropertyChanged(string name)
//        {
//            if (PropertyChanged != null)
//                PropertyChanged(this, new PropertyChangedEventArgs(name));
//        }

//        public event PropertyChangedEventHandler PropertyChanged;
//    }
//}
