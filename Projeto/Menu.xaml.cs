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
using MySql.Data.MySqlClient;
using System.Data;

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

        private void ItemCaixa_Selected(object sender, RoutedEventArgs e)
        {
            Caixa cax = new Caixa();
            cax.Show();
            Close();
        }

        private void ListPedido_Selected(object sender, RoutedEventArgs e)
        {
            CadastrarPedido cadpedid = new CadastrarPedido();
            cadpedid.Show();
            Close();
        }

        private void ListCliente_Selected(object sender, RoutedEventArgs e)
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
                case "ItemCaixa":
                    usc = new UserControlHome();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemHome":
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

        private void ListProduto_Selected(object sender, RoutedEventArgs e)
        {
            ConsultaProduto conscli = new ConsultaProduto();
            conscli.Show();
            Close();
        }

        private void Totcliente_Initialized(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc; PASSWORD=;";
            MySqlCommand dcm = new MySqlCommand("SELECT COUNT(*) as total FROM CadastrarCliente", conn);
            conn.Open();
            MySqlDataReader dr = dcm.ExecuteReader();
            while (dr.Read())
            {
                totcliente.Content = dr["total"].ToString();
               
            }
            conn.Close();
        }

        private void Totpedido_Initialized(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc; PASSWORD=;";
            MySqlCommand dcm = new MySqlCommand("SELECT COUNT(*) as total FROM CadastrarPedido", conn);
            conn.Open();
            MySqlDataReader dr = dcm.ExecuteReader();
            while (dr.Read())
            {
                totpedido.Content = dr["total"].ToString();

            }
            conn.Close();
        }

        private void Totcaixa_Initialized(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc; PASSWORD=;";
            MySqlCommand dcm = new MySqlCommand("SELECT SUM(valor) as total FROM CadastrarCaixa", conn);
            conn.Open();
            MySqlDataReader dr = dcm.ExecuteReader();
            while (dr.Read())
            {
                totcaixa.Content = dr["total"].ToString();

            }
            conn.Close();
        }
    }
}

