using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GPbuS
{
    public partial class FormRecSenha : Form
    {


        public FormRecSenha()
        {
            InitializeComponent();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            bool emailSucesso = DAO_Conexao.verificaEmail(txtEmail.Text);

            if (emailSucesso)
            {
                lblStatus.Text = "Email encontrado!";
                lblStatus.ForeColor = Color.Green;
                // Recupera o nome de usuário e a senha informados nos campos de entrada
                txtSenha.Enabled = true;
                lblsenha.Enabled = true;
                btnConcluir.Enabled = true;
                DAO_Conexao.con.Close();

            }
            // Caso contrário, exibe uma mensagem de erro
            else
            {
                lblStatus.Text = "Email Não Encontrado!";
                lblStatus.ForeColor= Color.Red;
            }
        }

        private void btnAtualizarSenha_Click(object sender, EventArgs e)
        {
            string novoEmail = txtEmail.Text;
            string novaSenha = txtSenha.Text;

            ADM administrador = new ADM();
            if (administrador.AtualizarSenha(novoEmail, novaSenha))
            {
                MessageBox.Show("Senha atualizada com sucesso");
                FormInicial InicialForm = new FormInicial();
                InicialForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Erro na atualização");
            }
        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            FormInicial InicialForm = new FormInicial();
            InicialForm.Show();
            this.Hide();
        }
    }
    }
