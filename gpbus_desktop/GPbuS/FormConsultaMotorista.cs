using MySql.Data.MySqlClient;
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
    public partial class FormConsultaMotorista : Form
    {

        // Importar a função necessária da biblioteca do Windows para permitir o movimento
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormConsultaMotorista()
        {
            InitializeComponent();
            Motorista motorista = new Motorista();
            MySqlDataReader r = motorista.consultarTodosMotoristas();
            while (r.Read())
                dgMotorista.Rows.Add(r["NomeMOTO"].ToString(), r["DataNascMOTO"].ToString(), r["CNHMOTO"].ToString(), r["EmailMOTO"].ToString(), r["NumeroOnibusMOTO"].ToString(),
                   r["CelularMOTO"].ToString(), r["EstadoMOTO"].ToString(), r["CidadeMOTO"].ToString(), r["EnderecoMOTO"].ToString(), r["CEPMOTO"].ToString(), r["AvaliacaoMOTO"].ToString());
            DAO_Conexao.con.Close();
        }

        private void ConsultaMotorista_Load(object sender, EventArgs e)
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
            gunaGradient2Panel1.GradientColor2 = Color.FromArgb(96, 97, 192);
            dgMotorista.BackgroundColor = Color.FromArgb(128, 128, 255);
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string vazio = "";
            FormPrincipal PrincipalForm = new FormPrincipal(vazio);
            PrincipalForm.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgMotorista.SelectedRows.Count > 0)
            {
                // Obter o valor da coluna de identificação da instância selecionada
                string cnh = dgMotorista.SelectedRows[0].Cells["CNHMOTO"].Value.ToString();

                // Criar uma instância do objeto Motorista
                Motorista motorista = new Motorista();
                motorista.CNH1 = cnh;


                // Chamar o método de exclusão do motorista
                
                DialogResult resp;
                resp = MessageBox.Show("Confirma Exclusão?", "Aviso do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    bool excluiu = motorista.excluirMotorista();
                    if (excluiu)
                    {
                        // Remover a linha selecionada do DataGridView
                        dgMotorista.Rows.RemoveAt(dgMotorista.SelectedRows[0].Index);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o motorista.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgMotorista.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgMotorista.SelectedRows[0];
                string nome = selectedRow.Cells["Motoristas"].Value.ToString();
                string dataNasc = selectedRow.Cells["DataNasc"].Value.ToString();
                string cnh = selectedRow.Cells["CNHMOTO"].Value.ToString();
                string email = selectedRow.Cells["EmailMOTO"].Value.ToString();
                int numOnibus;
                if (selectedRow.Cells["NumOnibusMOTO"].Value != null && !string.IsNullOrWhiteSpace(selectedRow.Cells["NumOnibusMOTO"].Value.ToString()))
                {
                    if (int.TryParse(selectedRow.Cells["NumOnibusMOTO"].Value.ToString(), out numOnibus))
                    {
                        string celular = selectedRow.Cells["CelularMOTO"].Value.ToString();
                        string estado = selectedRow.Cells["EstadoMOTO"].Value.ToString();
                        string cidade = selectedRow.Cells["CidadeMOTO"].Value.ToString();
                        string endereco = selectedRow.Cells["EstadoMOTO"].Value.ToString();
                        string cep = selectedRow.Cells["CEPMOTO"].Value.ToString();
                        string avaliacao = selectedRow.Cells["AvaliacaoMOTO"].Value.ToString();

                        FormAlterarMoto alterarForm = new FormAlterarMoto(nome, dataNasc, cnh, email, numOnibus, celular, estado, cidade, endereco, cep, avaliacao);
                        alterarForm.ShowDialog();
                    }
                    else
                    {
                        // Mensagem de erro ou tratamento adequado para o caso em que a conversão falha
                        MessageBox.Show("Valor inválido para NumOnibusMOTO.");
                    }
                }
                else
                {
                    // Se NumOnibusMOTO estiver vazio ou nulo, continue sem definir numOnibus
                    string celular = selectedRow.Cells["CelularMOTO"].Value.ToString();
                    string estado = selectedRow.Cells["EstadoMOTO"].Value.ToString();
                    string cidade = selectedRow.Cells["CidadeMOTO"].Value.ToString();
                    string endereco = selectedRow.Cells["EstadoMOTO"].Value.ToString();
                    string cep = selectedRow.Cells["CEPMOTO"].Value.ToString();
                    string avaliacao = selectedRow.Cells["AvaliacaoMOTO"].Value.ToString();

                    FormAlterarMoto alterarForm = new FormAlterarMoto(nome, dataNasc, cnh, email, 0, celular, estado, cidade, endereco, cep, avaliacao);
                    alterarForm.ShowDialog();
                }
                }
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

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
