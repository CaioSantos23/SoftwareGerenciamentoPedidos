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

        private void Tnome_TextChanged(object sender, TextChangedEventArgs e)
        {
       
        }

        private void Inserir_Click_1(object sender, RoutedEventArgs e)
        {
            CadastrarProduto cadpro = new CadastrarProduto();
            cadpro.Show();
            Close();


        }
        private void Tcpf1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tcod_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tcod1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tnomefantasia_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tendereco1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tbairro1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tuf1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Ttelefone1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tcel1_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void Temail1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Dtgridcliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void Tmunicipio1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Dtgridcliente_Initialized_1(object sender, EventArgs e)
        {
            carregar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void atualizar_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";

                MySqlCommand Update = new MySqlCommand("UPDATE CadastrarProduto SET codper ='" + tcodper.Text + "',produto = '" + tproduto.Text + "',categoria = '" + tcategoria.Text + "',preco ='" + tpreco.Text + "' WHERE codprod = '" + tcod1.Text + "'", conn);

                conn.Open();
                Update.ExecuteNonQuery();
                conn.Close();


                if
                    (MessageBox.Show("DESEJA ATUALIZAR?", "INFORMAÇÃO", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    MessageBox.Show("ATUALIZADO COM SUCESSO", "ATUALIZAR", MessageBoxButton.OK, MessageBoxImage.Information);
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
            Dtgridcliente.DataContext = dataSet;
        }

        private void excluir_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";

                MySqlCommand Deletar = new MySqlCommand("DELETE FROM CadastrarProduto WHERE codprod='" + tcod1.Text + "'", conn);

                conn.Open();
                Deletar.ExecuteNonQuery();
                conn.Close();


                if
                    (MessageBox.Show("DESEJA EXCLUIR?", "INFORMAÇÃO", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    MessageBox.Show("EXCLUIDO COM SUCESSO", "EXCLUIR", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void Voltar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }

        private void Trazaosocial_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Dtgridcliente_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            tcategoria.Items.Add("PIZZA");
            tcategoria.Items.Add("LANCHE");
            tcategoria.Items.Add("PORÇÃO");
       

        }

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tcategoria.Text = "Selecione";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tdata.Content = DateTime.Now.ToString("dd/MM/yyyy");
            thora.Content = DateTime.Now.ToString("HH:mm");

        }

        private void ttelefone1_Loaded(object sender, RoutedEventArgs e)
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