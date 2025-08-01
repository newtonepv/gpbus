using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPbuS
{
    public partial class FormCadADM2 : Form
    {
        private ADM adm;

        public FormCadADM2(ADM adm)
        {
            InitializeComponent();
            this.adm = adm;
        }

        private void FormCadastro2_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            
            this.adm.NomeUsuario1 = txtNomeUsuario.Text;
            this.adm.Senha1 = txtSenha.Text;
            if (this.adm.cadastrarAdministrador())
            {
                MessageBox.Show("Cadastro realizado com sucesso");
                FormInicial InicialForm = new FormInicial();
                InicialForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Erro no cadastro");
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadADM ADMCadForm = new FormCadADM();
            ADMCadForm.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            FormCadADM ADMCadForm = new FormCadADM();
            ADMCadForm.Show();
            this.Hide();
        }

        private void btnProximo_Click_1(object sender, EventArgs e)
        {
            this.adm.NomeUsuario1 = txtNomeUsuario.Text;
            this.adm.Senha1 = txtSenha.Text;
            if (this.adm.cadastrarAdministrador())
            {
                MessageBox.Show("Cadastro realizado com sucesso");
                FormInicial InicialForm = new FormInicial();
                InicialForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Erro no cadastro");
        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
