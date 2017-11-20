namespace WindowsFormsApplication1
{
    partial class Menu
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_options = new System.Windows.Forms.Button();
            this.btn_quit = new System.Windows.Forms.Button();
            this.btn_server = new System.Windows.Forms.Button();
            this.btn_join = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_options
            // 
            this.btn_options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_options.Location = new System.Drawing.Point(12, 398);
            this.btn_options.Name = "btn_options";
            this.btn_options.Size = new System.Drawing.Size(250, 50);
            this.btn_options.TabIndex = 0;
            this.btn_options.Text = "Optionen";
            this.btn_options.UseVisualStyleBackColor = true;
            this.btn_options.Visible = false;
            // 
            // btn_quit
            // 
            this.btn_quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_quit.Location = new System.Drawing.Point(268, 398);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(250, 50);
            this.btn_quit.TabIndex = 1;
            this.btn_quit.Text = "Beenden";
            this.btn_quit.UseVisualStyleBackColor = true;
            this.btn_quit.Visible = false;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // btn_server
            // 
            this.btn_server.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_server.Location = new System.Drawing.Point(12, 342);
            this.btn_server.Name = "btn_server";
            this.btn_server.Size = new System.Drawing.Size(506, 50);
            this.btn_server.TabIndex = 2;
            this.btn_server.Text = "Server Starten";
            this.btn_server.UseVisualStyleBackColor = true;
            this.btn_server.Visible = false;
            // 
            // btn_join
            // 
            this.btn_join.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_join.Location = new System.Drawing.Point(12, 286);
            this.btn_join.Name = "btn_join";
            this.btn_join.Size = new System.Drawing.Size(506, 50);
            this.btn_join.TabIndex = 3;
            this.btn_join.Text = "Spiel Beitreten";
            this.btn_join.UseVisualStyleBackColor = true;
            this.btn_join.Visible = false;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(13, 230);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(506, 50);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.tttgui;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(531, 531);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 531);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btn_join);
            this.Controls.Add(this.btn_server);
            this.Controls.Add(this.btn_quit);
            this.Controls.Add(this.btn_options);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_options;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.Button btn_server;
        private System.Windows.Forms.Button btn_join;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

