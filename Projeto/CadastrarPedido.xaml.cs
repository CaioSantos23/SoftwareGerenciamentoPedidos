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
using Org.BouncyCastle.Utilities;


namespace TCC
{
    /// <summary>
    /// Lógica interna para CadastrarPedido.xaml
    /// </summary>
    public partial class CadastrarPedido : Window
    {
        double total = 0;
        public CadastrarPedido()
        {
         
            InitializeComponent();
        }


        private void MesaComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            mesa.Items.Add("10");
            mesa.Items.Add("15");
            mesa.Items.Add("20");
            mesa.Items.Add("25");
            mesa.Items.Add("30");
            mesa.Items.Add("40");
            mesa.Items.Add("50");
            mesa.Items.Add("60");
            mesa.Items.Add("70");
            mesa.Items.Add("80");
            mesa.Items.Add("90");
        }

        private void DatagridProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row = dg.SelectedItem as DataRowView;

            if (row != null)
            {
             dataGridPedidos.Items.Add(row);
             total = total+double.Parse(row["preco"].ToString());
             labtot.Content = total.ToString();

            }
        }

        private void dataGridPedidos_Initialized(object sender, EventArgs e)
        {
            carregar();
        }
        private void DatagridProdutos_Initialized(object sender, EventArgs e)
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
            DatagridProdutos.DataContext = dataSet;
        }

        private void btFinalizar_Click(object sender, RoutedEventArgs e)
        {
            if (mesa.Text != "" & tnomeproduto.Text != "")
            {
                if (MessageBox.Show("CADASTRAR PEDIDO?", "INFORMAÇÃO", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    try
                    {
                        for (int i = 0; i < dataGridPedidos.Items.Count; i++)
                        {
                            MySqlConnection conn = new MySqlConnection();
                        conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";
                        MySqlCommand dcm = new MySqlCommand();
                        dcm.Connection = conn;

                        dcm.CommandText = "INSERT INTO CadastrarPedido(comanda,nome,produto,categoria,preco) values" +
                            "(@comanda,@nome,@produto, @categoria,@preco)";
                 
                        DataRowView row = dataGridPedidos.Items[i] as DataRowView;
   
                        dcm.Parameters.AddWithValue("@comanda", mesa.Text);
                        dcm.Parameters.AddWithValue("@nome", tnomeproduto.Text);
                        dcm.Parameters.AddWithValue("@produto", row["produto"].ToString());
                        dcm.Parameters.AddWithValue("@categoria", row["categoria"].ToString());
                        dcm.Parameters.AddWithValue("@preco", row["preco"].ToString());
                        conn.Open();

                        dcm.ExecuteNonQuery();
                        conn.Close();
                        }

                        MessageBox.Show("PEDIDO CADASTRADO COM SUCESSO", "CADASTRO", MessageBoxButton.OK, MessageBoxImage.Information);

                    }

                    catch (Exception a)
                    {
                        MessageBox.Show(a.ToString(), "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    limparCampos();

                }
            }
        }
        public void limparCampos()
        {
            tnomeproduto.Clear();
            mesa.Text = "Selecione";
    
        }
        private void btConsulta_Click(object sender, RoutedEventArgs e)
        {
            ListaPedidosOnline ped = new ListaPedidosOnline();
            ped.Show();
            Close();
        }

        private void dataGridPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row = dg.SelectedItem as DataRowView;


            if (row != null)

            {
                dataGridPedidos.Items.Remove(row);
                total = total - double.Parse(row["preco"].ToString());
                labtot.Content = total.ToString();
            }
            if (dg.Items.Count == 0)
            {
                labtot.Content = "0";
            }
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }

        private void BtPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";

                MySqlCommand dcm = new MySqlCommand();
                dcm.Connection = conn;

                MySqlCommand SELECT = new MySqlCommand("SELECT codprod,codper,produto,categoria,preco  FROM CadastrarProduto WHERE produto LIKE '%" + tnomeproduto.Text + "%'", conn);
                SELECT.Parameters.AddWithValue("@produto", tnomeproduto.Text);

                MySqlDataAdapter adp = new MySqlDataAdapter(SELECT);
                DataSet dataSet = new DataSet();
                adp.Fill(dataSet, "Load");
                DatagridProdutos.DataContext = dataSet; 
            }
            catch
            {
                MessageBox.Show("ERROR!!!!");
            }
        }
    }
}
