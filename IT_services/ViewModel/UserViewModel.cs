using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using IT_services.View;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Data;

namespace IT_services.ViewModel
{
    class UserViewModel : ViewModel
    {
        public DelegateCommand<UserView> Delete { get; set; }
        public DelegateCommand<UserView> Add { get; set; }
        public DelegateCommand<UserView> Read { get; set; }
        public DelegateCommand<UserView> Update { get; set; }

        public UserViewModel()
        {
            Delete = new DelegateCommand<UserView>(delete);
            Add = new DelegateCommand<UserView>(add);
            Read = new DelegateCommand<UserView>(read);
            Update = new DelegateCommand<UserView>(update);

        }

      void delete(UserView parametr)
        {
            
            int row = parametr.dg1.SelectedIndex;
           
            if (row == -1) MessageBox.Show("Оберіть послугу!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                DialogResult res = MessageBox.Show("Ви дійсно хочете видалити послугу ?", "Видалення послуги", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    parametr.dg1.CurrentColumn = parametr.dg1.Columns[0];
                    var selectedCell = parametr.dg1.SelectedCells[0];
                    var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
                    user.deleteServise((cellContent as TextBlock).Text);
                    ser = user.readServise();
                }
            }
        }

        void update(UserView parametr)
        {

        }

        void read(UserView parametr)
        {
            int row = parametr.dg1.SelectedIndex;

            if (row == -1) MessageBox.Show("Оберіть послугу!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                parametr.dg1.CurrentColumn = parametr.dg1.Columns[0];
                var selectedCell = parametr.dg1.SelectedCells[0];
                var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
                readCustomerView rcv = new readCustomerView();
                readCustomerViewModel rcvm = new readCustomerViewModel();
                rcvm.user.emailUser = user.emailUser;
                rcvm.user.password = user.password;
                rcvm.user.Name = user.Name;
                rcvm.user.telephon = user.telephon;
                rcvm.idServise = (cellContent as TextBlock).Text;
                rcv.Show();
                rcv.readCustomerG.DataContext = rcvm;
                
            }

        }

        void add(UserView parametr)
        {
             
            AddServiceView addv = new AddServiceView();
            AddServiceViewModel addvm = new AddServiceViewModel();
           addvm.user.emailUser = user.emailUser;
           addvm.user.password = user.password;
           addvm.user.Name = user.Name;
           //addvm.tel = user.telephon;
           addvm.user.telephon = user.telephon;
            addvm.servisePhone = user.telephon;
            addv.grMain1.DataContext = addvm;
            //addv.Show();
          
            if (addv.ShowDialog() == true)
            {
                ser = user.readServise();
            }

        }
    }
}
