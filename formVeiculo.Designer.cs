
using System.Data.SQLite;

namespace Reservas {
    partial class formVeiculo {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            btDeletar = new Button();
            dataGridView1 = new DataGridView();
            idusuario = new DataGridViewTextBoxColumn();
            descricao = new DataGridViewTextBoxColumn();
            placa = new DataGridViewTextBoxColumn();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(24, 12);
            label1.Name = "label1";
            label1.Size = new Size(128, 33);
            label1.TabIndex = 0;
            label1.Text = "Veículos";
            // 
            // btDeletar
            // 
            btDeletar.Location = new Point(237, 326);
            btDeletar.Name = "btDeletar";
            btDeletar.Size = new Size(110, 30);
            btDeletar.TabIndex = 7;
            btDeletar.Text = "Deletar";
            btDeletar.UseVisualStyleBackColor = true;
            btDeletar.Click += btDeletar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idusuario, descricao, placa });
            dataGridView1.Location = new Point(12, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(364, 272);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.RowValidated += dataGridView1_RowValidated;
            // 
            // idusuario
            // 
            idusuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idusuario.HeaderText = "id";
            idusuario.Name = "idusuario";
            idusuario.ReadOnly = true;
            // 
            // descricao
            // 
            descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descricao.HeaderText = "Descrição";
            descricao.Name = "descricao";
            // 
            // placa
            // 
            placa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            placa.HeaderText = "Placa";
            placa.Name = "placa";
            // 
            // button1
            // 
            button1.Location = new Point(139, 326);
            button1.Name = "button1";
            button1.Size = new Size(79, 30);
            button1.TabIndex = 13;
            button1.Text = "Fechar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // formVeiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 368);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(btDeletar);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "formVeiculo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Veículos";
            Load += formVeiculo_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private Button btDeletar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idusuario;
        private DataGridViewTextBoxColumn descricao;
        private DataGridViewTextBoxColumn placa;
        private Button button1;
    }
}
