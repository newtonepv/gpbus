
namespace GPbuS
{
    partial class FormCadADM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadADM));
            this.txtCEP = new System.Windows.Forms.MaskedTextBox();
            this.cbxCidade = new System.Windows.Forms.ComboBox();
            this.cbxEstado = new System.Windows.Forms.ComboBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.gunaGradient2Panel1 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.btnProximo = new Guna.UI.WinForms.GunaGradientButton();
            this.btnFoto = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaLabel10 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel9 = new Guna.UI.WinForms.GunaLabel();
            this.txtEndereco = new Guna.UI.WinForms.GunaTextBox();
            this.txtDataNasc = new Guna.UI.WinForms.GunaDateTimePicker();
            this.txtEmail = new Guna.UI.WinForms.GunaTextBox();
            this.gunaLabel8 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel7 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel6 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel5 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.lblNome = new Guna.UI.WinForms.GunaLabel();
            this.txtNome = new Guna.UI.WinForms.GunaTextBox();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse2 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse3 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse4 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse5 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse6 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse7 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaButton2 = new Guna.UI.WinForms.GunaButton();
            this.picFotoPerfil = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.gunaGradient2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(80, 381);
            this.txtCEP.Mask = "99.999-999";
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(66, 20);
            this.txtCEP.TabIndex = 24;
            this.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxCidade
            // 
            this.cbxCidade.FormattingEnabled = true;
            this.cbxCidade.Items.AddRange(new object[] {
            "Campinas",
            "Cosmópolis",
            "Hortolândia",
            "Limeira",
            "Rio Claro",
            "Sumaré",
            ""});
            this.cbxCidade.Location = new System.Drawing.Point(97, 307);
            this.cbxCidade.Name = "cbxCidade";
            this.cbxCidade.Size = new System.Drawing.Size(147, 21);
            this.cbxCidade.TabIndex = 30;
            // 
            // cbxEstado
            // 
            this.cbxEstado.FormattingEnabled = true;
            this.cbxEstado.Location = new System.Drawing.Point(97, 273);
            this.cbxEstado.Name = "cbxEstado";
            this.cbxEstado.Size = new System.Drawing.Size(147, 21);
            this.cbxEstado.TabIndex = 29;
            this.cbxEstado.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstados_SelectedIndexChanged);
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(97, 239);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(84, 20);
            this.txtCPF.TabIndex = 22;
            this.txtCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(97, 201);
            this.txtCelular.Mask = "(99) 99999-9999 ";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(92, 20);
            this.txtCelular.TabIndex = 10;
            this.txtCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gunaGradient2Panel1
            // 
            this.gunaGradient2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel1.Controls.Add(this.gunaButton2);
            this.gunaGradient2Panel1.Controls.Add(this.btnProximo);
            this.gunaGradient2Panel1.Controls.Add(this.btnFoto);
            this.gunaGradient2Panel1.Controls.Add(this.picFotoPerfil);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel10);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel9);
            this.gunaGradient2Panel1.Controls.Add(this.txtEndereco);
            this.gunaGradient2Panel1.Controls.Add(this.txtDataNasc);
            this.gunaGradient2Panel1.Controls.Add(this.txtEmail);
            this.gunaGradient2Panel1.Controls.Add(this.txtCPF);
            this.gunaGradient2Panel1.Controls.Add(this.txtCEP);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel8);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel7);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel6);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel5);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel4);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel3);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel2);
            this.gunaGradient2Panel1.Controls.Add(this.gunaLabel1);
            this.gunaGradient2Panel1.Controls.Add(this.lblNome);
            this.gunaGradient2Panel1.Controls.Add(this.txtNome);
            this.gunaGradient2Panel1.Controls.Add(this.cbxCidade);
            this.gunaGradient2Panel1.Controls.Add(this.cbxEstado);
            this.gunaGradient2Panel1.Controls.Add(this.txtCelular);
            this.gunaGradient2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaGradient2Panel1.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(123)))), ((int)(((byte)(153)))));
            this.gunaGradient2Panel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.gunaGradient2Panel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gunaGradient2Panel1.Location = new System.Drawing.Point(0, 0);
            this.gunaGradient2Panel1.Name = "gunaGradient2Panel1";
            this.gunaGradient2Panel1.Size = new System.Drawing.Size(688, 448);
            this.gunaGradient2Panel1.TabIndex = 31;
            this.gunaGradient2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaGradient2Panel1_Paint);
            this.gunaGradient2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gunaGradient2Panel1_MouseDown);
            // 
            // btnProximo
            // 
            this.btnProximo.Animated = true;
            this.btnProximo.AnimationHoverSpeed = 0.07F;
            this.btnProximo.AnimationSpeed = 0.03F;
            this.btnProximo.BackColor = System.Drawing.Color.Transparent;
            this.btnProximo.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnProximo.BaseColor2 = System.Drawing.Color.Gold;
            this.btnProximo.BorderColor = System.Drawing.Color.White;
            this.btnProximo.BorderSize = 1;
            this.btnProximo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnProximo.FocusedColor = System.Drawing.Color.Empty;
            this.btnProximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProximo.ForeColor = System.Drawing.Color.White;
            this.btnProximo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnProximo.Image = null;
            this.btnProximo.ImageSize = new System.Drawing.Size(20, 20);
            this.btnProximo.Location = new System.Drawing.Point(486, 368);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.OnHoverBaseColor1 = System.Drawing.Color.Gold;
            this.btnProximo.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(104)))));
            this.btnProximo.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnProximo.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnProximo.OnHoverImage = null;
            this.btnProximo.OnPressedColor = System.Drawing.Color.Black;
            this.btnProximo.Radius = 15;
            this.btnProximo.Size = new System.Drawing.Size(137, 33);
            this.btnProximo.TabIndex = 42;
            this.btnProximo.Text = "Próximo";
            this.btnProximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnFoto
            // 
            this.btnFoto.Animated = true;
            this.btnFoto.AnimationHoverSpeed = 0.07F;
            this.btnFoto.AnimationSpeed = 0.03F;
            this.btnFoto.BackColor = System.Drawing.Color.Transparent;
            this.btnFoto.BaseColor1 = System.Drawing.Color.White;
            this.btnFoto.BaseColor2 = System.Drawing.Color.White;
            this.btnFoto.BorderColor = System.Drawing.Color.Black;
            this.btnFoto.BorderSize = 1;
            this.btnFoto.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFoto.FocusedColor = System.Drawing.Color.Empty;
            this.btnFoto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFoto.ForeColor = System.Drawing.Color.Black;
            this.btnFoto.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnFoto.Image = null;
            this.btnFoto.ImageSize = new System.Drawing.Size(20, 20);
            this.btnFoto.Location = new System.Drawing.Point(486, 319);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFoto.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFoto.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnFoto.OnHoverForeColor = System.Drawing.Color.White;
            this.btnFoto.OnHoverImage = null;
            this.btnFoto.OnPressedColor = System.Drawing.Color.Black;
            this.btnFoto.Radius = 4;
            this.btnFoto.Size = new System.Drawing.Size(137, 25);
            this.btnFoto.TabIndex = 41;
            this.btnFoto.Text = "Selecione uma Imagem";
            this.btnFoto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // gunaLabel10
            // 
            this.gunaLabel10.AutoSize = true;
            this.gunaLabel10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel10.ForeColor = System.Drawing.Color.White;
            this.gunaLabel10.Location = new System.Drawing.Point(463, 105);
            this.gunaLabel10.Name = "gunaLabel10";
            this.gunaLabel10.Size = new System.Drawing.Size(186, 16);
            this.gunaLabel10.TabIndex = 39;
            this.gunaLabel10.Text = "Insira uma foto de perfil:";
            this.gunaLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaLabel9
            // 
            this.gunaLabel9.AutoSize = true;
            this.gunaLabel9.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gunaLabel9.Location = new System.Drawing.Point(103, 21);
            this.gunaLabel9.Name = "gunaLabel9";
            this.gunaLabel9.Size = new System.Drawing.Size(546, 59);
            this.gunaLabel9.TabIndex = 38;
            this.gunaLabel9.Text = "Cadastro de Administrador";
            // 
            // txtEndereco
            // 
            this.txtEndereco.BackColor = System.Drawing.Color.Transparent;
            this.txtEndereco.BaseColor = System.Drawing.Color.White;
            this.txtEndereco.BorderColor = System.Drawing.Color.Black;
            this.txtEndereco.BorderSize = 1;
            this.txtEndereco.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEndereco.FocusedBaseColor = System.Drawing.Color.White;
            this.txtEndereco.FocusedBorderColor = System.Drawing.Color.Gold;
            this.txtEndereco.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEndereco.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(108, 344);
            this.txtEndereco.MaximumSize = new System.Drawing.Size(312, 20);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.PasswordChar = '\0';
            this.txtEndereco.Radius = 6;
            this.txtEndereco.SelectedText = "";
            this.txtEndereco.Size = new System.Drawing.Size(265, 20);
            this.txtEndereco.TabIndex = 37;
            // 
            // txtDataNasc
            // 
            this.txtDataNasc.BackColor = System.Drawing.Color.Transparent;
            this.txtDataNasc.BaseColor = System.Drawing.Color.White;
            this.txtDataNasc.BorderColor = System.Drawing.Color.Black;
            this.txtDataNasc.BorderSize = 1;
            this.txtDataNasc.CustomFormat = null;
            this.txtDataNasc.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.txtDataNasc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDataNasc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDataNasc.ForeColor = System.Drawing.Color.Black;
            this.txtDataNasc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataNasc.Location = new System.Drawing.Point(187, 171);
            this.txtDataNasc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtDataNasc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtDataNasc.Name = "txtDataNasc";
            this.txtDataNasc.OnHoverBaseColor = System.Drawing.Color.White;
            this.txtDataNasc.OnHoverBorderColor = System.Drawing.Color.Gold;
            this.txtDataNasc.OnHoverForeColor = System.Drawing.Color.Black;
            this.txtDataNasc.OnPressedColor = System.Drawing.Color.Black;
            this.txtDataNasc.Radius = 4;
            this.txtDataNasc.Size = new System.Drawing.Size(119, 20);
            this.txtDataNasc.TabIndex = 36;
            this.txtDataNasc.Text = "05/08/2023";
            this.txtDataNasc.Value = new System.DateTime(2023, 8, 5, 0, 0, 0, 0);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BaseColor = System.Drawing.Color.White;
            this.txtEmail.BorderColor = System.Drawing.Color.Black;
            this.txtEmail.BorderSize = 1;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.FocusedBaseColor = System.Drawing.Color.White;
            this.txtEmail.FocusedBorderColor = System.Drawing.Color.Gold;
            this.txtEmail.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(84, 137);
            this.txtEmail.MaximumSize = new System.Drawing.Size(312, 20);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.Radius = 6;
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(289, 20);
            this.txtEmail.TabIndex = 35;
            // 
            // gunaLabel8
            // 
            this.gunaLabel8.AutoSize = true;
            this.gunaLabel8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel8.ForeColor = System.Drawing.Color.White;
            this.gunaLabel8.Location = new System.Drawing.Point(37, 383);
            this.gunaLabel8.Name = "gunaLabel8";
            this.gunaLabel8.Size = new System.Drawing.Size(37, 14);
            this.gunaLabel8.TabIndex = 34;
            this.gunaLabel8.Text = "CEP:";
            this.gunaLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaLabel7
            // 
            this.gunaLabel7.AutoSize = true;
            this.gunaLabel7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel7.ForeColor = System.Drawing.Color.White;
            this.gunaLabel7.Location = new System.Drawing.Point(38, 345);
            this.gunaLabel7.Name = "gunaLabel7";
            this.gunaLabel7.Size = new System.Drawing.Size(75, 14);
            this.gunaLabel7.TabIndex = 33;
            this.gunaLabel7.Text = "Endereço: ";
            this.gunaLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaLabel6
            // 
            this.gunaLabel6.AutoSize = true;
            this.gunaLabel6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel6.ForeColor = System.Drawing.Color.White;
            this.gunaLabel6.Location = new System.Drawing.Point(35, 309);
            this.gunaLabel6.Name = "gunaLabel6";
            this.gunaLabel6.Size = new System.Drawing.Size(57, 16);
            this.gunaLabel6.TabIndex = 32;
            this.gunaLabel6.Text = "Cidade:";
            this.gunaLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaLabel5
            // 
            this.gunaLabel5.AutoSize = true;
            this.gunaLabel5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel5.ForeColor = System.Drawing.Color.White;
            this.gunaLabel5.Location = new System.Drawing.Point(35, 275);
            this.gunaLabel5.Name = "gunaLabel5";
            this.gunaLabel5.Size = new System.Drawing.Size(58, 16);
            this.gunaLabel5.TabIndex = 31;
            this.gunaLabel5.Text = "Estado:";
            this.gunaLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel4.ForeColor = System.Drawing.Color.White;
            this.gunaLabel4.Location = new System.Drawing.Point(37, 240);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(38, 16);
            this.gunaLabel4.TabIndex = 29;
            this.gunaLabel4.Text = "CPF:";
            this.gunaLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel3.ForeColor = System.Drawing.Color.White;
            this.gunaLabel3.Location = new System.Drawing.Point(35, 203);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(57, 16);
            this.gunaLabel3.TabIndex = 28;
            this.gunaLabel3.Text = "Celular:";
            this.gunaLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.White;
            this.gunaLabel2.Location = new System.Drawing.Point(35, 171);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(146, 16);
            this.gunaLabel2.TabIndex = 27;
            this.gunaLabel2.Text = "Data de Nascimento:";
            this.gunaLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.White;
            this.gunaLabel1.Location = new System.Drawing.Point(34, 137);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(46, 16);
            this.gunaLabel1.TabIndex = 2;
            this.gunaLabel1.Text = "Email:";
            this.gunaLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.ForeColor = System.Drawing.Color.White;
            this.lblNome.Location = new System.Drawing.Point(34, 102);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(49, 16);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome:";
            this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.Transparent;
            this.txtNome.BaseColor = System.Drawing.Color.White;
            this.txtNome.BorderColor = System.Drawing.Color.Black;
            this.txtNome.BorderSize = 1;
            this.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNome.FocusedBaseColor = System.Drawing.Color.White;
            this.txtNome.FocusedBorderColor = System.Drawing.Color.Gold;
            this.txtNome.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNome.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(84, 102);
            this.txtNome.MaximumSize = new System.Drawing.Size(312, 20);
            this.txtNome.Name = "txtNome";
            this.txtNome.PasswordChar = '\0';
            this.txtNome.Radius = 6;
            this.txtNome.SelectedText = "";
            this.txtNome.Size = new System.Drawing.Size(289, 20);
            this.txtNome.TabIndex = 0;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 15;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaElipse2
            // 
            this.gunaElipse2.Radius = 2;
            this.gunaElipse2.TargetControl = this;
            // 
            // gunaElipse3
            // 
            this.gunaElipse3.Radius = 2;
            this.gunaElipse3.TargetControl = this.txtCelular;
            // 
            // gunaElipse4
            // 
            this.gunaElipse4.Radius = 2;
            this.gunaElipse4.TargetControl = this.txtCPF;
            // 
            // gunaElipse5
            // 
            this.gunaElipse5.Radius = 3;
            this.gunaElipse5.TargetControl = this.cbxEstado;
            // 
            // gunaElipse6
            // 
            this.gunaElipse6.Radius = 3;
            this.gunaElipse6.TargetControl = this.cbxCidade;
            // 
            // gunaElipse7
            // 
            this.gunaElipse7.Radius = 2;
            this.gunaElipse7.TargetControl = this.txtCEP;
            // 
            // gunaButton2
            // 
            this.gunaButton2.Animated = true;
            this.gunaButton2.AnimationHoverSpeed = 0.07F;
            this.gunaButton2.AnimationSpeed = 0.03F;
            this.gunaButton2.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaButton2.BaseColor = System.Drawing.Color.Transparent;
            this.gunaButton2.BorderColor = System.Drawing.Color.Transparent;
            this.gunaButton2.BorderSize = 1;
            this.gunaButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton2.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gunaButton2.Image = global::GPbuS.Properties.Resources.de_volta;
            this.gunaButton2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton2.Location = new System.Drawing.Point(37, 38);
            this.gunaButton2.Name = "gunaButton2";
            this.gunaButton2.OnHoverBaseColor = System.Drawing.Color.LightGray;
            this.gunaButton2.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gunaButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton2.OnHoverImage = null;
            this.gunaButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton2.Radius = 4;
            this.gunaButton2.Size = new System.Drawing.Size(26, 25);
            this.gunaButton2.TabIndex = 43;
            this.gunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton2.Click += new System.EventHandler(this.gunaButton2_Click);
            // 
            // picFotoPerfil
            // 
            this.picFotoPerfil.BaseColor = System.Drawing.Color.White;
            this.picFotoPerfil.Location = new System.Drawing.Point(466, 128);
            this.picFotoPerfil.Name = "picFotoPerfil";
            this.picFotoPerfil.Size = new System.Drawing.Size(175, 175);
            this.picFotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFotoPerfil.TabIndex = 40;
            this.picFotoPerfil.TabStop = false;
            this.picFotoPerfil.UseTransfarantBackground = false;
            // 
            // FormCadADM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(688, 448);
            this.Controls.Add(this.gunaGradient2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(571, 432);
            this.Name = "FormCadADM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCadADM";
            this.Load += new System.EventHandler(this.FormCadADM_Load);
            this.gunaGradient2Panel1.ResumeLayout(false);
            this.gunaGradient2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoPerfil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.ComboBox cbxEstado;
        private System.Windows.Forms.ComboBox cbxCidade;
        private System.Windows.Forms.MaskedTextBox txtCEP;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaTextBox txtNome;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLabel lblNome;
        private Guna.UI.WinForms.GunaTextBox txtEmail;
        private Guna.UI.WinForms.GunaLabel gunaLabel8;
        private Guna.UI.WinForms.GunaLabel gunaLabel7;
        private Guna.UI.WinForms.GunaLabel gunaLabel6;
        private Guna.UI.WinForms.GunaLabel gunaLabel5;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaElipse gunaElipse2;
        private Guna.UI.WinForms.GunaDateTimePicker txtDataNasc;
        private Guna.UI.WinForms.GunaElipse gunaElipse3;
        private Guna.UI.WinForms.GunaElipse gunaElipse4;
        private Guna.UI.WinForms.GunaTextBox txtEndereco;
        private Guna.UI.WinForms.GunaElipse gunaElipse5;
        private Guna.UI.WinForms.GunaElipse gunaElipse6;
        private Guna.UI.WinForms.GunaElipse gunaElipse7;
        private Guna.UI.WinForms.GunaCirclePictureBox picFotoPerfil;
        private Guna.UI.WinForms.GunaLabel gunaLabel10;
        private Guna.UI.WinForms.GunaLabel gunaLabel9;
        private Guna.UI.WinForms.GunaGradientButton btnFoto;
        private Guna.UI.WinForms.GunaGradientButton btnProximo;
        private Guna.UI.WinForms.GunaButton gunaButton2;
    }
}