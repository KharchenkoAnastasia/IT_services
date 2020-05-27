using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using IT_services;
using IT_services.View;
using System.Windows.Controls;
using System.Windows.Data;
//using System.Windows;
using System.Windows.Forms;


namespace IT_services.ViewModel
{
    class CustomerViewModel:ViewModel

    {
        public DelegateCommand<CustomerView> Delete { get; set; }
        public DelegateCommand<CustomerView> Poisk { get; set; }

        public DataTable OrderSpisok
        {
            get { customer.emailCustomer = emailEntrance; spisok_order = customer.readOrder(); return spisok_order; }
            set { SetProperty(ref spisok_order, value); }      
        }

        public CustomerViewModel()
        {
            Delete = new DelegateCommand<CustomerView>(delete);
            Poisk = new DelegateCommand<CustomerView>(poisk);
        }

        void delete(CustomerView parametr)
        {
            int row = parametr.dgC.SelectedIndex; 
            if (row == -1) MessageBox.Show("Оберіть замовлення!", "Помилка",MessageBoxButtons.OK,MessageBoxIcon.Error);

            else
            {
               
                DialogResult res = MessageBox.Show("Ви дійсно хочете видалити замовлення ?", "Видалення замовлення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    parametr.dgC.CurrentColumn = parametr.dgC.Columns[0];
                    var selectedCell = parametr.dgC.SelectedCells[0];
                    var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
                    customer.Delete((cellContent as TextBlock).Text);
                    OrderSpisok = customer.readOrder();
                    System.Windows.MessageBox.Show("Замовлення видалено", "Видалення", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }
            }
        }

        void poisk(CustomerView parametr)
        {
            PoiskView pv = new PoiskView();
            PoiskViewModel pvm = new PoiskViewModel();
            pvm.customer.emailCustomer = customer.emailCustomer;
            pvm.customer.NameCustomer = customer.NameCustomer;
            pvm.email = customer.emailCustomer;
            pvm.customer.telephonCustomer = customer.telephonCustomer;
            pv.Show();
            pv.PoiskV.DataContext = pvm;
            parametr.Close();
        }
    }
}
