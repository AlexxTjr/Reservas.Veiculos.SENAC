namespace Reservas {
    partial class PainelDia {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            lbDia = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            bindingSource1 = new BindingSource(components);
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // lbDia
            // 
            lbDia.BackColor = Color.Transparent;
            lbDia.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbDia.Location = new Point(105, 53);
            lbDia.Margin = new Padding(0);
            lbDia.Name = "lbDia";
            lbDia.Size = new Size(23, 18);
            lbDia.TabIndex = 0;
            lbDia.Text = "9";
            lbDia.TextAlign = ContentAlignment.MiddleRight;
            lbDia.Click += AbrirFormAgenda;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(128, 71);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.Click += AbrirFormAgenda;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(128, 128, 255);
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(128, 17);
            label1.TabIndex = 0;
            label1.Tag = "";
            label1.Text = "label1";
            label1.Click += AbrirFormAgenda;
            // 
            // label2
            // 
            label2.BackColor = Color.Turquoise;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(0, 17);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(128, 17);
            label2.TabIndex = 1;
            label2.Text = "label2";
            label2.Click += AbrirFormAgenda;
            // 
            // label3
            // 
            label3.BackColor = Color.Lime;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(0, 34);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(128, 18);
            label3.TabIndex = 2;
            label3.Text = "label3";
            label3.Click += AbrirFormAgenda;
            // 
            // label4
            // 
            label4.BackColor = Color.Yellow;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Location = new Point(0, 52);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(128, 18);
            label4.TabIndex = 3;
            label4.Text = "label4";
            label4.Click += AbrirFormAgenda;
            // 
            // PainelDia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lbDia);
            Controls.Add(flowLayoutPanel1);
            Cursor = Cursors.Hand;
            Margin = new Padding(0);
            Name = "PainelDia";
            Size = new Size(128, 70);
            Click += AbrirFormAgenda;
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbDia;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Label label2;
        private BindingSource bindingSource1;
        private Label label3;
        private Label label4;
    }
}
