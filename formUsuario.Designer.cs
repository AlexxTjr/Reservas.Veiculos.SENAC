
using System.Data.SQLite;

namespace Reservas {
    partial class formUsuario {

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
            tipoacessousuario = new DataGridViewComboBoxColumn();
            nomeusuario = new DataGridViewTextBoxColumn();
            username = new DataGridViewTextBoxColumn();
            senhausuario = new DataGridViewTextBoxColumn();
            cpfusuario = new DataGridViewTextBoxColumn();
            emailusuario = new DataGridViewTextBoxColumn();
            telefone = new DataGridViewTextBoxColumn();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(37, 9);
            label1.Name = "label1";
            label1.Size = new Size(132, 33);
            label1.TabIndex = 0;
            label1.Text = "Usuários";
            // 
            // btDeletar
            // 
            btDeletar.Location = new Point(790, 408);
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idusuario, tipoacessousuario, nomeusuario, username, senhausuario, cpfusuario, emailusuario, telefone });
            dataGridView1.Location = new Point(12, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(927, 348);
            dataGridView1.TabIndex = 9;
            dataGridView1.RowValidated += dataGridView1_RowValidated;
            // 
            // idusuario
            // 
            idusuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idusuario.HeaderText = "id";
            idusuario.Name = "idusuario";
            idusuario.ReadOnly = true;
            // 
            // tipoacessousuario
            // 
            tipoacessousuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tipoacessousuario.HeaderText = "Tipo";
            tipoacessousuario.Items.AddRange(new object[] { "Usuário", "Admin" });
            tipoacessousuario.Name = "tipoacessousuario";
            // 
            // nomeusuario
            // 
            nomeusuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeusuario.HeaderText = "Nome";
            nomeusuario.Name = "nomeusuario";
            // 
            // username
            // 
            username.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            username.HeaderText = "UserName";
            username.Name = "username";
            // 
            // senhausuario
            // 
            senhausuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            senhausuario.HeaderText = "Senha";
            senhausuario.Name = "senhausuario";
            // 
            // cpfusuario
            // 
            cpfusuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cpfusuario.HeaderText = "CPF";
            cpfusuario.MaxInputLength = 11;
            cpfusuario.Name = "cpfusuario";
            cpfusuario.Resizable = DataGridViewTriState.False;
            // 
            // emailusuario
            // 
            emailusuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            emailusuario.HeaderText = "Email";
            emailusuario.Name = "emailusuario";
            // 
            // telefone
            // 
            telefone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            telefone.HeaderText = "Telefone";
            telefone.Name = "telefone";
            // 
            // button1
            // 
            button1.Location = new Point(662, 408);
            button1.Name = "button1";
            button1.Size = new Size(85, 30);
            button1.TabIndex = 13;
            button1.Text = "Fechar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // formUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 450);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(btDeletar);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "formUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuários";
            Load += formUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private Button btDeletar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idusuario;
        private DataGridViewComboBoxColumn tipoacessousuario;
        private DataGridViewTextBoxColumn nomeusuario;
        private DataGridViewTextBoxColumn username;
        private DataGridViewTextBoxColumn senhausuario;
        private DataGridViewTextBoxColumn cpfusuario;
        private DataGridViewTextBoxColumn emailusuario;
        private DataGridViewTextBoxColumn telefone;
        private Button button1;
    }
}
