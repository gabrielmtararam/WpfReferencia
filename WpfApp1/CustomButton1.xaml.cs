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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para CustomButton1.xam
    /// </summary>
    public partial class CustomButton1 : UserControl
    {
        public event EventHandler SaveClicked;


        public CustomButton1()
        {
            InitializeComponent();
        }


        private void saveFromBtn(object sender, RoutedEventArgs e)
        {
            SaveClicked?.Invoke(sender, e);
            MessageBox.Show("" + SaveClicked);

            //CustomTextBox x;
            //object obj = Application.Current.MainWindow.FindName("TBreceita");
            //if (obj is CustomTextBox)
            //{
            //    x = CustomTextBox(obj);
            //}
            //MessageBox.Show(""+ obj.);
        }

       
    }
}
