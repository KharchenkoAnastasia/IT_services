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
    class RegistrationViewModel:ViewModel
    {
        public DelegateCommand<RegistrationView> Authorisation { get; set; }
        public DelegateCommand<RegistrationView> Registration { get; set; }

        public RegistrationViewModel()
        {
            Authorisation = new DelegateCommand<RegistrationView>(authorisation);
            Registration = new DelegateCommand<RegistrationView>(registration);
        }

        void registration(RegistrationView parametr)
        {
            var passwordBox = parametr.passwordBox;
            passwordE = passwordBox.Password;

            if (String.IsNullOrEmpty(passwordE) || String.IsNullOrEmpty(emailE)
                || String.IsNullOrEmpty(nameE) || parametr.Entrance.Text == "" || String.IsNullOrEmpty(telephonE))
                MessageBox.Show("Вкажіть потрібні для входу дані.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (emailE.Contains(" ") || emailE.Contains("\t") || emailE.Contains("\n"))
                MessageBox.Show("Вказаний email не може існувати.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (passwordE.Contains(" ") || passwordE.Contains("\t") || passwordE.Contains("\n"))
                MessageBox.Show("Некоректний пароль.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (nameE.Contains(" ") || nameE.Contains("\t") || nameE.Contains("\n"))
                MessageBox.Show("Некоректне ім'я.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (parametr.Entrance.Text.ToString() == "Виконавець")
            {
                if (user.registration(emailE,passwordE,nameE,telephonE))
                {
                    UserView userView = new UserView();
                    UserViewModel uservm = new UserViewModel();
                    uservm.user.emailUser = emailE;
                    uservm.user.password = passwordE;
                    uservm.user.Name = nameE;
                    uservm.user.telephon = telephonE;
                    userView.Show();
                    userView.grMain1.DataContext = uservm;
                    parametr.Close();
                }
                else MessageBox.Show("Користувач з вказаним email вже зареєстрований.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (customer.registration(emailE, passwordE, nameE,telephonE))
            {
                CustomerView cv = new CustomerView();
                CustomerViewModel cvm = new CustomerViewModel();

                cvm.customer.emailCustomer = emailE;


                cvm.customer.NameCustomer = "";
                cvm.customer.NameCustomer = nameE;
                cvm.emailEntrance = emailE;
                cvm.customer.telephonCustomer = telephonE;
                // cvm.emailEntrance = emailE;
                cv.Show();
                cv.CusV.DataContext = cvm;

                parametr.Close();
            }
            else
            {
                MessageBox.Show("Користувач з вказаним email вже зареєстрований.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        void authorisation(RegistrationView parametr)
        {
            AvtorizationView authorisationView = new AvtorizationView();
            authorisationView.Show();
            parametr.Close();
        }

    }
}
