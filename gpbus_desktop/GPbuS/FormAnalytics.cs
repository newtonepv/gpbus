using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPbuS
{
    
    public partial class FormAnalytics : Form
    {
        // Importar a função necessária da biblioteca do Windows para permitir o movimento
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormAnalytics()
        {
            InitializeComponent();
        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void FormAnalytics_Load(object sender, EventArgs e)
        {
            ExcelToDatabaseUpdater excelUpdater = new ExcelToDatabaseUpdater();
            excelUpdater.UpdateDatabase("C:\\Users\\luans\\OneDrive\\Área de Trabalho\\Analytics_GPbuS.xlsx");
            excelUpdater.UpdateChart("C:\\Users\\luans\\OneDrive\\Área de Trabalho\\Analytics_GPbuS.xlsx");
            Dictionary<string, object> valoresDoBanco = excelUpdater.PreencherLabels();
            List<double> earnings = excelUpdater.GetEarningsFromDatabase();

            if (earnings.Count >= 31) // Verifica se existem pelo menos 31 valores na lista de earnings
            {
                double earning1 = earnings[0];
                double earning2 = earnings[1];
                double earning3 = earnings[2];
                double earning4 = earnings[3];
                double earning5 = earnings[4];
                double earning6 = earnings[5];
                double earning7 = earnings[6];
                double earning8 = earnings[7];
                double earning9 = earnings[8];
                double earning10 = earnings[9];
                double earning11 = earnings[10];
                double earning12 = earnings[11];
                double earning13 = earnings[12];
                double earning14 = earnings[13];
                double earning15 = earnings[14];
                double earning16 = earnings[15];
                double earning17 = earnings[16];
                double earning18 = earnings[17];
                double earning19 = earnings[18];
                double earning20 = earnings[19];
                double earning21 = earnings[20];
                double earning22 = earnings[21];
                double earning23 = earnings[22];
                double earning24 = earnings[23];
                double earning25 = earnings[24];
                double earning26 = earnings[25];
                double earning27 = earnings[26];
                double earning28 = earnings[27];
                double earning29 = earnings[28];
                double earning30 = earnings[29];
                double earning31 = earnings[30];

                chart1.Series["Billing"].Points.Clear(); 

                for (int i = 0; i < 31; i++)
                {
                    chart1.Series["Billing"].Points.AddXY("Earning" + (i + 1), earnings[i]);
                }
                
                chart1.Update();
            }

            if (valoresDoBanco != null)
            {
                // Acessando os valores do dicionário
                string earings = valoresDoBanco["Earings"].ToString();
                string downloads = valoresDoBanco["Downloads"].ToString();
                string costumers = valoresDoBanco["Costumers"].ToString();
                string managers = valoresDoBanco["Managers"].ToString();
                string drivers = valoresDoBanco["Drivers"].ToString();
                string bosses = valoresDoBanco["Bosses"].ToString();
                string monthlyGoal = valoresDoBanco["MonthlyGoal"].ToString();

                decimal valorNumerico = decimal.Parse(earings); // Converter para decimal

                string valorFormatado = valorNumerico.ToString("C2"); // Formatar como valor monetário (com 2 casas decimais)
                lblEarings.Text = valorFormatado;

                // Agora você pode usar esses valores como desejar
                // Por exemplo, atribuir a Labels ou outros controles
                lblEarings.Text = valorFormatado;
                lblDownloads.Text = downloads;
                lblCostumers.Text = costumers;
                lblManagers.Text = managers;
                lblDrivers.Text = drivers;
                lblBosses.Text = bosses;
                gunaCircleProgressBar1.Value = int.Parse(monthlyGoal);
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

        public void ModoEscuro()
        {

        }

        public void ModoClaro()
        {
            gunaGradient2Panel1.GradientColor1 = Color.FromArgb(96, 97, 192);
            gunaGradient2Panel1.GradientColor2 = Color.FromArgb(96, 97, 192);
            gunaPanel1.BackColor = Color.FromArgb(128, 128, 255);
            gunaPanel2.BackColor = Color.FromArgb(128, 128, 255);
            gunaPanel3.BackColor = Color.FromArgb(128, 128, 255);
            gunaPanel4.BackColor = Color.FromArgb(128, 128, 255);
            gunaPanel5.BackColor = Color.FromArgb(128, 128, 255);
            label1.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            label3.ForeColor = Color.Gainsboro;
            label4.ForeColor = Color.Gainsboro;
            label7.ForeColor = Color.Gainsboro;
            label12.ForeColor = Color.Gainsboro;
            label14.ForeColor = Color.Gainsboro;
            label16.ForeColor = Color.Gainsboro;
            lblEarings.ForeColor = Color.FromArgb(96, 97, 192);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
