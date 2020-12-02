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
    /// Lógica interna para ControleCaixa.xaml
    /// </summary>
    public partial class ControleCaixa : Window
    {
        public ControleCaixa()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Caixa cax = new Caixa();
            cax.Show();
            Close();
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (tvalor.Text != "")
            {
                if (MessageBox.Show("ADICIONAR ENTRADA?", "INFORMAÇÃO", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    try
                    {
                        MySqlConnection conn = new MySqlConnection();
                        conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";
                        MySqlCommand dcm = new MySqlCommand();
                        dcm.Connection = conn;
                        dcm.CommandText = "INSERT INTO CadastrarCaixa(valor ,dat ,obs) values" +
                            "(@valor,@dat,@obs)";
                        dcm.Parameters.AddWithValue("@valor", tvalor.Text);
                        dcm.Parameters.AddWithValue("@dat", tdata.Text);
                        dcm.Parameters.AddWithValue("@obs", tobs.Text);
                        conn.Open();
                        dcm.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("ENTRADA CADASTRADA", "CADASTRO", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    catch
                    {
                        MessageBox.Show("ERRO NO CADASTRO", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    limparCampos();
                    Caixa cax = new Caixa();
                    cax.Show();
                    Close();
                }
            }
        }


        public void limparCampos()
        {
            tvalor.Clear();
            tdata.Clear();
            tobs.Clear();
        }

        private void Tdata_Initialized(object sender, EventArgs e)
        {
            tdata.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
    

