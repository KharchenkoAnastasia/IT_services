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
    /// Логика взаимодействия для updateStatusView.xaml
    /// </summary>
    public partial class updateStatusView : Window
    {
        public updateStatusView()
        {
            InitializeComponent();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            
            this.DialogResult = true;
        }
        public string StatusOrder
        {
            get { return Box.Text; }
        }
    }
}
