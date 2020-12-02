using System;
using System.Collections.Generic;
using System.Data;
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


namespace TCC
{
    /// <summary>
    /// Lógica interna para ConsultaProdutos.xaml
    /// </summary>
    public partial class ConsultaProduto : Window
    {
        public ConsultaProduto()
        {
            InitializeComponent();

        }

        private void Inserir_Click_1(object sender, RoutedEventArgs e)
        {
            CadastrarProduto cadpro = new CadastrarProduto();
            cadpro.Show();
            Close();
        }
        
        private void DtgridProduto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row = dg.SelectedItem as DataRowView;

            if (row != null)
            {
                tcod1.Text = row["codprod"].ToString();
                tcodper.Text = row["codper"].ToString();
                tproduto.Text = row["produto"].ToString();
                tcategoria.Text = row["categoria"].ToString();
                tpreco.Text = row["preco"].ToString();
            }
        }

        private void DtgridProduto_Initialized(object sender, EventArgs e)
        {
            carregar();
        }

        private void btAtualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";

                MySqlCommand Update = new MySqlCommand("UPDATE CadastrarProduto SET codper ='" + tcodper.Text + "',produto = '" + tproduto.Text + "',categoria = '" + tcategoria.Text + "',preco ='" + tpreco.Text + "' WHERE codprod = '" + tcod1.Text + "'", conn);

                if
                    (MessageBox.Show("DESEJA ATUALIZAR?", "INFORMAÇÃO", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    MessageBox.Show("ATUALIZADO COM SUCESSO", "ATUALIZAR", MessageBoxButton.OK, MessageBoxImage.Information);

                    conn.Open();
                    Update.ExecuteNonQuery();
                    conn.Close();
                    limparCampos();
                }
                carregar();

            }
            catch
            {
                MessageBox.Show("NÃO FOI POSSIVEL ATUALIZAR");
                limparCampos();
            }
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
            DtgridProduto.DataContext = dataSet;
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";

                MySqlCommand Deletar = new MySqlCommand("DELETE FROM CadastrarProduto WHERE codprod='" + tcod1.Text + "'", conn);

                if
                    (MessageBox.Show("DESEJA EXCLUIR?", "INFORMAÇÃO", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    MessageBox.Show("EXCLUIDO COM SUCESSO", "EXCLUIR", MessageBoxButton.OK, MessageBoxImage.Warning);
                    conn.Open();
                    Deletar.ExecuteNonQuery();
                    conn.Close();
                    limparCampos();
                }

                carregar();
            }
            catch
            {
                MessageBox.Show("NÃO FOI POSSIVEL EXCLUIR");
            }
        }

        public void limparCampos()
        {
            tcod1.Clear();
            tcodper.Clear();
            tproduto.Clear();
            tcategoria.Text = "Selecione";
            tpreco.Clear();

        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            tcategoria.Items.Add("PIZZA");
            tcategoria.Items.Add("LANCHE");
            tcategoria.Items.Add("PORÇÃO");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tcategoria.Text = "Selecione";
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }

        private void btpesquisa_Click(object sender, RoutedEventArgs e)
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
                DtgridProduto.DataContext = dataSet;
            }
            catch
            {
                MessageBox.Show("ERROR!!!!");
            }
        }
    }
}