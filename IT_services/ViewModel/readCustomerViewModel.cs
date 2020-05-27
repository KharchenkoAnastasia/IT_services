using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using IT_services;
using IT_services.View;
using System.Windows.Forms;
using System.Data;
using System.Windows.Controls;

namespace IT_services.ViewModel
{
    class readCustomerViewModel:ViewModel
    {
        public string idServise = "";
        public DelegateCommand<readCustomerView> UpdateOrder { get; set; }

        public DataTable SpisokCustomer
        {
            get { spisokCustomer = user.readCustomer(idServise); return spisokCustomer; }
            set { SetProperty(ref spisokCustomer, value); }
        }
        public readCustomerViewModel()
        {
            UpdateOrder = new DelegateCommand<readCustomerView>(update);
        }
        void update(readCustomerView parametr)
        {

            int row = parametr.dgC.SelectedIndex;
            if (row == -1) MessageBox.Show("Оберіть замовлення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                parametr.dgC.CurrentColumn = parametr.dgC.Columns[2];
                var selectedCell = parametr.dgC.SelectedCells[2];
                var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
                updateStatusView windows = new updateStatusView();
                if (windows.ShowDialog() == true)
                { if (windows.Box.Text == "") MessageBox.Show("Вкажіть потрібні дані для зміни статусу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        user.updateStatus(idServise, (cellContent as TextBlock).Text, windows.Box.Text);
                        SpisokCustomer = user.readCustomer(idServise);
                    }
                    SpisokCustomer = user.readCustomer(idServise);
                }
            }
            SpisokCustomer = user.readCustomer(idServise);
        }


    }
}
