
namespace GPbuS
{
    partial class FormInicial
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicial));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaGradientPanel1 = new Guna.UI.WinForms.GunaGradientPanel();
            this.gunaLinkLabel2 = new Guna.UI.WinForms.GunaLinkLabel();
            this.chkLembrarMe = new Guna.UI.WinForms.GunaCheckBox();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaTransfarantPictureBox3 = new Guna.UI.WinForms.GunaTransfarantPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaLinkLabel1 = new Guna.UI.WinForms.GunaLinkLabel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.btnLogin = new Guna.UI.WinForms.GunaAdvenceButton();
            this.gunaTransfarantPictureBox2 = new Guna.UI.WinForms.GunaTransfarantPictureBox();
            this.txtSenha = new Guna.UI.WinForms.GunaTextBox();
            this.gunaTransfarantPictureBox1 = new Guna.UI.WinForms.GunaTransfarantPictureBox();
            this.txtEmail = new Guna.UI.WinForms.GunaTextBox();
            this.gunaGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaTransfarantPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaTransfarantPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaTransfarantPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 10;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaGradientPanel1
            // 
            this.gunaGradientPanel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gunaGradientPanel1.BackColor = System.Drawing.Color.White;
            this.gunaGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gunaGradientPanel1.BackgroundImage")));
            this.gunaGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaGradientPanel1.Controls.Add(this.gunaLinkLabel2);
            this.gunaGradientPanel1.Controls.Add(this.chkLembrarMe);
            this.gunaGradientPanel1.Controls.Add(this.gunaLabel3);
            this.gunaGradientPanel1.Controls.Add(this.gunaLabel2);
            this.gunaGradientPanel1.Controls.Add(this.gunaTransfarantPictureBox3);
            this.gunaGradientPanel1.Controls.Add(this.label1);
            this.gunaGradientPanel1.Controls.Add(this.gunaLinkLabel1);
            this.gunaGradientPanel1.Controls.Add(this.gunaLabel1);
            this.gunaGradientPanel1.Controls.Add(this.btnLogin);
            this.gunaGradientPanel1.Controls.Add(this.gunaTransfarantPictureBox2);
            this.gunaGradientPanel1.Controls.Add(this.txtSenha);
            this.gunaGradientPanel1.Controls.Add(this.gunaTransfarantPictureBox1);
            this.gunaGradientPanel1.Controls.Add(this.txtEmail);
            this.gunaGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaGradientPanel1.GradientColor1 = System.Drawing.Color.BlanchedAlmond;
            this.gunaGradientPanel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gunaGradientPanel1.GradientColor3 = System.Drawing.Color.Orange;
            this.gunaGradientPanel1.GradientColor4 = System.Drawing.Color.Gold;
            this.gunaGradientPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gunaGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaGradientPanel1.Name = "gunaGradientPanel1";
            this.gunaGradientPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gunaGradientPanel1.Size = new System.Drawing.Size(354, 457);
            this.gunaGradientPanel1.TabIndex = 8;
            this.gunaGradientPanel1.Text = "gunaGradientPanel1";
            this.gunaGradientPanel1.Click += new System.EventHandler(this.gunaGradientPanel1_Click_1);
            this.gunaGradientPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gunaGradientPanel1_MouseDown);
            // 
            // gunaLinkLabel2
            // 
            this.gunaLinkLabel2.ActiveLinkColor = System.Drawing.Color.DarkRed;
            this.gunaLinkLabel2.AutoSize = true;
            this.gunaLinkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaLinkLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLinkLabel2.LinkColor = System.Drawing.Color.Red;
            this.gunaLinkLabel2.Location = new System.Drawing.Point(190, 316);
            this.gunaLinkLabel2.Name = "gunaLinkLabel2";
            this.gunaLinkLabel2.Size = new System.Drawing.Size(90, 15);
            this.gunaLinkLabel2.TabIndex = 18;
            this.gunaLinkLabel2.TabStop = true;
            this.gunaLinkLabel2.Text = "Esqueci a senha";
            this.gunaLinkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gunaLinkLabel2_LinkClicked);
            // 
            // chkLembrarMe
            // 
            this.chkLembrarMe.BackColor = System.Drawing.Color.Transparent;
            this.chkLembrarMe.BaseColor = System.Drawing.Color.White;
            this.chkLembrarMe.CheckedOffColor = System.Drawing.Color.Gray;
            this.chkLembrarMe.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkLembrarMe.FillColor = System.Drawing.Color.White;
            this.chkLembrarMe.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLembrarMe.Location = new System.Drawing.Point(68, 314);
            this.chkLembrarMe.Name = "chkLembrarMe";
            this.chkLembrarMe.Size = new System.Drawing.Size(110, 20);
            this.chkLembrarMe.TabIndex = 17;
            this.chkLembrarMe.Text = "Remember me";
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel3.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel3.ForeColor = System.Drawing.Color.White;
            this.gunaLabel3.Location = new System.Drawing.Point(150, 196);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(67, 21);
            this.gunaLabel3.TabIndex = 16;
            this.gunaLabel3.Text = "LOG IN";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel2.Font = new System.Drawing.Font("Yu Gothic Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.Black;
            this.gunaLabel2.Location = new System.Drawing.Point(122, 430);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(104, 18);
            this.gunaLabel2.TabIndex = 14;
            this.gunaLabel2.Text = "LLPN Company";
            // 
            // gunaTransfarantPictureBox3
            // 
            this.gunaTransfarantPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransfarantPictureBox3.BaseColor = System.Drawing.Color.Black;
            this.gunaTransfarantPictureBox3.Image = global::GPbuS.Properties.Resources.GPbuSLogo;
            this.gunaTransfarantPictureBox3.Location = new System.Drawing.Point(91, 22);
            this.gunaTransfarantPictureBox3.Name = "gunaTransfarantPictureBox3";
            this.gunaTransfarantPictureBox3.Size = new System.Drawing.Size(167, 119);
            this.gunaTransfarantPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaTransfarantPictureBox3.TabIndex = 13;
            this.gunaTransfarantPictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(56, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Sua Cidade ao Seu Alcance";
            // 
            // gunaLinkLabel1
            // 
            this.gunaLinkLabel1.ActiveLinkColor = System.Drawing.Color.DarkRed;
            this.gunaLinkLabel1.AutoSize = true;
            this.gunaLinkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaLinkLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLinkLabel1.LinkColor = System.Drawing.Color.Red;
            this.gunaLinkLabel1.Location = new System.Drawing.Point(218, 394);
            this.gunaLinkLabel1.Name = "gunaLinkLabel1";
            this.gunaLinkLabel1.Size = new System.Drawing.Size(81, 15);
            this.gunaLinkLabel1.TabIndex = 11;
            this.gunaLinkLabel1.TabStop = true;
            this.gunaLinkLabel1.Text = "Cadastre-se já";
            this.gunaLinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gunaLinkLabel1_LinkClicked);
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.Location = new System.Drawing.Point(44, 394);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(150, 15);
            this.gunaLabel1.TabIndex = 10;
            this.gunaLabel1.Text = "Ainda não tem uma conta?";
            // 
            // btnLogin
            // 
            this.btnLogin.AnimationHoverSpeed = 0.07F;
            this.btnLogin.AnimationSpeed = 0.03F;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BaseColor = System.Drawing.Color.White;
            this.btnLogin.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderSize = 1;
            this.btnLogin.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnLogin.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnLogin.CheckedForeColor = System.Drawing.Color.White;
            this.btnLogin.CheckedImage = null;
            this.btnLogin.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.FocusedColor = System.Drawing.Color.Empty;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Image = null;
            this.btnLogin.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLogin.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnLogin.Location = new System.Drawing.Point(125, 344);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogin.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLogin.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLogin.OnHoverImage = null;
            this.btnLogin.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnLogin.OnPressedColor = System.Drawing.Color.DarkGray;
            this.btnLogin.Radius = 15;
            this.btnLogin.Size = new System.Drawing.Size(108, 31);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // gunaTransfarantPictureBox2
            // 
            this.gunaTransfarantPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransfarantPictureBox2.BaseColor = System.Drawing.Color.Black;
            this.gunaTransfarantPictureBox2.Image = global::GPbuS.Properties.Resources.padlock_3064155;
            this.gunaTransfarantPictureBox2.Location = new System.Drawing.Point(68, 285);
            this.gunaTransfarantPictureBox2.Name = "gunaTransfarantPictureBox2";
            this.gunaTransfarantPictureBox2.Size = new System.Drawing.Size(25, 19);
            this.gunaTransfarantPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaTransfarantPictureBox2.TabIndex = 7;
            this.gunaTransfarantPictureBox2.TabStop = false;
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.Transparent;
            this.txtSenha.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSenha.BorderColor = System.Drawing.Color.Snow;
            this.txtSenha.BorderSize = 1;
            this.txtSenha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSenha.FocusedBaseColor = System.Drawing.Color.White;
            this.txtSenha.FocusedBorderColor = System.Drawing.Color.Black;
            this.txtSenha.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(98, 283);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '\0';
            this.txtSenha.Radius = 5;
            this.txtSenha.SelectedText = "";
            this.txtSenha.Size = new System.Drawing.Size(182, 23);
            this.txtSenha.TabIndex = 6;
            this.txtSenha.Text = "Digite sua senha";
            this.txtSenha.Enter += new System.EventHandler(this.txtSenha_Enter);
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            // 
            // gunaTransfarantPictureBox1
            // 
            this.gunaTransfarantPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransfarantPictureBox1.BaseColor = System.Drawing.Color.Black;
            this.gunaTransfarantPictureBox1.Image = global::GPbuS.Properties.Resources.email_542689;
            this.gunaTransfarantPictureBox1.Location = new System.Drawing.Point(68, 248);
            this.gunaTransfarantPictureBox1.Name = "gunaTransfarantPictureBox1";
            this.gunaTransfarantPictureBox1.Size = new System.Drawing.Size(25, 19);
            this.gunaTransfarantPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaTransfarantPictureBox1.TabIndex = 1;
            this.gunaTransfarantPictureBox1.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEmail.BorderColor = System.Drawing.Color.Snow;
            this.txtEmail.BorderSize = 1;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.FocusedBaseColor = System.Drawing.Color.White;
            this.txtEmail.FocusedBorderColor = System.Drawing.Color.Black;
            this.txtEmail.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(98, 245);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.Radius = 5;
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(182, 23);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.Text = "Digite seu email";
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(354, 457);
            this.Controls.Add(this.gunaGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login&Cadastro";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.gunaGradientPanel1.ResumeLayout(false);
            this.gunaGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaTransfarantPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaTransfarantPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaTransfarantPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaGradientPanel gunaGradientPanel1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaTransfarantPictureBox gunaTransfarantPictureBox1;
        private Guna.UI.WinForms.GunaTextBox txtEmail;
        private Guna.UI.WinForms.GunaTextBox txtSenha;
        private Guna.UI.WinForms.GunaTransfarantPictureBox gunaTransfarantPictureBox2;
        private Guna.UI.WinForms.GunaAdvenceButton btnLogin;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLinkLabel gunaLinkLabel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTransfarantPictureBox gunaTransfarantPictureBox3;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaCheckBox chkLembrarMe;
        private Guna.UI.WinForms.GunaLinkLabel gunaLinkLabel2;
    }
}

