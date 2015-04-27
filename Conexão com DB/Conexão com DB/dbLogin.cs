using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace Conexão_com_DB
{
   

    public partial class dbLogin : Form

  

    {
       

        public dbLogin()
        {
            InitializeComponent();
        }

        private void Conectar_Click(object sender, EventArgs e)
        {
            try
            {

                Conn.Valor = "Server=" + txt_host.Text + ";user=" + txt_user.Text + ";password=" + txt_pass.Text + ";";

                try
                {
                    
                    string dbConn = Conn.Valor;
                    MySqlConnection conexao = new MySqlConnection(dbConn);
                    
                    conexao.Open();


                    SpeechSynthesizer sucesso = new SpeechSynthesizer();
                    MessageBox.Show("Conectado!",Conn.Valor);
                    

                    this.Hide();
                   

                    if (conexao.State == ConnectionState.Open)
                    {


                       Conexaodb principal = new Conexaodb();

                        principal.Show();



                    }

                   
                }


              catch (MySqlException ex)
              {

                  MessageBox.Show(ex.Message);


                 

              } 


               

              

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            finally
            {
                
              


            }

        }
    }
}


