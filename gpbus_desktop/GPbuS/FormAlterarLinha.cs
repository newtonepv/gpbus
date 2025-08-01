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
    public partial class FormAlterarLinha : Form
    {
        // Importar a função necessária da biblioteca do Windows para permitir o movimento
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormAlterarLinha(string nome, string numero, string empresa, string tipo, string sentido1, string sentido2, string hrsaida1, string hrsaida2)
        {
            InitializeComponent();
            txtNome.Text = nome;
            txtNumero.Text = numero;
            txtEmpresa.Text = empresa;
            txtTipo.Text = tipo;
            txtSentido1.Text = sentido1;
            txtSentido2.Text = sentido2;
            txtHrSaidaS1.Text = hrsaida1;
            txtHrSaidaS2.Text = hrsaida2;
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Linha linha = new Linha(txtNumero.Text, txtNome.Text, txtEmpresa.Text, txtSentido1.Text, txtSentido2.Text, txtTipo.Text, txtHrSaidaS1.Text, txtHrSaidaS2.Text);
            if (linha.atualizarLinha())
            {
                MessageBox.Show("Atualizado com sucesso!");
                this.Close();
            }
            else
                MessageBox.Show("Erro na Atualização");
        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Iniciar o movimento do formulário quando o botão esquerdo do mouse é pressionado
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void FormAlterarLinha_Load(object sender, EventArgs e)
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
    }
}
