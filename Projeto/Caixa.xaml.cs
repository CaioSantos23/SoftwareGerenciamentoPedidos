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
    /// Lógica interna para Caixa.xaml
    /// </summary>
    public partial class Caixa : Window
    {
        

        public Caixa()
        {
            InitializeComponent();
        }


        private void btAdEntrada_Click(object sender, RoutedEventArgs e)
        {
            ControleCaixa controle = new ControleCaixa();
            controle.Show();
            Close();
        }
  

        private void dataGridCaixa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row = dg.SelectedItem as DataRowView;

            if (row != null)
            {
                tvalor.Text = row["valor"].ToString();
                tdata.Text = row["dat"].ToString();
             
            }
        }
        private void dataGridCaixa_Initialized(object sender, EventArgs e)
        {
            carregar();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btFeCaixa_Click(object sender, RoutedEventArgs e)
        {
            if
                (MessageBox.Show("DESEJA FECHAR CAIXA?", "INFORMAÇÃO", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

            {
                MessageBox.Show("CAIXA FECHADO", "INFORMAÇÃO", MessageBoxButton.OK, MessageBoxImage.Information);
                Menu menu = new Menu();
                menu.Show();
                Close();

            }
        
        }
    
        public void carregar()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";
            MySqlCommand dcm = new MySqlCommand();
            dcm.Connection = conn;

            MySqlCommand SELECT = new MySqlCommand("SELECT * FROM CadastrarCaixa", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(SELECT);
            DataSet dataSet = new DataSet();
            adp.Fill(dataSet, "Load");
            dataGridCaixa.DataContext = dataSet;
        }
        public void limparCampos()
        {
            tvalor.Text = "";
            tdata.Text = "";
        }

        private void btReEntrada_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc;PASSWORD=;";

                MySqlCommand Deletar = new MySqlCommand("DELETE FROM CadastrarCaixa WHERE valor='" + tvalor.Text + "'", conn);

                if
                    (MessageBox.Show("DESEJA REMOVER ENTRADA?", "INFORMAÇÃO", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

                {
                    MessageBox.Show("REMOVIDO COM SUCESSO", "EXCLUIR", MessageBoxButton.OK, MessageBoxImage.Warning);
                  
                    conn.Open();
                    Deletar.ExecuteNonQuery();
                    conn.Close();
                    limparCampos();
                    
                }
      
                carregar();

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc; PASSWORD=;";
                MySqlCommand dcm = new MySqlCommand("SELECT SUM(valor) as total FROM CadastrarCaixa", con);
                con.Open();
                MySqlDataReader dr = dcm.ExecuteReader();

                while (dr.Read())
                {
                    ttotal.Text = dr["total"].ToString();

                }
                con.Close();

            }
            catch
            {
                MessageBox.Show("NÃO FOI POSSIVEL EXCLUIR");
            }
        }
 

        private void Ttotal_Initialized(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "SERVER=localhost; PORT=3306; USER ID=root; DATABASE=tcc; PASSWORD=;";
            MySqlCommand dcm = new MySqlCommand("SELECT SUM(valor) as total FROM CadastrarCaixa", conn);
            conn.Open();
            MySqlDataReader dr = dcm.ExecuteReader();
            
            while (dr.Read())
            {
                ttotal.Text = dr["total"].ToString();
              
            }
            conn.Close();
        }
      
    } }

