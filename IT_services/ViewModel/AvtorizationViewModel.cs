using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using IT_services;
using IT_services.View;
using System.Windows;
namespace IT_services.ViewModel
{
    class AvtorizationViewModel:ViewModel
    {    
       
        public DelegateCommand <AvtorizationView> Avtorization { get; set; }
        public DelegateCommand<AvtorizationView> Registration { get; set; }

        public AvtorizationViewModel()
        {
            Avtorization = new DelegateCommand<AvtorizationView>(authorisation);
            Registration = new DelegateCommand<AvtorizationView>(registration);
            
        }

        void authorisation(AvtorizationView parametr)
        {
           
            
             var passwordBox = parametr.passwordBox;
             passwordE = passwordBox.Password;
             if (String.IsNullOrEmpty(passwordE) || String.IsNullOrEmpty(emailE) || parametr.Entrance.Text=="")
                 MessageBox.Show("Вкажіть потрібні для входу дані.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
             else if ( emailE.Contains(" ") || emailE.Contains("\t") || emailE.Contains("\n"))
                 MessageBox.Show("Вказаний email не може існувати.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
             else if (passwordE.Contains(" ") || passwordE.Contains("\t") || passwordE.Contains("\n"))
                 MessageBox.Show("Вказаний пароль не може існувати.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
             else if (parametr.Entrance.Text.ToString()=="Виконавець") {
                if (user.authorisation(emailE,passwordE)) {

                     UserView userView = new UserView();
                     UserViewModel uservm = new UserViewModel();
                     uservm.user.emailUser = emailE;
                     uservm.user.password = passwordE;
                     uservm.user.Name = user.Name;
                     uservm.user.telephon = user.telephon;
                    
                    
                     userView.Show();
                     userView.grMain1.DataContext = uservm;
                    
                    parametr.Close();
                }
                else MessageBox.Show("Користувач з вказаними даними відсутній.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
             else if (customer.authorisation(emailE, passwordE))
            {
                CustomerView cv = new CustomerView();
                CustomerViewModel cvm = new CustomerViewModel();
                
                cvm.customer.emailCustomer = customer.emailCustomer;

                
                cvm.customer.NameCustomer = "";
                cvm.customer.NameCustomer=customer.NameCustomer;
                cvm.emailEntrance = customer.emailCustomer;
                cvm.customer.telephonCustomer = customer.telephonCustomer;
               // cvm.emailEntrance = emailE;
                cv.Show();
                cv.CusV.DataContext = cvm;

                parametr.Close();
            } else MessageBox.Show("Користувач з вказаними даними відсутній.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);


            
        }

        void registration(AvtorizationView parametr)
        {
            RegistrationView registrationView = new RegistrationView();
            registrationView.Show();
            parametr.Close();
        }


    }


}
