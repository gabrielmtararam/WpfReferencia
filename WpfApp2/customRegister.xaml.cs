using Microsoft.Win32;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for customRegister.xaml
    /// </summary>
    public partial class customRegister : UserControl
    {
        public customRegister Main;

        public customRegister()
        {
            Main = this;
            InitializeComponent();
        }
        private void selectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                userImage.Source = new BitmapImage(new Uri(op.FileName));
            }

        }



        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }


        private void WindowSaveEventHanddler(object sender, EventArgs e)
        {
            string message = "";
            bool validated = true;

            foreach (CustomTextBox tb in FindVisualChildren<CustomTextBox>(Main))
            {
                if (tb.Validated == false)
                {
                    message += " \n  " + tb.CustomToolTip;
                    validated = false;
                }
            }

            if (validated == false)
                MessageBox.Show("" + message);
            else
                MessageBox.Show("" + "salvo com sucesso");
        }
    }
}

