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
    public partial class FormPrincipal : Form
    {
        
        private string username;

        // Importar a função necessária da biblioteca do Windows para permitir o movimento
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        public FormPrincipal(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            if(username == "")
            {
                lblBoasVindas1.Visible = false;
            }
            else
            {
                lblBoasVindas1.Text = "Welcome, " + username + "!";
                lblBoasVindas1.ForeColor = Color.White;
                //lblBoasVindas1.BackColor = Color.FromArgb(212, 2, 2);
                lblBoasVindas1.Font = new Font("Yu Gothic", 10, FontStyle.Bold);
            }

            if (Properties.Settings.Default.ModoEscuro)
            {
                ModoEscuro();
            }
            else
            {
                ModoClaro();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void motoristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadMotorista MotoristaCadForm = new FormCadMotorista();
            MotoristaCadForm.Show();
            this.Hide();
        }

        private void linhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadLinha LinhaCadForm = new FormCadLinha();
            LinhaCadForm.Show();
            this.Hide();
        }

        private void motoristaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormConsultaMotorista MotoristaConsultaForm = new FormConsultaMotorista();
            MotoristaConsultaForm.Show();
            this.Hide();
        }

        private void linhaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormConsultaLinha LinhaConsultaForm = new FormConsultaLinha();
            LinhaConsultaForm.Show();
            this.Hide();
        }

        private void gunaGradient2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            FormCadMotorista MotoristaCadForm = new FormCadMotorista();
            MotoristaCadForm.Show();
            //this.Hide();
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            FormCadLinha LinhaCadForm = new FormCadLinha();
            LinhaCadForm.Show();
            //this.Hide();
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            FormConsultaMotorista MotoristaConsultaForm = new FormConsultaMotorista();
            MotoristaConsultaForm.Show();
            //this.Hide();
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            FormConsultaLinha LinhaConsultaForm = new FormConsultaLinha();
            LinhaConsultaForm.Show();
            //this.Hide();
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

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            FormAnalytics AnalyticsForm = new FormAnalytics();
            AnalyticsForm.Show();
        }

        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            FormConfig ConfigForm = new FormConfig();
            ConfigForm.Show();
            this.Hide();
        }

        public void ModoClaro()
        {
            gunaGradient2Panel1.GradientColor1 = Color.FromArgb(128, 128, 255);
            gunaGradient2Panel1.GradientColor2 = Color.FromArgb(128, 128, 255);
            gunaGradient2Panel2.GradientColor1 = Color.FromArgb(192, 192, 255);
            gunaGradient2Panel2.GradientColor1 = Color.FromArgb(128, 128, 255);
            gunaGradient2Panel3.GradientColor1 = Color.FromArgb(96, 97, 192);
            gunaGradient2Panel3.GradientColor2 = Color.FromArgb(96, 97, 192);
            txtPesquisar.BaseColor = Color.WhiteSmoke;
            txtPesquisar.ForeColor = Color.Black;
            gunaButton1.BaseColor = Color.WhiteSmoke;
            gunaButton1.OnHoverBaseColor = Color.LightGray;
        }

        public void ModoEscuro()
        {
            gunaGradient2Panel1.GradientColor1 = Color.FromArgb(46, 51, 73);
            gunaGradient2Panel1.GradientColor2 = Color.FromArgb(46, 51, 73);
            gunaGradient2Panel2.GradientColor1 = Color.FromArgb(24, 30, 54);
            gunaGradient2Panel2.GradientColor1 = Color.FromArgb(24, 30, 54);
            gunaGradient2Panel3.GradientColor1 = Color.FromArgb(24, 30, 54);
            gunaGradient2Panel3.GradientColor1 = Color.FromArgb(24, 30, 54);
            txtPesquisar.BaseColor = Color.FromArgb(74, 79, 99);
            txtPesquisar.ForeColor = Color.White;
            gunaButton1.BaseColor = Color.FromArgb(74, 79, 99);
            gunaButton1.OnHoverBaseColor = Color.Gray;
        }

        private void txtPesquisar_Enter(object sender, EventArgs e)
        {
            if (txtPesquisar.Text == "Pesquisar...")
            {
                txtPesquisar.Text = "";

            }
        }

        private void txtPesquisar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPesquisar.Text))
            {
                txtPesquisar.Text = "Pesquisar...";

            }
        }
    }
}
