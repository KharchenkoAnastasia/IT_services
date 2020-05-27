using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using IT_services.View;
using System.ComponentModel;
//using System.Windows;
using System.Collections;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Data;
using System.Windows.Forms;
namespace IT_services.ViewModel
{
    class AddServiceViewModel : ViewModel
    {
        public DelegateCommand<AddServiceView> AddSer { get; set; }
        public string tel="";
      // public bool but=fak

        public AddServiceViewModel()
        {
            AddSer = new DelegateCommand<AddServiceView>(addSer);
            
        }

        

        void addSer(AddServiceView parametr)
        {
            if (String.IsNullOrEmpty(serviseName) || String.IsNullOrEmpty(serviseStart) ||
                String.IsNullOrEmpty(serviseEnd) || String.IsNullOrEmpty(serviseCity)
                || String.IsNullOrEmpty(servisePhone) || String.IsNullOrEmpty(servisePrice) ||
                String.IsNullOrEmpty(serviseDescription))
            { MessageBox.Show("Вкажіть потрібні для входу дані.", "Помилка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); 
            }
            else
            {
                user.add_servise(servis);
                parametr.Close();
            }
           
        }
    }
}
