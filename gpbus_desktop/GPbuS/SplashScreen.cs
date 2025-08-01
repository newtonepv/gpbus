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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            // Configurações do timer
            timer1.Interval = 20; // Tempo de atualização em milissegundos
            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gunaProgressBar1.Value += 1; // Incrementa o valor da ProgressBar em 1
            lblStatus.Text = $"Loading... ({gunaProgressBar1.Value}%)"; // Atualiza o texto do Label com o valor da ProgressBar

            // Quando a ProgressBar atingir 100, para o Timer e fecha a SplashScreen
            if (gunaProgressBar1.Value == 100)
            {
                timer1.Stop(); // Para o Timer
                FormInicial mainForm = new FormInicial(); // Cria o formulário principal
                mainForm.Show(); // Exibe o formulário principal
                this.Hide(); // Esconde a SplashScreen
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
