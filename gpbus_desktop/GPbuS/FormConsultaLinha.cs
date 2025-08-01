using MySql.Data.MySqlClient;
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
    public partial class FormConsultaLinha : Form
    {
        public FormConsultaLinha()
        {
            InitializeComponent();
            //Size = new Size(786, 467);
            //WindowState = FormWindowState.Maximized;
            Linha linha = new Linha();
            MySqlDataReader r = linha.consultarTodasLinhas();
            while (r.Read())
                dgLinha.Rows.Add(r["CodigoLINHA"].ToString(), r["NumeroLINHA"].ToString(), r["NomeLINHA"].ToString(), r["EmpresaLINHA"].ToString(), r["Sentido1LINHA"].ToString(), r["Sentido2LINHA"].ToString(),
                   r["TipoLINHA"].ToString());
            DAO_Conexao.con.Close();
        }

        private void FormConsultaLinha_Load(object sender, EventArgs e)
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
            dgLinha.BackgroundColor = Color.FromArgb(128, 128, 255);
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string vazio = "";
            FormPrincipal PrincipalForm = new FormPrincipal(vazio);
            PrincipalForm.Show();
            this.Hide();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgLinha.SelectedRows.Count > 0)
            {
                // Obter o valor da coluna de identificação da instância selecionada
                string nmrLinha = dgLinha.SelectedRows[0].Cells["NumeroLINHA"].Value.ToString();

                // Criar uma instância do objeto Motorista
                Linha linha = new Linha();
                linha.Numero1 = nmrLinha;


                // Chamar o método de exclusão da linha

                DialogResult resp;
                resp = MessageBox.Show("Confirma Exclusão?", "Aviso do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    bool excluiu = linha.excluirLinha();
                    if (excluiu)
                    {
                        // Remover a linha selecionada do DataGridView
                        dgLinha.Rows.RemoveAt(dgLinha.SelectedRows[0].Index);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o linha.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada.");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormCadLinha LinhaCadForm = new FormCadLinha();
            LinhaCadForm.Show();
            this.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgLinha.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgLinha.SelectedRows[0];
                string nome = selectedRow.Cells["NomeLINHA"].Value.ToString();
                string numero = selectedRow.Cells["NumeroLINHA"].Value.ToString();
                string empresa = selectedRow.Cells["EmpresaLINHA"].Value.ToString();
                string sentido1 = selectedRow.Cells["Sentido1LINHA"].Value.ToString();
                string sentido2 = selectedRow.Cells["Sentido2LINHA"].Value.ToString();
                string tipo = selectedRow.Cells["TipoLINHA"].Value.ToString();
                FormAlterarLinha alterarForm = new FormAlterarLinha(nome, numero, empresa, tipo, sentido1, sentido2, "", "");
                alterarForm.ShowDialog();
                }
            }
        }
    }
    
