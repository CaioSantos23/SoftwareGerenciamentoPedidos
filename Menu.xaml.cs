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

namespace TCC
{
    /// <summary>
    /// Lógica interna para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ItemHome_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ItemCreate_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            CadastrarPedido cadpedid = new CadastrarPedido();
            cadpedid.Show();
            Close();

        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            ConsultaCliente concli = new ConsultaCliente();
            concli.Show();
            Close();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UserControlHome();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCreate":
                    usc = new UserControlCreate();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {
            ConsultaProduto conscli = new ConsultaProduto();
            conscli.Show();
            Close();
        }
    }
}
