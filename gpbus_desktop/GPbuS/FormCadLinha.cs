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

namespace GPbuS
{
    public partial class FormCadLinha : Form
    {

        // Importar a função necessária da biblioteca do Windows para permitir o movimento
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormCadLinha()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FormCadLinha_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ModoEscuro)
            {
                ModoEscuro();
            }
            else
            {
                ModoClaro();
            }
        }

        public void ModoEscuro()
        {

        }

        public void ModoClaro()
        {
            gunaGradient2Panel1.GradientColor1 = Color.FromArgb(96, 97, 192);
            gunaGradient2Panel1.GradientColor2 = Color.FromArgb(128, 128, 255);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Linha linha = new Linha(txtNumero.Text, txtNome.Text, txtEmpresa.Text, txtSentido1.Text, txtSentido2.Text, txtTipo.Text, txtHrSaidaS1.Text, txtHrSaidaS2.Text);
            if (linha.cadastrarLinha())
            {
                string vazio = "";
                MessageBox.Show("Cadastro realizado com sucesso");
                FormPrincipal PrincipalForm = new FormPrincipal(vazio);
                PrincipalForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Erro no cadastro");
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string vazio = "";
            FormPrincipal PrincipalForm = new FormPrincipal(vazio);
            PrincipalForm.Show();
            this.Hide();
        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
