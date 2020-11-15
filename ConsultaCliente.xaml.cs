using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;


namespace TCC
{
    /// <summary>
    /// Lógica interna para ConsultaCliente.xaml
    /// </summary>
    public partial class ConsultaCliente : Window
    {
        public ConsultaCliente()
        {
            InitializeComponent();
        }
        public void carregar()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";
            MySqlCommand dcm = new MySqlCommand();
            dcm.Connection = conn;

            MySqlCommand SELECT = new MySqlCommand("SELECT * FROM CadastrarCliente", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(SELECT);
            DataSet dataSet = new DataSet();
            adp.Fill(dataSet, "Load");
            Dtgridcliente.DataContext = dataSet;
        }

        private void atualizar_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";

                MySqlCommand Update = new MySqlCommand("UPDATE CadastrarCliente SET nome ='" + tnome.Text + "',end = '" + tend.Text + "',bairro = '" + tbairro.Text + "',num ='" + tnum.Text + "',complemento ='" + tcomp.Text + "' ,tel ='" + ttel.Text + "' WHERE codcli = '" + tcod1.Text + "'", conn);

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

        private void excluir_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";

                MySqlCommand Deletar = new MySqlCommand("DELETE FROM CadastrarCliente WHERE codcli='" + tcod1.Text + "'", conn);

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

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tdata.Content = DateTime.Now.ToString("dd/MM/yyyy");
            thora.Content = DateTime.Now.ToString("HH:mm");

        }
        public void limparCampos()
        {
            tcod1.Clear();
            tnome.Clear();
            tend.Clear();
            tbairro.Clear();
            tnum.Clear();
            tcomp.Clear();
            ttel.Clear();
        }
        private void Dtgridcliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row = dg.SelectedItem as DataRowView;

            if (row != null)
            {
                tcod1.Text = row["codcli"].ToString();
                tnome.Text = row["nome"].ToString();
                tend.Text = row["end"].ToString();
                tbairro.Text = row["bairro"].ToString();
                tnum.Text = row["num"].ToString();
                tcomp.Text = row["complemento"].ToString();
                ttel.Text = row["tel"].ToString();

            }
        }
        private void Dtgridcliente_Initialized_1(object sender, EventArgs e)
        {
            carregar();
        }
        private void Dtgridcliente_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Inserir_Click_1(object sender, RoutedEventArgs e)
        {
            CadastrarCliente cadcli = new CadastrarCliente();
            cadcli.Show();
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

                MySqlCommand SELECT = new MySqlCommand("SELECT codcli,nome,end,bairro,num,complemento,tel  FROM CadastrarCliente WHERE nome LIKE '%" + tnomeproduto.Text + "%'", conn);
                SELECT.Parameters.AddWithValue("@nome", tnomeproduto.Text);

                MySqlDataAdapter adp = new MySqlDataAdapter(SELECT);
                DataSet dataSet = new DataSet();
                adp.Fill(dataSet, "Load");
                Dtgridcliente.DataContext = dataSet;
            }
            catch
            {
                MessageBox.Show("ERROR!!!!");
            }
        }
    }
}
