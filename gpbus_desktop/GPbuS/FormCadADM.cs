using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPbuS
{
    public partial class FormCadADM : Form
    {
        private ADM adm;

        // Importar a função necessária da biblioteca do Windows para permitir o movimento
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        public FormCadADM()
        {
            InitializeComponent();
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInicial InicialForm = new FormInicial();
            InicialForm.Show();
            this.Hide();
        }

        

        // Crie o evento SelectedIndexChanged para o ComboBox de estados
        private void comboBoxEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxCidade.Enabled = true;
            // Remova todas as cidades do ComboBox de cidades
            cbxCidade.Items.Clear();

            // Adicione apenas as cidades correspondentes ao estado selecionado
            if (cbxEstado.SelectedItem.ToString() == "São Paulo")
            {
                cbxCidade.Text = "";
                cbxCidade.Items.AddRange(new string[] { "São Paulo", "Campinas", "Santo André" });
            }
            else if (cbxEstado.SelectedItem.ToString() == "Rio de Janeiro")
            {
                cbxCidade.Text = "";
                cbxCidade.Items.AddRange(new string[] { "Rio de Janeiro", "Niterói", "Volta Redonda" });
            }
            else if (cbxEstado.SelectedItem.ToString() == "Minas Gerais")
            {
                cbxCidade.Text = "";
                cbxCidade.Items.AddRange(new string[] { "Belo Horizonte", "Uberlândia", "Juiz de Fora" });
            }
        }

        private void FormCadADM_Load(object sender, EventArgs e)
        {
            // Adicione os estados ao ComboBox de estados
            cbxEstado.Items.AddRange(new string[] { "São Paulo", "Rio de Janeiro", "Minas Gerais" });
            cbxCidade.Enabled = false;
            btnProximo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            Image imagem = picFotoPerfil.Image;
            byte[] imagemBytes = null;
            if (imagem != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Use o formato apropriado (Jpeg, Png, etc.)
                    imagemBytes = ms.ToArray();
                }
            }
            adm = new ADM(txtNome.Text, txtDataNasc.Text, txtEmail.Text, "", "", txtCelular.Text, txtCPF.Text, imagemBytes, cbxCidade.Text, cbxEstado.Text, txtEndereco.Text, txtCEP.Text);
            /*if (adm.cadastrarAdministrador())
            {
                MessageBox.Show("Cadastro realizado com sucesso");
                
            }
            else
                MessageBox.Show("Erro no cadastro");*/
            FormCadADM2 cadastro2Form = new FormCadADM2(adm);
            cadastro2Form.Show();
            this.Hide();
        }

       
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtDataNasc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif";

            // Exibe o diálogo de seleção de arquivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtém o caminho do arquivo selecionado
                string caminhoDaImagem = openFileDialog.FileName;

                // Carrega a imagem na PictureBox
                picFotoPerfil.Image = Image.FromFile(caminhoDaImagem);
                picFotoPerfil.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Iniciar o movimento do formulário quando o botão esquerdo do mouse é pressionado
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }
    }
}
