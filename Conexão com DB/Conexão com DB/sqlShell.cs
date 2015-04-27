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
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using System.Speech.Synthesis.TtsEngine;
using System.Speech.Recognition.SrgsGrammar;

namespace Conexão_com_DB
{
    public partial class sqlShell : Form
    {
        public sqlShell()
        {
            InitializeComponent();
        }

        private void executarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dbConn = Conn.Valor;
            MySqlConnection conexao = new MySqlConnection(dbConn);
            try
            {

                conexao.Open();

                MySqlCommand INSERT = new MySqlCommand(textBox1.Text, conexao);
                INSERT.ExecuteNonQuery();
                conexao.Close();
                SpeechSynthesizer sucesso = new SpeechSynthesizer();
                
                
                MessageBox.Show("Comandos enviados com sucesso! (Cheque o PHPMYADMIN)");
                sucesso.Speak("Comandos enviados com sucesso!");
              
                
            }
            catch(MySqlException ex)
            {

                MessageBox.Show(ex.Message);  

            }

            finally
            {

                conexao.Close();

            }
        }

      

        

    }
}
