using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using IT_services.ViewModel;
using IT_services;
using System.Data;
namespace IT_services.ViewModel

{
    class ViewModel : BindableBase
    {
        public User user = new User();
        public Customer customer = new Customer();
        DataTable spisok = new DataTable();
        public servise servis = new servise();
        public DataTable spisok_order = new DataTable();
        public DataTable spisokCustomer = new DataTable();
        //public string emailCustomer = "";
        string price;
        
        public string emailEntrance="", passwordEntrance="", nameEntrance="", telephonEntrance="";
        public string email
        {
            get { return user.emailUser; }
            set { SetProperty(ref user.emailUser, value); }
        }
        public string password
        {
            get { return user.password; }
            set { SetProperty(ref user.password, value); }
        }

       /* public string telephonU
        {
            get { return user.telephon; }
            set { SetProperty(ref user.telephon, value); }
        }*/

        public string name
        {
            get { return user.Name; }
            set { SetProperty(ref user.Name, value); }
        }

        public string nameCustomer
        {
            get { return customer.NameCustomer; }
            set { SetProperty(ref customer.NameCustomer, value); }
        }

        public string phoneCustomer
        {
            get { return customer.telephonCustomer; }
            set { SetProperty(ref customer.telephonCustomer,value); }
        }
       

        public string emailE
        {
            get { return emailEntrance; }
            set { SetProperty(ref emailEntrance, value); }
        }
        public string passwordE
        {
            get { return passwordEntrance; }
            set { SetProperty(ref passwordEntrance, value); }
        }
        public string nameE
        {
            get { return nameEntrance; }
            set { SetProperty(ref nameEntrance, value); }
        }

        public string telephonE
        {
            get { return telephonEntrance; }
            set { SetProperty(ref telephonEntrance, value); }
        }

      /*  public string nameCus
        {
            get {  return customer.emailCustomer; }
            set { SetProperty(ref customer.emailCustomer, value); }
        }
        */
        public DataTable ser
        {
            get { spisok = user.readServise(); return spisok; }
            set { SetProperty(ref spisok, value); }
        }

       

        public string serviseName
        {
            get { return servis.name_servise; }
            set { SetProperty(ref servis.name_servise, value); }
        }

        public string serviseStart
        {
            get { return servis.start; }
            set { SetProperty(ref servis.start, value); }
        }

        public string serviseEnd
        {
            get { return servis.konets; }
            set { SetProperty(ref servis.konets, value); }
        }

        public string serviseCity
        {
            get { return servis.city; }
            set { SetProperty(ref servis.city, value); }
        }
        public string servisePhone
        {
            get { return servis.phone; }
            set { SetProperty(ref servis.phone, value); }
        }

        public string servisePrice
        {
            get { price = servis.price.ToString(); return price; }
            set {    SetProperty(ref price, value);  servis.price = float.Parse(price); }
        }
        public string serviseDescription
        {
            get { return servis.description; }
            set { SetProperty(ref servis.description, value); }
        }
    }
}
