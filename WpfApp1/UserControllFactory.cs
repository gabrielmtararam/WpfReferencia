using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class UserControllFactory
    {
        UserControllFactory(int panelType, int textType, int fontSize=25)
        {
            switch (panelType)
            {
                case 0:
                        myPanel.Children.Insert(0, myNewControl);
                    break;
                    
            }
        }

    }
}
