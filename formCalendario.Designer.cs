namespace Reservas {
    partial class formCalendario {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCalendario));
            btUsuarios = new Button();
            btVeiculos = new Button();
            layoutCalendar = new FlowLayoutPanel();
            btProximoMes = new Button();
            btMesAnterior = new Button();
            lbMes = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            lbUsuario = new Label();
            label10 = new Label();
            btHistorico = new Button();
            pictureBox1 = new PictureBox();
            label11 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // btUsuarios
            // 
            btUsuarios.Location = new Point(668, 80);
            btUsuarios.Name = "btUsuarios";
            btUsuarios.Size = new Size(98, 48);
            btUsuarios.TabIndex = 0;
            btUsuarios.Text = "Usuários";
            btUsuarios.UseVisualStyleBackColor = true;
            btUsuarios.Click += btUsuarios_Click;
            // 
            // btVeiculos
            // 
            btVeiculos.Location = new Point(800, 80);
            btVeiculos.Name = "btVeiculos";
            btVeiculos.Size = new Size(97, 48);
            btVeiculos.TabIndex = 1;
            btVeiculos.Text = "Veículos";
            btVeiculos.UseVisualStyleBackColor = true;
            btVeiculos.Click += btVeiculos_Click;
            // 
            // layoutCalendar
            // 
            layoutCalendar.Location = new Point(12, 157);
            layoutCalendar.Margin = new Padding(0);
            layoutCalendar.Name = "layoutCalendar";
            layoutCalendar.Size = new Size(899, 465);
            layoutCalendar.TabIndex = 2;
            // 
            // btProximoMes
            // 
            btProximoMes.Location = new Point(822, 7);
            btProximoMes.Name = "btProximoMes";
            btProximoMes.Size = new Size(75, 48);
            btProximoMes.TabIndex = 3;
            btProximoMes.Text = ">>";
            btProximoMes.UseVisualStyleBackColor = true;
            btProximoMes.Click += btProximoMes_Click;
            // 
            // btMesAnterior
            // 
            btMesAnterior.Location = new Point(543, 7);
            btMesAnterior.Name = "btMesAnterior";
            btMesAnterior.Size = new Size(75, 48);
            btMesAnterior.TabIndex = 4;
            btMesAnterior.Text = "<<";
            btMesAnterior.UseVisualStyleBackColor = true;
            btMesAnterior.Click += btMesAnterior_Click;
            // 
            // lbMes
            // 
            lbMes.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbMes.Location = new Point(624, 7);
            lbMes.Name = "lbMes";
            lbMes.Size = new Size(181, 48);
            lbMes.TabIndex = 5;
            lbMes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(182, 113);
            label1.Name = "label1";
            label1.Size = new Size(257, 15);
            label1.TabIndex = 6;
            label1.Text = "Clique em um dia para editar os agendamentos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(182, 139);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 7;
            label2.Text = "Segunda";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(317, 139);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 8;
            label3.Text = "Terça";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 139);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 9;
            label4.Text = "Domingo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(433, 139);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 10;
            label5.Text = "Quarta";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(558, 139);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 11;
            label6.Text = "Quinta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(683, 139);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 12;
            label7.Text = "Sexta";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(800, 139);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 13;
            label8.Text = "Sábado";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(106, 14);
            label9.Name = "label9";
            label9.Size = new Size(431, 33);
            label9.TabIndex = 14;
            label9.Text = "Agenda de Reserva de Veículos";
            // 
            // lbUsuario
            // 
            lbUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbUsuario.ForeColor = Color.Black;
            lbUsuario.Location = new Point(119, 80);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(439, 20);
            lbUsuario.TabIndex = 15;
            lbUsuario.Text = "Nome de Usuário (usuario@email.com)";
            lbUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(261, 65);
            label10.Name = "label10";
            label10.Size = new Size(90, 15);
            label10.TabIndex = 16;
            label10.Text = "Usuário Logado";
            // 
            // btHistorico
            // 
            btHistorico.Location = new Point(543, 80);
            btHistorico.Name = "btHistorico";
            btHistorico.Size = new Size(97, 48);
            btHistorico.TabIndex = 17;
            btHistorico.Text = "Histórico";
            btHistorico.UseVisualStyleBackColor = true;
            btHistorico.Click += btHistorico_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-58, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(234, 147);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(127, 637);
            label11.Name = "label11";
            label11.Size = new Size(246, 15);
            label11.TabIndex = 19;
            label11.Text = "Azul - manhã , Verde - tarde,  Amarelo - noite";
            label11.Click += label11_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(317, 625);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(26, 17);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(230, 625);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(26, 17);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(150, 625);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(26, 17);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 22;
            pictureBox4.TabStop = false;
            // 
            // formCalendario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 655);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(label11);
            Controls.Add(btHistorico);
            Controls.Add(lbUsuario);
            Controls.Add(label4);
            Controls.Add(label9);
            Controls.Add(pictureBox1);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbMes);
            Controls.Add(btMesAnterior);
            Controls.Add(btProximoMes);
            Controls.Add(layoutCalendar);
            Controls.Add(btVeiculos);
            Controls.Add(btUsuarios);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "formCalendario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Reserva de Veículos";
            FormClosed += formCalendario_FormClosed;
            Load += formCalendario_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btUsuarios;
        private Button btVeiculos;
        private FlowLayoutPanel layoutCalendar;
        private Button btProximoMes;
        private Button btMesAnterior;
        private Label lbMes;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        public Label lbUsuario;
        private Label label10;
        private Button btHistorico;
        private PictureBox pictureBox1;
        private Label label11;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}