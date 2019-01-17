using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WpfApp2
{
    /// <summary>
    /// Interação lógica para UserControl1.xam
    /// </summary>
    public partial class CustomTextBox : UserControl
    {




        public bool Validated
        {
            get { return (bool)GetValue(ValidatedProperty); }
            set { SetValue(ValidatedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValidatedProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidatedProperty =
            DependencyProperty.Register("ValidatedProperty", typeof(bool), typeof(CustomTextBox), new PropertyMetadata(false));




        private static readonly Regex _regex = new Regex("[^0-9]");


        public int PropCVType
        {
            get { return (int)GetValue(CVType); }
            set { SetValue(CVType, (int)value); }
        }
        public static readonly DependencyProperty CVType = DependencyProperty.Register("PropCVType", typeof(int), typeof(CustomTextBox), new FrameworkPropertyMetadata(
     0,
     new PropertyChangedCallback(OnCVTypePropertyChanged)));



        public string CustomToolTip
        {
            get { return (string)GetValue(MyPropertycustomTolTip); }
            set { SetValue(MyPropertycustomTolTip,value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertycustomTolTip =
            DependencyProperty.Register("CustomToolTip", typeof(string), typeof(CustomTextBox), new FrameworkPropertyMetadata(
     null,
     new PropertyChangedCallback(OnFirstPropertyChanged)));





        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(CustomTextBox), new FrameworkPropertyMetadata(
     null,
     new PropertyChangedCallback(OnLabelTexttPropertyChanged)));



    private static void OnLabelTexttPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
         CustomTextBox c = sender as CustomTextBox;
            if (c != null)
            {
                c.OnLabelTextChanged();
            }
    }
    
        public void OnLabelTextChanged()
        {
            label1.Content = LabelText;

        }

        private static void OnFirstPropertyChanged(
   DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomTextBox c = sender as CustomTextBox;
            if (c != null)
            {
                c.OnToolTipChanged();
            }
        }
        private static void OnCVTypePropertyChanged(
        DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomTextBox c = sender as CustomTextBox;
            if (c != null)
            {
                c.OnCVTypeChanged();
            }
        }

        private void OnCVTypeChanged()
        {
            
            if (PropCVType == 2)
            {
                bool handled = !_regex.IsMatch(textBox.Text);
                if (!handled)
                {
                    textBox.BorderBrush = System.Windows.Media.Brushes.Red;
                    // MessageBox.Show("esse campo so pode conter numeros");
                    //MessageBox.Show((string)CustomToolTip);
                    //
                }

            }
            if (PropCVType == 1 || PropCVType == 3 || PropCVType == 2)
            {
                if (textBox.Text == "")
                {
                    textBox.BorderBrush = System.Windows.Media.Brushes.Red;
                }
            }
        }

        private void OnToolTipChanged()
        {
            ToolTip tooltip = new ToolTip { Content = (string)CustomToolTip };
            textBox.ToolTip = tooltip;
            tooltip.IsOpen = true;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

            if (PropCVType == 2)
            {
                bool handled = !_regex.IsMatch(textBox.Text);
                if (!handled || textBox.Text == "")
                {
                    textBox.BorderBrush = System.Windows.Media.Brushes.Red;
                    Validated = false;
                    // MessageBox.Show("esse campo so pode conter numeros");
                    //MessageBox.Show((string)CustomToolTip);
                    //
                }
                else
                {
                    Validated = true;
                    textBox.BorderBrush = System.Windows.Media.Brushes.Blue;
                }

            }
            if (PropCVType == 1 ||  PropCVType == 3 )
            {
                if (textBox.Text == "")
                {
                    Validated = false;
                    textBox.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    Validated = true;
                    textBox.BorderBrush = System.Windows.Media.Brushes.Blue;
                }
            }
        }



        public CustomTextBox()
        {

            InitializeComponent();
            DataContext = this;
            
  
        }


    }
}
