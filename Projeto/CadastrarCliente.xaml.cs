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
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class CadastrarCliente : Window
    {
        public CadastrarCliente()
        {
            InitializeComponent();
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            ConsultaCliente consulcli = new ConsultaCliente();
            consulcli.Show();
            Close();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }
        public void limparCampos()
        {
            tcod.Clear();
            tnome.Clear();
            tend.Clear();
            tbairro.Clear();
            tnum.Clear();
            tcomp.Clear();
            ttel.Clear();
        }
 
        private void BtCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (tnome.Text != "" & tend.Text != "" & tbairro.Text != "" & tnum.Text != "" & ttel.Text != "")
            {
                if (MessageBox.Show("CADASTRAR CLIENTE?", "INFORMAÇÃO", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    try
                    {
                        MySqlConnection conn = new MySqlConnection();
                        conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";
                        MySqlCommand dcm = new MySqlCommand();
                        dcm.Connection = conn;



                        dcm.CommandText = "INSERT INTO CadastrarCliente(nome,end,bairro,num,complemento,tel) values" +
                            "(@nome,@end,@bairro,@num,@complemento,@tel)";


                        dcm.Parameters.AddWithValue("@nome", tnome.Text);
                        dcm.Parameters.AddWithValue("@end", tend.Text);
                        dcm.Parameters.AddWithValue("@bairro", tbairro.Text);
                        dcm.Parameters.AddWithValue("@num", tnum.Text);
                        dcm.Parameters.AddWithValue("@complemento", tcomp.Text);
                        dcm.Parameters.AddWithValue("@tel", ttel.Text);

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
    }
}
