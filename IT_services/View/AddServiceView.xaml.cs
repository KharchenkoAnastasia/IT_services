using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IT_services.View
{
    /// <summary>
    /// Логика взаимодействия для AddServiceView.xaml
    /// </summary>
    public partial class AddServiceView : Window
    {
        public AddServiceView()
        {
            InitializeComponent();
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(nameSer.ToString()) || String.IsNullOrEmpty(startSer.ToString()) ||
                String.IsNullOrEmpty(endSer.ToString()) || String.IsNullOrEmpty(citySer.ToString()) ||
                String.IsNullOrEmpty(priceSer.ToString()) || String.IsNullOrEmpty(phoneSer.ToString())
                || String.IsNullOrEmpty(decriptionSer.ToString()))
            { MessageBox.Show("Вкажіть потрібні для входу дані.", "Помилка", MessageBoxButton.OKCancel, MessageBoxImage.Error);  this.DialogResult = false; }
            else this.DialogResult = true;
        }
    }
}
