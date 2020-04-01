using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Help
{
    public class DebitCardQueriesVM : BaseViewModel
    {
        #region Constructor
        public DebitCardQueriesVM(INavigation nav)
        {
            Navigation = nav;
        }
        #endregion

        #region Properties
        private string _key;
        public string key
        {
            get { return _key; }
            set
            {
                if(_key != value)
                {
                    _key = value;
                    OnPropertyChanged("key");
                }
            }
        }
        private string _data;
        public string data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged("data");
                }
            }
        }
        #endregion

    }
}
