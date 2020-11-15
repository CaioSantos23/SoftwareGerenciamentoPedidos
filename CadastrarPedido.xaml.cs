using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
namespace TCC
{
    /// <summary>
    /// Lógica interna para CadastrarPedido.xaml
    /// </summary>
    public partial class CadastrarPedido : Window
    {
        public CadastrarPedido()
        {
            InitializeComponent();
        }

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            comanda.Items.Add("10");
            comanda.Items.Add("20");
            comanda.Items.Add("30");
            comanda.Items.Add("40");
            comanda.Items.Add("50");
            comanda.Items.Add("60");
            comanda.Items.Add("70");
            comanda.Items.Add("80");
            comanda.Items.Add("90");
        }
        private void Limpa()
        {
           
        }

        private void btpesquisa_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void Dtgridcliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row = dg.SelectedItem as DataRowView;
          


            if (row != null)
            {
             dataGridProdutoCompras.Items.Add(row);

            }
        }

        private void DataGridProdutoCompras_Initialized(object sender, EventArgs e)
        {
            carregar();
        }
        private void Dtgridcliente_Initialized_1(object sender, EventArgs e)
        {
            carregar();
        }
        public void carregar()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";
            MySqlCommand dcm = new MySqlCommand();
            dcm.Connection = conn;

            MySqlCommand SELECT = new MySqlCommand("SELECT * FROM CadastrarProduto", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(SELECT);
            DataSet dataSet = new DataSet();
            adp.Fill(dataSet, "Load");
            Dtgridcliente.DataContext = dataSet;
        }
        private void Dtgridcliente_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Inserir_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void excluir_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridProdutoCompras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          

        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
