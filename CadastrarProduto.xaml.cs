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
    /// Lógica interna para CadastrarProduto.xaml
    /// </summary>
    public partial class CadastrarProduto : Window
    {
        public CadastrarProduto()
        {
            InitializeComponent();
        }

        private void Inserir_Click_1(object sender, RoutedEventArgs e)
        {
            if (tcodper.Text != "" & tproduto.Text != "" & tcategoria.Text != "" & tpreco.Text != "")
            {
                if (MessageBox.Show("CADASTRAR PRODUTO?", "INFORMAÇÃO", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    try
                    {
                        MySqlConnection conn = new MySqlConnection();
                        conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";
                        MySqlCommand dcm = new MySqlCommand();
                        dcm.Connection = conn;



                        dcm.CommandText = "INSERT INTO CadastrarProduto(codper,produto,categoria,preco) values" +
                            "(@codper,@produto,@categoria,@preco)";


                        dcm.Parameters.AddWithValue("@codper", tcodper.Text);
                        dcm.Parameters.AddWithValue("@produto", tproduto.Text);
                        dcm.Parameters.AddWithValue("@categoria", tcategoria.Text);
                        dcm.Parameters.AddWithValue("@preco", tpreco.Text);

                        conn.Open();
                        dcm.ExecuteNonQuery();
                        conn.Close();






                        MessageBox.Show("CLIENTE CADASTRADO COM SUCESSO", "CADASTRO", MessageBoxButton.OK, MessageBoxImage.Information);




                    }

                    catch
                    {
                        MessageBox.Show("ERRO NO CADASTRO", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    limparCampos();
                 
                }
            }
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            ConsultaProduto cons = new ConsultaProduto();
            cons.Show();
            Close();
        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            tcategoria.Items.Add("PIZZA");
            tcategoria.Items.Add("LANCHE");
            tcategoria.Items.Add("PORÇÃO");


        }
        private void excluir_Click_5(object sender, RoutedEventArgs e)
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

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tcategoria.Text = "Selecione";
        }
        public void limparCampos()
        {
            tcod1.Clear();
            tcodper.Clear();
            tproduto.Clear();
            tcategoria.Text = "Selecione";
            tpreco.Clear();

        }
    }
}
