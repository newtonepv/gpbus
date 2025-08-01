using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using System.Configuration;

namespace GPbuS
{
    public partial class FormInicial : Form
    {

        // Importar a função necessária da biblioteca do Windows para permitir o movimento
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormInicial()
        {
            InitializeComponent();
            if (DAO_Conexao.getConexao("143.106.241.3", "cl201273", "cl201273", "MarcosLeonardo18"))
                Console.WriteLine("Conectado");
            else
                Console.WriteLine("Erro de Conexão");
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LembrarMe)
            {
                txtEmail.Text = Properties.Settings.Default.EmailLembrado;
                txtSenha.Text = Properties.Settings.Default.SenhaLembrada;
                chkLembrarMe.Checked = true;
            }
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool lembrar = chkLembrarMe.Checked;
            
                // Tenta fazer login usando o nome de usuário e a senha informados
                bool loginSucesso = DAO_Conexao.loginAdministrador(txtEmail.Text, txtSenha.Text);

                // Se o login for bem-sucedido, exibe uma mensagem de boas-vindas e abre a próxima tela
                if (loginSucesso)
                {
                string email = txtEmail.Text;
                string senha = txtSenha.Text;
                if (lembrar)
                {
                    Properties.Settings.Default.EmailLembrado = email;
                    Properties.Settings.Default.SenhaLembrada = senha;
                }
                else
                {
                    Properties.Settings.Default.EmailLembrado = string.Empty;
                    Properties.Settings.Default.SenhaLembrada = string.Empty;
                }

                Properties.Settings.Default.LembrarMe = lembrar;
                Properties.Settings.Default.Save();
                MessageBox.Show("Seja bem-vindo!");
                    ADM adm = new ADM();
                    // Recupera o nome de usuário e a senha informados nos campos de entrada
                    
                    MySqlDataReader r = adm.retornaUserName(email, senha);
                    while (r.Read())
                    {
                        string username = r["NomeUsuarioADM"].ToString();
                        Console.WriteLine("Nome de usuário: " + username);
                        FormPrincipal PrincipalForm = new FormPrincipal(username);
                        PrincipalForm.Show();
                        this.Hide();
                    }
                    DAO_Conexao.con.Close();
                    
                }
                // Caso contrário, exibe uma mensagem de erro
                else
                {
                    MessageBox.Show("Email ou senha inválidos. Por favor, tente novamente.");
                }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Digite seu email")
            {
                txtEmail.Text = "";
                
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Digite seu email";
                
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Digite sua senha")
            {
                txtSenha.Text = "";
                
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                txtSenha.Text = "Digite sua senha";
                
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       
        }

        private void gunaGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientPanel1_Click_1(object sender, EventArgs e)
        {

        }

        private void gunaLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormCadADM PassageiroCadForm = new FormCadADM();
            PassageiroCadForm.Show();
            this.Hide();
        }

        private void gunaGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Iniciar o movimento do formulário quando o botão esquerdo do mouse é pressionado
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void gunaLinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRecSenha recSenha = new FormRecSenha();
            recSenha.Show();
            this.Close();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

