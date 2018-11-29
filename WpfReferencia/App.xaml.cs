using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfReferencia
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {


        private void Application_Startup(object sender, StartupEventArgs e)
        {

            MainWindow wnd = new MainWindow();

            wnd.Title = "janela criada por um metodo e nao passando a janela como parametro";
 
            wnd.Show();
        }


    }
}
