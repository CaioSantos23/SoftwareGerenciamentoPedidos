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

                MySqlCommand SELECT = new MySqlCommand("SELECT codpedon,cliente,descricao,categoria,valortotal,recebimento,dat,stat  FROM PedidosOnline WHERE codpedon LIKE '%" + tnomeproduto.Text + "%'", conn);
                SELECT.Parameters.AddWithValue("@codpedon", tnomeproduto.Text);

                MySqlDataAdapter adp = new MySqlDataAdapter(SELECT);
                DataSet dataSet = new DataSet();
                adp.Fill(dataSet, "Load");
                dataGridProdutoCompras.DataContext = dataSet;
            }
            catch
            {
                MessageBox.Show("ERROR!!!!");
            }

        }
        private void BtIr_Click(object sender, RoutedEventArgs e)
        {
            CarregarPeriodoData();
        }

        private void dataGridProdutoCompras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void CarregarPeriodoData()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";

            MySqlCommand dcm = new MySqlCommand();
            dcm.Connection = conn;

            MySqlCommand SELECT = new MySqlCommand("SELECT codpedon,cliente,descricao,categoria,valortotal,recebimento,dat,stat FROM PedidosOnline  WHERE data BETWEEN @inicio and @fim group by descricao", conn);
            SELECT.Parameters.AddWithValue("@inicio", tdatInicio);
            SELECT.Parameters.AddWithValue("@fim", tdatFim);
            MySqlDataAdapter adp = new MySqlDataAdapter(SELECT);
            DataSet dataSet = new DataSet();
            adp.Fill(dataSet, "Load");
            dataGridProdutoCompras.DataContext = dataSet;

        }

        private void DataGridProdutoCompras_Initialized(object sender, EventArgs e)
        {

        }


        private void tnomeproduto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }
    }
}
 