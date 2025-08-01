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
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void gunaWinSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaWinSwitch1.Checked == false) {

                gunaTransfarantPictureBox2.Visible = false;
                gunaTransfarantPictureBox1.Visible = true;
                gunaGradient2Panel1.GradientColor1 = Color.FromArgb(46, 51, 73);
                gunaGradient2Panel1.GradientColor2 = Color.FromArgb(24, 30, 54);
                gunaWinSwitch1.FillColor = Color.Gray;
                gunaLabel1.ForeColor = Color.Red;
                gunaLabel2.ForeColor = Color.Red;
                Properties.Settings.Default.ModoEscuro = true;

            } else if (gunaWinSwitch1.Checked == true)
            {
                //gunaWinSwitch1.Checked = true;
                gunaTransfarantPictureBox2.Visible = true;
                gunaTransfarantPictureBox1.Visible = false;
                gunaGradient2Panel1.GradientColor1 = Color.FromArgb(192, 192, 255);
                gunaGradient2Panel1.GradientColor2 = Color.FromArgb(24, 30, 54);
                gunaWinSwitch1.FillColor = Color.WhiteSmoke;
                gunaLabel1.ForeColor = Color.FromArgb(192, 0, 0);
                gunaLabel2.ForeColor = Color.FromArgb(192, 0, 0);
                Properties.Settings.Default.ModoEscuro = false;
            }
            else
            {

            }
            Properties.Settings.Default.Save();
        }

        public void ModoEscuro()
        {
            gunaWinSwitch1.Checked = false;
            gunaTransfarantPictureBox2.Visible = false;
            gunaTransfarantPictureBox1.Visible = true;
            gunaGradient2Panel1.GradientColor1 = Color.FromArgb(46, 51, 73);
            gunaGradient2Panel1.GradientColor2 = Color.FromArgb(24, 30, 54);
            gunaWinSwitch1.FillColor = Color.Gray;
        }

        public void ModoClaro()
        {
            gunaWinSwitch1.Checked = true;
            gunaTransfarantPictureBox2.Visible = true;
            gunaTransfarantPictureBox1.Visible = false;
            gunaGradient2Panel1.GradientColor1 = Color.FromArgb(192, 192, 255);
            gunaGradient2Panel1.GradientColor2 = Color.FromArgb(24, 30, 54);
            gunaWinSwitch1.FillColor = Color.WhiteSmoke;
            gunaLabel1.ForeColor = Color.FromArgb(192, 0, 0);
            gunaLabel2.ForeColor = Color.FromArgb(192, 0, 0);
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            FormPrincipal PrincipalForm = new FormPrincipal("");
            PrincipalForm.Show();
            this.Hide();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            gunaTransfarantPictureBox2.Visible = false;
            if (Properties.Settings.Default.ModoEscuro)
            {
                ModoEscuro();
            }
            else
            {
                ModoClaro();
            }
        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            gunaLabel10.Text = "Configurações";
            gunaLabel1.Text = "Tema";
            gunaLabel2.Text = "Idioma";
            btnLogin.Text = "Português";
            gunaAdvenceButton1.Text = "Inglês";
            btnCancelar.Text = "Sair";
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            gunaLabel10.Text = "Settings";
            gunaLabel1.Text = "Theme";
            gunaLabel2.Text = "Language";
            btnLogin.Text = "Portuguese";
            gunaAdvenceButton1.Text = "English";
            btnCancelar.Text = "Leave";
        }
    }
}
