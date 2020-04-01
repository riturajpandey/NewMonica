using MonicaLoanApp.Models;
using MonicaLoanApp.Models.Help;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Help
{
    public class HelpPageVM : BaseViewModel
    {
        #region Constructor
        public HelpPageVM(INavigation nav)
        {
            Navigation = nav;
            //QueryList = new ObservableCollection<HelpListModel>
            //{
            //    new HelpListModel{Question="Why has my card transaction declined?",Answer="Card not working? its worth double checking that you card is actibvated and enabled for the transaction type you are attempting"},
            //    new HelpListModel{Question="Why has my card transaction declined?",Answer="dsbhbcjadbcjknadklcnkladcncj;ac necfnjadfncibeafcnkjdfchibefkcn;fhibce;jfncjk;bdcjb efc"},
            //    new HelpListModel{Question="Why has my card transaction declined?",Answer="Card not working? its worth double checking that you card is actibvated and enabled for the transaction type you are attempting"},
            //    new HelpListModel{Question="Why has my card transaction declined?",Answer="dn jkcnkjdfncjkdsfnvjkbdsfjkvkadf;vjkadsf kj"},
            //    new HelpListModel{Question="Why has my card transaction declined?",Answer="Card not working? its worth double checking that you card is actibvated and enabled for the transaction type you are attempting"},
            //    new HelpListModel{Question="Why has my card transaction declined?",Answer="Card not working? its worth double checking that you card is actibvated and enabled for the transaction type you are attempting"},
            //    new HelpListModel{Question="Why has my card transaction declined?",Answer="Card not working? its worth double checking that you card is actibvated and enabled for the transaction type you are attempting"},
            //    new HelpListModel{Question="Why has my card transaction declined?",Answer="Card not working? its worth double checking that you card is actibvated and enabled for the transaction type you are attempting"},
            //};
        }
        #endregion

        #region Properties
        private ObservableCollection<HelpListModel> _QueryList;
        public ObservableCollection<HelpListModel> QueryList
        {
            get { return _QueryList; }
            set
            {
                if(_QueryList!= value)
                {
                    _QueryList = value;
                    OnPropertyChanged("QueryList");
                }
            }
        }

        private ObservableCollection<Staticdata> _FaqList;
        public ObservableCollection<Staticdata> FaqList
        {
            get { return _FaqList; }
            set
            {
                if (_FaqList != value)
                {
                    _FaqList = value;
                    OnPropertyChanged("FaqList");
                }
            }
        }

        #endregion

        #region Commands
        #endregion

        #region Methods
        /// <summary>
        /// Call This Api For StaticDataSearch
        /// </summary>
        /// <returns></returns>
        public async Task StaticDataSearch()
        {
            //Fileter Bank List From Static Data List..
            try
            {
                var filteredStatelist = Helpers.Constants.StaticDataList.Where(a => a.type == "FAQ").ToList();
                FaqList  = new ObservableCollection<Staticdata>(filteredStatelist);
            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }
        #endregion
    }
}
