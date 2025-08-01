
namespace GPbuS
{
    partial class FormConsultaLinha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsultaLinha));
            this.gunaGradient2Panel1 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.btnCancelar = new Guna.UI.WinForms.GunaGradientButton();
            this.btnExcluir = new Guna.UI.WinForms.GunaGradientButton();
            this.btnAlterar = new Guna.UI.WinForms.GunaGradientButton();
            this.btnAdd = new Guna.UI.WinForms.GunaGradientButton();
            this.dgLinha = new Guna.UI.WinForms.GunaDataGridView();
            this.CodigoLINHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroLINHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeLINHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpresaLINHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sentido1LINHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sentido2LINHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoLINHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gunaButton2 = new Guna.UI.WinForms.GunaButton();
            this.gunaLabel11 = new Guna.UI.WinForms.GunaLabel();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaGradient2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLinha)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaGradient2Panel1
            // 
            this.gunaGradient2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel1.Controls.Add(this.btnCancelar);
            this.gunaGradient2Panel1.Controls.Add(this.btnExcluir);
            this.gunaGradient2Panel1.Controls.Add(this.btnAlterar);
            this.gunaGradient2Panel1.Controls.Add(this.btnAdd);
            this.gunaGradient2Panel1.Controls.Add(this.dgLinha);
            this.gunaGradient2Panel1.Controls.Add(this.gunaButton2);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel11);
            this.gunaGradient2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaGradient2Panel1.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.gunaGradient2Panel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.gunaGradient2Panel1.Location = new System.Drawing.Point(0, 0);
            this.gunaGradient2Panel1.Name = "gunaGradient2Panel1";
            this.gunaGradient2Panel1.Size = new System.Drawing.Size(850, 428);
            this.gunaGradient2Panel1.TabIndex = 7;
            this.gunaGradient2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaGradient2Panel1_Paint);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Animated = true;
            this.btnCancelar.AnimationHoverSpeed = 0.07F;
            this.btnCancelar.AnimationSpeed = 0.03F;
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnCancelar.BaseColor2 = System.Drawing.Color.Gold;
            this.btnCancelar.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.BorderSize = 1;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancelar.FocusedColor = System.Drawing.Color.Empty;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.Image = null;
            this.btnCancelar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCancelar.Location = new System.Drawing.Point(691, 374);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OnHoverBaseColor1 = System.Drawing.Color.Gold;
            this.btnCancelar.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnCancelar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnCancelar.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnCancelar.OnHoverImage = null;
            this.btnCancelar.OnPressedColor = System.Drawing.Color.Black;
            this.btnCancelar.Radius = 15;
            this.btnCancelar.Size = new System.Drawing.Size(137, 42);
            this.btnCancelar.TabIndex = 53;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Animated = true;
            this.btnExcluir.AnimationHoverSpeed = 0.07F;
            this.btnExcluir.AnimationSpeed = 0.03F;
            this.btnExcluir.BackColor = System.Drawing.Color.Transparent;
            this.btnExcluir.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnExcluir.BaseColor2 = System.Drawing.Color.Gold;
            this.btnExcluir.BorderColor = System.Drawing.Color.White;
            this.btnExcluir.BorderSize = 1;
            this.btnExcluir.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExcluir.FocusedColor = System.Drawing.Color.Empty;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.Black;
            this.btnExcluir.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnExcluir.Image = null;
            this.btnExcluir.ImageSize = new System.Drawing.Size(20, 20);
            this.btnExcluir.Location = new System.Drawing.Point(333, 374);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.OnHoverBaseColor1 = System.Drawing.Color.Gold;
            this.btnExcluir.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnExcluir.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnExcluir.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnExcluir.OnHoverImage = null;
            this.btnExcluir.OnPressedColor = System.Drawing.Color.Black;
            this.btnExcluir.Radius = 15;
            this.btnExcluir.Size = new System.Drawing.Size(137, 42);
            this.btnExcluir.TabIndex = 49;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Animated = true;
            this.btnAlterar.AnimationHoverSpeed = 0.07F;
            this.btnAlterar.AnimationSpeed = 0.03F;
            this.btnAlterar.BackColor = System.Drawing.Color.Transparent;
            this.btnAlterar.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnAlterar.BaseColor2 = System.Drawing.Color.Gold;
            this.btnAlterar.BorderColor = System.Drawing.Color.White;
            this.btnAlterar.BorderSize = 1;
            this.btnAlterar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAlterar.FocusedColor = System.Drawing.Color.Empty;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.ForeColor = System.Drawing.Color.Black;
            this.btnAlterar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAlterar.Image = null;
            this.btnAlterar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAlterar.Location = new System.Drawing.Point(179, 374);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.OnHoverBaseColor1 = System.Drawing.Color.Gold;
            this.btnAlterar.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnAlterar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAlterar.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnAlterar.OnHoverImage = null;
            this.btnAlterar.OnPressedColor = System.Drawing.Color.Black;
            this.btnAlterar.Radius = 15;
            this.btnAlterar.Size = new System.Drawing.Size(137, 42);
            this.btnAlterar.TabIndex = 49;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.AnimationHoverSpeed = 0.07F;
            this.btnAdd.AnimationSpeed = 0.03F;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnAdd.BaseColor2 = System.Drawing.Color.Gold;
            this.btnAdd.BorderColor = System.Drawing.Color.White;
            this.btnAdd.BorderSize = 1;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.FocusedColor = System.Drawing.Color.Empty;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAdd.Image = null;
            this.btnAdd.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAdd.Location = new System.Drawing.Point(25, 374);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnHoverBaseColor1 = System.Drawing.Color.Gold;
            this.btnAdd.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnAdd.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAdd.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnAdd.OnHoverImage = null;
            this.btnAdd.OnPressedColor = System.Drawing.Color.Black;
            this.btnAdd.Radius = 15;
            this.btnAdd.Size = new System.Drawing.Size(137, 42);
            this.btnAdd.TabIndex = 49;
            this.btnAdd.Text = "Adicionar Novo";
            this.btnAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgLinha
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(248)))), ((int)(((byte)(196)))));
            this.dgLinha.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgLinha.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgLinha.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgLinha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgLinha.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgLinha.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(12)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLinha.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgLinha.ColumnHeadersHeight = 50;
            this.dgLinha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgLinha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoLINHA,
            this.NumeroLINHA,
            this.NomeLINHA,
            this.EmpresaLINHA,
            this.Sentido1LINHA,
            this.Sentido2LINHA,
            this.TipoLINHA});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(213)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgLinha.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgLinha.EnableHeadersVisualStyles = false;
            this.dgLinha.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgLinha.Location = new System.Drawing.Point(12, 77);
            this.dgLinha.Name = "dgLinha";
            this.dgLinha.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLinha.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgLinha.RowHeadersVisible = false;
            this.dgLinha.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgLinha.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgLinha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLinha.Size = new System.Drawing.Size(826, 277);
            this.dgLinha.TabIndex = 52;
            this.dgLinha.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Ember;
            this.dgLinha.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(248)))), ((int)(((byte)(196)))));
            this.dgLinha.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgLinha.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgLinha.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgLinha.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgLinha.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgLinha.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgLinha.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(12)))));
            this.dgLinha.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgLinha.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.dgLinha.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgLinha.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgLinha.ThemeStyle.HeaderStyle.Height = 50;
            this.dgLinha.ThemeStyle.ReadOnly = false;
            this.dgLinha.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgLinha.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgLinha.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgLinha.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgLinha.ThemeStyle.RowsStyle.Height = 22;
            this.dgLinha.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(213)))), ((int)(((byte)(89)))));
            this.dgLinha.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // CodigoLINHA
            // 
            this.CodigoLINHA.HeaderText = "Código";
            this.CodigoLINHA.Name = "CodigoLINHA";
            // 
            // NumeroLINHA
            // 
            this.NumeroLINHA.HeaderText = "Número";
            this.NumeroLINHA.Name = "NumeroLINHA";
            // 
            // NomeLINHA
            // 
            this.NomeLINHA.HeaderText = "Nome";
            this.NomeLINHA.Name = "NomeLINHA";
            // 
            // EmpresaLINHA
            // 
            this.EmpresaLINHA.HeaderText = "Empresa";
            this.EmpresaLINHA.Name = "EmpresaLINHA";
            // 
            // Sentido1LINHA
            // 
            this.Sentido1LINHA.HeaderText = "Sentido 1";
            this.Sentido1LINHA.Name = "Sentido1LINHA";
            // 
            // Sentido2LINHA
            // 
            this.Sentido2LINHA.HeaderText = "Sentido 2";
            this.Sentido2LINHA.Name = "Sentido2LINHA";
            // 
            // TipoLINHA
            // 
            this.TipoLINHA.HeaderText = "Tipo";
            this.TipoLINHA.Name = "TipoLINHA";
            // 
            // gunaButton2
            // 
            this.gunaButton2.AnimationHoverSpeed = 0.07F;
            this.gunaButton2.AnimationSpeed = 0.03F;
            this.gunaButton2.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton2.BaseColor = System.Drawing.Color.Transparent;
            this.gunaButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gunaButton2.BorderSize = 1;
            this.gunaButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gunaButton2.Image = null;
            this.gunaButton2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton2.Location = new System.Drawing.Point(804, 33);
            this.gunaButton2.Name = "gunaButton2";
            this.gunaButton2.OnHoverBaseColor = System.Drawing.Color.Gray;
            this.gunaButton2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton2.OnHoverImage = null;
            this.gunaButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton2.Radius = 3;
            this.gunaButton2.Size = new System.Drawing.Size(26, 25);
            this.gunaButton2.TabIndex = 51;
            this.gunaButton2.Text = "X";
            this.gunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton2.Click += new System.EventHandler(this.gunaButton2_Click);
            // 
            // gunaLabel11
            // 
            this.gunaLabel11.AutoSize = true;
            this.gunaLabel11.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gunaLabel11.Location = new System.Drawing.Point(28, 19);
            this.gunaLabel11.Name = "gunaLabel11";
            this.gunaLabel11.Size = new System.Drawing.Size(433, 42);
            this.gunaLabel11.TabIndex = 50;
            this.gunaLabel11.Text = "Consulta de Linhas de Ônibus";
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 10;
            this.gunaElipse1.TargetControl = this;
            // 
            // FormConsultaLinha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 428);
            this.Controls.Add(this.gunaGradient2Panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConsultaLinha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormConsultaLinha";
            this.Load += new System.EventHandler(this.FormConsultaLinha_Load);
            this.gunaGradient2Panel1.ResumeLayout(false);
            this.gunaGradient2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLinha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel11;
        private Guna.UI.WinForms.GunaButton gunaButton2;
        private Guna.UI.WinForms.GunaDataGridView dgLinha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoLINHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroLINHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeLINHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpresaLINHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sentido1LINHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sentido2LINHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoLINHA;
        private Guna.UI.WinForms.GunaGradientButton btnAdd;
        private Guna.UI.WinForms.GunaGradientButton btnAlterar;
        private Guna.UI.WinForms.GunaGradientButton btnExcluir;
        private Guna.UI.WinForms.GunaGradientButton btnCancelar;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}