
using System.Data.SQLite;

namespace Reservas {
    partial class formHistorico {

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
            comboVeiculos = new ComboBox();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            nome = new DataGridViewTextBoxColumn();
            veiculo = new DataGridViewTextBoxColumn();
            turno = new DataGridViewTextBoxColumn();
            datareserva = new DataGridViewTextBoxColumn();
            datadevolucao = new DataGridViewTextBoxColumn();
            situacao = new DataGridViewTextBoxColumn();
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
            label1.Size = new Size(136, 33);
            label1.TabIndex = 0;
            label1.Text = "Histórico";
            // 
            // comboVeiculos
            // 
            comboVeiculos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboVeiculos.FormattingEnabled = true;
            comboVeiculos.Location = new Point(188, 19);
            comboVeiculos.Name = "comboVeiculos";
            comboVeiculos.Size = new Size(199, 23);
            comboVeiculos.TabIndex = 10;
            comboVeiculos.DropDownClosed += comboVeiculos_DropDownClosed;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.CausesValidation = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, nome, veiculo, turno, datareserva, datadevolucao, situacao });
            dataGridView1.Location = new Point(12, 54);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.Size = new Size(730, 390);
            dataGridView1.TabIndex = 11;
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
            situacao.Name = "situacao";
            // 
            // button1
            // 
            button1.Location = new Point(667, 450);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Fechar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // formHistorico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 480);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(comboVeiculos);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "formHistorico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Histórico de Reservas";
            Load += formHistorico_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private ComboBox comboVeiculos;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nome;
        private DataGridViewTextBoxColumn veiculo;
        private DataGridViewTextBoxColumn turno;
        private DataGridViewTextBoxColumn datareserva;
        private DataGridViewTextBoxColumn datadevolucao;
        private DataGridViewTextBoxColumn situacao;
        private Button button1;
    }
}
