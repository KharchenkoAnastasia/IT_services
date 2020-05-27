using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using IT_services;
using System.Data;
using IT_services.View;
using System.Windows.Controls;
using System.Windows;

namespace IT_services.ViewModel
{
    class PoiskViewModel:ViewModel
    {
        public string email = "";
        public string poiskStr = "";
        public string priceOt = "", priceDo = "", dataOt = "", dataDo="";
        public DataTable resultPoisk = new DataTable();

        public string StringPoisk
        {
            get { return poiskStr; }
            set { SetProperty(ref poiskStr, value); }
        }

        public DataTable TablePoisk
        {
            get { return resultPoisk; }
            set { SetProperty(ref resultPoisk, value); }
        }

        public string OtPrice
        {
            get { return priceOt; }
            set { SetProperty(ref priceOt, value); }
        }

        public string DoPrice
        {
            get { return priceDo; }
            set { SetProperty(ref priceDo, value); }
        }
        public string OtDate
        {
            get { return dataOt; }
            set { SetProperty(ref dataOt, value); }
        }
        public string DoDate
        {
            get { return dataDo; }
            set { SetProperty(ref dataDo, value); }
        }

        public DelegateCommand<PoiskView> Vuv { get; set; }
        public DelegateCommand<PoiskView> Filter { get; set; }
        public DelegateCommand<PoiskView> Nazad { get; set; }
        public DelegateCommand<PoiskView> Order { get; set; }
        public PoiskViewModel()
        {
            Vuv = new DelegateCommand<PoiskView>(vuv);
            Nazad = new DelegateCommand<PoiskView>(nazad);
            Filter = new DelegateCommand<PoiskView>(filter);
            Order = new DelegateCommand<PoiskView>(order);
        }

        void order(PoiskView parametr)
        {
            int row = parametr.dgC.SelectedIndex;
            if (row == -1) MessageBox.Show("Оберіть послугу!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                parametr.dgC.CurrentColumn = parametr.dgC.Columns[0];
                var selectedCell = parametr.dgC.SelectedCells[0];
                var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
                customer.serviceOrder((cellContent as TextBlock).Text);
                MessageBox.Show("Послуга замовлена", "Замовлення", MessageBoxButton.OK, MessageBoxImage.Information);
            }
              
                               
        }

        void vuv(PoiskView parametr)
        {
            TablePoisk=customer.poiskServise(poiskStr);
            Console.WriteLine(customer.telephonCustomer);


        }
        void filter(PoiskView parametr)
        {
            if (priceOt != "" && priceDo != "")
            {
                TablePoisk = customer.filterPrice(priceOt, priceDo, resultPoisk);
                
            }
           
            if (dataOt != "")
            {
                TablePoisk = customer.filterDate(dataOt, resultPoisk);
            }
            
            if (parametr.CityF.Text!= "")
            {
                TablePoisk = customer.filterCity(parametr.CityF.Text, resultPoisk);
            }
            if (priceOt== "" && priceDo== "" && dataOt== "" && parametr.CityF.Text == "") { MessageBox.Show("Вкажіть потрібні для застосування фільтру.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error); }

            OtPrice = "";
            DoPrice = "";
            OtDate = "";
            parametr.CityF.Text = "";
           

        }
        void nazad(PoiskView parametr)
        {
            CustomerView cv = new CustomerView();
            CustomerViewModel cvm = new CustomerViewModel();

            cvm.customer.emailCustomer = customer.emailCustomer;


            cvm.customer.NameCustomer = "";
            cvm.customer.NameCustomer = customer.NameCustomer;
            cvm.emailEntrance = customer.emailCustomer;
            cvm.customer.telephonCustomer = customer.telephonCustomer;
            
            cv.Show();
            cv.CusV.DataContext = cvm;

            parametr.Close();
        }
    }
}
