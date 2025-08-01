using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPbuS
{
    public partial class FormCadMotorista : Form
    {
        // Importar a função necessária da biblioteca do Windows para permitir o movimento
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormCadMotorista()
        {
            InitializeComponent();
            Linha linha = new Linha();
            MySqlDataReader r = linha.consultarCodigoLinhas();
            while (r.Read())
            {
                cbxNumeroOnibus.Items.Add(r["NumeroLINHA"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string vazio = "";
            FormPrincipal PrincipalForm = new FormPrincipal(vazio);
            PrincipalForm.Show();
            this.Hide();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            Image imagem = picFotoPerfil.Image;
            byte[] imagemBytes = null;
            if (imagem != null)
            {
                if (ImageFormat.Jpeg.Equals(imagem.RawFormat) ||
        ImageFormat.Png.Equals(imagem.RawFormat) ||
        ImageFormat.Gif.Equals(imagem.RawFormat))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        imagem.Save(ms, imagem.RawFormat); // Use o formato apropriado (Jpeg, Png, etc.)
                        imagemBytes = ms.ToArray();
                    }
                } else
                {
                    MessageBox.Show("Formato de imagem não suportado. Por favor, selecione uma imagem JPEG, PNG ou GIF.");
                    return;
                }
            }
            Motorista motorista = new Motorista(txtNome.Text, txtData.Text, txtCNH.Text, txtEmail.Text, int.Parse(cbxNumeroOnibus.Text), imagemBytes, "", txtCelular.Text, cbxEstado.Text, cbxCidade.Text, txtEndereco.Text, txtCEP.Text);
            if (motorista.cadastrarMotorista())
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

        private void comboBoxEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxCidade.Enabled = true;
            // Remova todas as cidades do ComboBox de cidades
            //cbxCidade.Items.Clear();

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

        private void FormCadMotorista_Load(object sender, EventArgs e)
        {
            // Para não deixar o usuário digitar na combobox
            cbxCidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxNumeroOnibus.DropDownStyle = ComboBoxStyle.DropDownList;
            // Adicione os estados ao ComboBox de estados
            cbxEstado.Items.AddRange(new string[] { "São Paulo", "Rio de Janeiro", "Minas Gerais" });
            cbxCidade.Enabled = false;

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

        private void btnFoto_Click(object sender, EventArgs e)
        {
            // Cria uma instância do OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif";

            // Exibe o diálogo de seleção de arquivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtém o caminho do arquivo selecionado
                string caminhoDaImagem = openFileDialog.FileName;

                // Carrega a imagem na PictureBox
                picFotoPerfil.Image = Image.FromFile(caminhoDaImagem);
            }
        }

        private void cbxCodOnibus_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void FormCadMotorista_MouseDown(object sender, MouseEventArgs e)
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
            this.Close();
        }
    }
}
