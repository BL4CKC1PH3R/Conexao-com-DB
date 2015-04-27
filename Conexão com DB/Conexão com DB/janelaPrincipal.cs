using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Conexão_com_DB
{
    public partial class Conexaodb : Form
    {
       
       

        public Conexaodb()
        {
            InitializeComponent();
        }

       

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void criarTabelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlShell shellsql = new sqlShell();

            shellsql.Show();
            

           
            
            
        }

        private void Conexaodb_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection(Conn.Valor);
            MySqlCommand cmd = conexao.CreateCommand();
            cmd.CommandText = "show databases";
            try
            {
                conexao.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string row = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    row += reader.GetValue(i).ToString();
                    database.Items.Add(row);

                 
                }

                button1.Enabled = false;


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Number.ToString());
                MessageBox.Show(ex.Message);
            }

           
        }

    

        private void btn_tabela_Click(object sender, EventArgs e)
        {

            
            MySqlConnection conexao = new MySqlConnection(Conn.Valor);
            MySqlDataAdapter executar = new MySqlDataAdapter();
            var resultado = new DataSet();
            try
            {


                conexao.Open();
                // MySqlCommand cmd = new MySqlCommand(" SELECT * FROM "+comboBox1.SelectedItem+"."+comboBox2.SelectedItem+"; ", conexao);

                executar = new MySqlDataAdapter("Select * from " + database.SelectedItem + "." + table.SelectedItem + "; ", conexao);
                executar.Fill(resultado,table.SelectedItem.ToString()); 
                dataGridView1.DataSource = resultado;
                dataGridView1.DataMember = table.SelectedItem.ToString(); 

               /*
                * 
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dbdataset);
                */






            }

            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            table.Items.Clear();
            MySqlConnection conexao = new MySqlConnection(Conn.Valor);
            MySqlCommand cmd = conexao.CreateCommand();
            cmd.CommandText = "use "+database.SelectedItem+";show tables;";
            try
            {
                conexao.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string row = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                        row += reader.GetValue(i).ToString();
                    table.Items.Add(row);
                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Number.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int linha = dataGridView1.CurrentRow.Index;
            String id = dataGridView1[0, linha].Value.ToString(); 
            String usuario = dataGridView1[1, linha].Value.ToString(); 
            String senha = dataGridView1[2, linha].Value.ToString(); 
            String SQL = "use test; UPDATE user SET usuario = '"+usuario+"',senha = '"+senha+"' WHERE ID_User = "+id+";";
            MySqlConnection conexao = new MySqlConnection(Conn.Valor);
            try
            {

                conexao.Open();
                MySqlCommand executa = new MySqlCommand(SQL, conexao); 
                executa.ExecuteNonQuery();
                MessageBox.Show("Atualizado com sucesso!");
               

            }

            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //pega a linha selecionada na datagridview  
            int linha = dataGridView1.CurrentRow.Index;
            String selecionado = dataGridView1[0, linha].OwningColumn.Name.ToString();
            String ID = dataGridView1[0, linha].Value.ToString();
            String SQL = "use "+database.SelectedItem+"; delete from "+table.SelectedItem+" where "+selecionado+"= '" + ID +"';"; 
            MySqlConnection conexao = new MySqlConnection(Conn.Valor);
            try
            {
                conexao.Open();
                MySqlCommand executa = new MySqlCommand(SQL, conexao);
                //executa o SQL que apaga o registro   
                executa.ExecuteNonQuery();
               
                MessageBox.Show("Excluido com sucesso!");
                //remove a linha da datagridview   
                dataGridView1.Rows.RemoveAt(linha);
              

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }  


            }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                if (database.SelectedIndex == -1 || table.SelectedIndex == -1)
                {

                    MessageBox.Show("Você esqueceu de selecionar uma Database ou uma Table");

                }

                else
                {

                    registro registro = new registro();

                    registro.Show();


                    Conn.Database = database.SelectedItem.ToString();
                    Conn.Table = table.SelectedItem.ToString();


                }


            }

            catch
            {
                

                


            }






        }  


        }

    }

