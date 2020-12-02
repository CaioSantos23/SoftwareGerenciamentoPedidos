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
    /// Lógica interna para CadastrarCliente.xaml
    /// </summary>
    public partial class ListaPedidosOnline : Window
    {
        public ListaPedidosOnline()
        {
            InitializeComponent();
        }

        private void btpesquisa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";

                MySqlCommand dcm = new MySqlCommand();
                dcm.Connection = conn;

                MySqlCommand SELECT = new MySqlCommand("SELECT * FROM CadastrarPedido WHERE nome LIKE '%" + tnomepedido.Text + "%'", conn);
                SELECT.Parameters.AddWithValue("@nome", tnomepedido.Text);

                MySqlDataAdapter adp = new MySqlDataAdapter(SELECT);
                DataSet dataSet = new DataSet();
                adp.Fill(dataSet, "Load");
                dataGridPedidos.DataContext = dataSet;
            }
            catch
            {
                MessageBox.Show("ERROR!!!!");
            }

        }

        private void dataGridPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row = dg.SelectedItem as DataRowView;
        }

        public void CarregarPeriodoData()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";
            MySqlCommand dcm = new MySqlCommand();
            dcm.Connection = conn;

            MySqlCommand SELECT = new MySqlCommand("SELECT * FROM CadastrarPedido ", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(SELECT);
            DataSet dataSet = new DataSet();
            adp.Fill(dataSet, "Load");
            dataGridPedidos.DataContext = dataSet;
        }

        private void dataGridPedidos_Initialized(object sender, EventArgs e)
        {
            CarregarPeriodoData();
        }


        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }

        private void Btconcluido_Click(object sender, RoutedEventArgs e)
        {
         
            DataRowView row = dataGridPedidos.SelectedItem as DataRowView;

            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";
                MySqlCommand Deletar = new MySqlCommand("DELETE FROM CadastrarPedido WHERE codped='" + row["codped"] + "'", conn);

                if
                    (MessageBox.Show("CONCLUIR PEDIDO?", "INFORMAÇÃO", MessageBoxButton.YesNo, MessageBoxImage.Information ) == MessageBoxResult.Yes)

                {
                    MessageBox.Show("PEDIDO CONCLUIDO", "INFORMAÇÃO", MessageBoxButton.OK, MessageBoxImage.Information);

                    conn.Open();
                    Deletar.ExecuteNonQuery();
                    conn.Close();
                }


                CarregarPeriodoData();
            }
            catch
            {
                MessageBox.Show("NÃO FOI POSSIVEL CONCLUIR");
            }

        }
       
    }
}
 