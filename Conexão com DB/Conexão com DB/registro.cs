using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Conexão_com_DB
{
    public partial class registro : Form
    {
        public registro()
        {
            InitializeComponent();
        }

        private void btn_regist_Click(object sender, EventArgs e)
        {
        
           
            MySqlConnection conexao = new MySqlConnection(Conn.Valor);
            try
            {

                conexao.Open();

                MySqlCommand INSERT = new MySqlCommand("use "+Conn.Database+"; INSERT INTO  "+Conn.Table+" (Usuario, Senha) VALUES ('"+txt_user.Text+"','"+txt_pass.Text+"');", conexao);

                INSERT.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Usuario e senha Inseridos com sucesso!");
            }

            catch (MySqlException ex)
            {


                MessageBox.Show(ex.Message);

            }

        }

        private void registro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Conn.Database);
        }
    }
}
