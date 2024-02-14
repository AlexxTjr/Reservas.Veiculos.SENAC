
using System.Data.SQLite;

namespace Reservas {
    partial class formAgenda {

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
            id = new DataGridViewTextBoxColumn();
            nome = new DataGridViewComboBoxColumn();
            veiculo = new DataGridViewComboBoxColumn();
            turno = new DataGridViewComboBoxColumn();
            datareserva = new DataGridViewTextBoxColumn();
            datadevolucao = new DataGridViewTextBoxColumn();
            situacao = new DataGridViewComboBoxColumn();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(403, 33);
            label1.TabIndex = 0;
            label1.Text = "Agenda para o dia 01/01/2000";
            // 
            // btDeletar
            // 
            btDeletar.Location = new Point(671, 408);
            btDeletar.Name = "btDeletar";
            btDeletar.Size = new Size(99, 30);
            btDeletar.TabIndex = 7;
            btDeletar.Text = "Deletar";
            btDeletar.UseVisualStyleBackColor = true;
            btDeletar.Click += btDeletar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, nome, veiculo, turno, datareserva, datadevolucao, situacao });
            dataGridView1.Location = new Point(27, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(743, 329);
            dataGridView1.TabIndex = 9;
            dataGridView1.RowValidating += dataGridView1_RowValidating;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id.FillWeight = 25F;
            id.HeaderText = "id";
            id.Name = "id";
            id.ReadOnly = true;
            id.Resizable = DataGridViewTriState.False;
            // 
            // nome
            // 
            nome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nome.HeaderText = "Nome";
            nome.Name = "nome";
            // 
            // veiculo
            // 
            veiculo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            veiculo.HeaderText = "Veículo";
            veiculo.Name = "veiculo";
            // 
            // turno
            // 
            turno.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            turno.HeaderText = "Turno";
            turno.Items.AddRange(new object[] { "Manhã", "Tarde", "Noite" });
            turno.Name = "turno";
            // 
            // datareserva
            // 
            datareserva.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datareserva.HeaderText = "Data de Reserva";
            datareserva.Name = "datareserva";
            // 
            // datadevolucao
            // 
            datadevolucao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datadevolucao.HeaderText = "Data de Devolução";
            datadevolucao.Name = "datadevolucao";
            // 
            // situacao
            // 
            situacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            situacao.HeaderText = "Situação";
            situacao.Items.AddRange(new object[] { "Reservado", "Cancelado" });
            situacao.Name = "situacao";
            // 
            // button1
            // 
            button1.Location = new Point(588, 408);
            button1.Name = "button1";
            button1.Size = new Size(77, 30);
            button1.TabIndex = 13;
            button1.Text = "Fechar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // formAgenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 450);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(btDeletar);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "formAgenda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agendamento de Veículo";
            FormClosed += formAgenda_FormClosed;
            Load += formAgenda_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private Button btDeletar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewComboBoxColumn nome;
        private DataGridViewComboBoxColumn veiculo;
        private DataGridViewComboBoxColumn turno;
        private DataGridViewTextBoxColumn datareserva;
        private DataGridViewTextBoxColumn datadevolucao;
        private DataGridViewComboBoxColumn situacao;
        private Button button1;
    }
}
