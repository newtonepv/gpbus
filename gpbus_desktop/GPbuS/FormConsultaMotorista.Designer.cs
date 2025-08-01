
namespace GPbuS
{
    partial class FormConsultaMotorista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsultaMotorista));
            this.dgMotorista = new Guna.UI.WinForms.GunaDataGridView();
            this.Motoristas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataNasc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNHMOTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailMOTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumOnibusMOTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CelularMOTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoMOTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CidadeMOTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnderecoMOTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEPMOTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvaliacaoMOTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gunaGradient2Panel1 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.gunaButton2 = new Guna.UI.WinForms.GunaButton();
            this.gunaLabel11 = new Guna.UI.WinForms.GunaLabel();
            this.btnAlterar = new Guna.UI.WinForms.GunaGradientButton();
            this.btnCancelar = new Guna.UI.WinForms.GunaGradientButton();
            this.btnExcluir = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgMotorista)).BeginInit();
            this.gunaGradient2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgMotorista
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(248)))), ((int)(((byte)(196)))));
            this.dgMotorista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgMotorista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMotorista.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgMotorista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgMotorista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgMotorista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(12)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMotorista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgMotorista.ColumnHeadersHeight = 50;
            this.dgMotorista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgMotorista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Motoristas,
            this.DataNasc,
            this.CNHMOTO,
            this.EmailMOTO,
            this.NumOnibusMOTO,
            this.CelularMOTO,
            this.EstadoMOTO,
            this.CidadeMOTO,
            this.EnderecoMOTO,
            this.CEPMOTO,
            this.AvaliacaoMOTO});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(213)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMotorista.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgMotorista.EnableHeadersVisualStyles = false;
            this.dgMotorista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgMotorista.Location = new System.Drawing.Point(12, 69);
            this.dgMotorista.Name = "dgMotorista";
            this.dgMotorista.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMotorista.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgMotorista.RowHeadersVisible = false;
            this.dgMotorista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgMotorista.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgMotorista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMotorista.Size = new System.Drawing.Size(1153, 331);
            this.dgMotorista.TabIndex = 6;
            this.dgMotorista.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Ember;
            this.dgMotorista.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(248)))), ((int)(((byte)(196)))));
            this.dgMotorista.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgMotorista.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgMotorista.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgMotorista.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgMotorista.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgMotorista.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgMotorista.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(12)))));
            this.dgMotorista.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgMotorista.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.dgMotorista.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgMotorista.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgMotorista.ThemeStyle.HeaderStyle.Height = 50;
            this.dgMotorista.ThemeStyle.ReadOnly = false;
            this.dgMotorista.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgMotorista.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgMotorista.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgMotorista.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgMotorista.ThemeStyle.RowsStyle.Height = 22;
            this.dgMotorista.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(213)))), ((int)(((byte)(89)))));
            this.dgMotorista.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // Motoristas
            // 
            this.Motoristas.HeaderText = "Motoristas";
            this.Motoristas.Name = "Motoristas";
            // 
            // DataNasc
            // 
            this.DataNasc.HeaderText = "Data de Nascimento";
            this.DataNasc.Name = "DataNasc";
            // 
            // CNHMOTO
            // 
            this.CNHMOTO.HeaderText = "CNH";
            this.CNHMOTO.Name = "CNHMOTO";
            // 
            // EmailMOTO
            // 
            this.EmailMOTO.HeaderText = "Email";
            this.EmailMOTO.Name = "EmailMOTO";
            // 
            // NumOnibusMOTO
            // 
            this.NumOnibusMOTO.HeaderText = "Número do Ônibus";
            this.NumOnibusMOTO.Name = "NumOnibusMOTO";
            // 
            // CelularMOTO
            // 
            this.CelularMOTO.HeaderText = "Celular";
            this.CelularMOTO.Name = "CelularMOTO";
            // 
            // EstadoMOTO
            // 
            this.EstadoMOTO.HeaderText = "Estado";
            this.EstadoMOTO.Name = "EstadoMOTO";
            // 
            // CidadeMOTO
            // 
            this.CidadeMOTO.HeaderText = "Cidade";
            this.CidadeMOTO.Name = "CidadeMOTO";
            // 
            // EnderecoMOTO
            // 
            this.EnderecoMOTO.HeaderText = "Endereço";
            this.EnderecoMOTO.Name = "EnderecoMOTO";
            // 
            // CEPMOTO
            // 
            this.CEPMOTO.HeaderText = "CEP";
            this.CEPMOTO.Name = "CEPMOTO";
            // 
            // AvaliacaoMOTO
            // 
            this.AvaliacaoMOTO.HeaderText = "Avaliação";
            this.AvaliacaoMOTO.Name = "AvaliacaoMOTO";
            // 
            // gunaGradient2Panel1
            // 
            this.gunaGradient2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel1.Controls.Add(this.gunaButton2);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel11);
            this.gunaGradient2Panel1.Controls.Add(this.dgMotorista);
            this.gunaGradient2Panel1.Controls.Add(this.btnAlterar);
            this.gunaGradient2Panel1.Controls.Add(this.btnCancelar);
            this.gunaGradient2Panel1.Controls.Add(this.btnExcluir);
            this.gunaGradient2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaGradient2Panel1.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.gunaGradient2Panel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.gunaGradient2Panel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gunaGradient2Panel1.Location = new System.Drawing.Point(0, 0);
            this.gunaGradient2Panel1.Name = "gunaGradient2Panel1";
            this.gunaGradient2Panel1.Size = new System.Drawing.Size(1177, 478);
            this.gunaGradient2Panel1.TabIndex = 7;
            this.gunaGradient2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaGradient2Panel1_Paint);
            this.gunaGradient2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gunaGradient2Panel1_MouseDown);
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
            this.gunaButton2.Location = new System.Drawing.Point(1118, 24);
            this.gunaButton2.Name = "gunaButton2";
            this.gunaButton2.OnHoverBaseColor = System.Drawing.Color.Gray;
            this.gunaButton2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton2.OnHoverImage = null;
            this.gunaButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton2.Radius = 3;
            this.gunaButton2.Size = new System.Drawing.Size(26, 25);
            this.gunaButton2.TabIndex = 50;
            this.gunaButton2.Text = "X";
            this.gunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton2.Click += new System.EventHandler(this.gunaButton2_Click);
            // 
            // gunaLabel11
            // 
            this.gunaLabel11.AutoSize = true;
            this.gunaLabel11.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gunaLabel11.Location = new System.Drawing.Point(27, 15);
            this.gunaLabel11.Name = "gunaLabel11";
            this.gunaLabel11.Size = new System.Drawing.Size(348, 42);
            this.gunaLabel11.TabIndex = 49;
            this.gunaLabel11.Text = "Consulta de Motoristas";
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
            this.btnAlterar.Location = new System.Drawing.Point(34, 421);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.OnHoverBaseColor1 = System.Drawing.Color.Gold;
            this.btnAlterar.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnAlterar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAlterar.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnAlterar.OnHoverImage = null;
            this.btnAlterar.OnPressedColor = System.Drawing.Color.Black;
            this.btnAlterar.Radius = 15;
            this.btnAlterar.Size = new System.Drawing.Size(137, 42);
            this.btnAlterar.TabIndex = 48;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(988, 421);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OnHoverBaseColor1 = System.Drawing.Color.Gold;
            this.btnCancelar.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnCancelar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnCancelar.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnCancelar.OnHoverImage = null;
            this.btnCancelar.OnPressedColor = System.Drawing.Color.Black;
            this.btnCancelar.Radius = 15;
            this.btnCancelar.Size = new System.Drawing.Size(137, 42);
            this.btnCancelar.TabIndex = 48;
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
            this.btnExcluir.Location = new System.Drawing.Point(203, 421);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.OnHoverBaseColor1 = System.Drawing.Color.Gainsboro;
            this.btnExcluir.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnExcluir.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnExcluir.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnExcluir.OnHoverImage = null;
            this.btnExcluir.OnPressedColor = System.Drawing.Color.Black;
            this.btnExcluir.Radius = 15;
            this.btnExcluir.Size = new System.Drawing.Size(137, 42);
            this.btnExcluir.TabIndex = 48;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 10;
            this.gunaElipse1.TargetControl = this;
            // 
            // FormConsultaMotorista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 478);
            this.Controls.Add(this.gunaGradient2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(571, 432);
            this.Name = "FormConsultaMotorista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaMotorista";
            this.Load += new System.EventHandler(this.ConsultaMotorista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMotorista)).EndInit();
            this.gunaGradient2Panel1.ResumeLayout(false);
            this.gunaGradient2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaDataGridView dgMotorista;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaGradientButton btnAlterar;
        private Guna.UI.WinForms.GunaGradientButton btnExcluir;
        private Guna.UI.WinForms.GunaGradientButton btnCancelar;
        private Guna.UI.WinForms.GunaLabel gunaLabel11;
        private Guna.UI.WinForms.GunaButton gunaButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Motoristas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataNasc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNHMOTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailMOTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumOnibusMOTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CelularMOTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoMOTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CidadeMOTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnderecoMOTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEPMOTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvaliacaoMOTO;
    }
}