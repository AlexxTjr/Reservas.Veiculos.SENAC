using System.Data.SQLite;
using System.Diagnostics;

namespace Reservas {
    public partial class formUsuario : Form {

        static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database\\reservas.db");
        string cs = $"URI=file:{databasePath};";
        bool canSave = false;

        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;

        public formUsuario() {
            InitializeComponent();
        }

        private void ShowData() {
            canSave = false;
            dataGridView1.Rows.Clear();
            var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT usuario.*,acesso.tipoacesso FROM usuario left join acesso on acesso.idacesso = usuario.idacessousuario order by usuario.idusuario";
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) {
                dataGridView1.Rows.Insert(0, dr.GetInt32(0), dr.GetString(8), dr.GetString(4), dr.GetString(3), dr.GetString(2), dr.GetString(5), dr.GetString(6), dr.GetString(7));
            }
            canSave = true;
        }

        private void formUsuario_Load(object sender, EventArgs e) {
            ShowData();
        }

        private int InsertOrUpdateData(int id, int acesso, string senha, string nome, string username, string cpf, string email, string telefone) {
            var con = new SQLiteConnection(cs);
            con.Open();

            string sql;
            int newId = 0;

            if (id > 0) {
                sql = "UPDATE usuario SET senhausuario = @senha, nomeusuario = @nome, username = @username, idacessousuario = @acesso, cpfusuario = @cpf, telefone = @telefone, emailusuario = @email WHERE idusuario = @id";
            }
            else {
                sql = "INSERT INTO usuario (senhausuario, nomeusuario,username, cpfusuario, emailusuario, idacessousuario, telefone) VALUES (@senha, @nome, @username, @cpf, @email, @acesso, @telefone); SELECT last_insert_rowid();";
            }

            using (var cmd = new SQLiteCommand(sql, con)) {
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@acesso", acesso);
                cmd.Parameters.AddWithValue("@senha", senha);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@telefone", telefone);

                if (id > 0) {
                    cmd.Parameters.AddWithValue("@id", id);
                }

                if (id == 0) {
                    newId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0) {
                        Debug.WriteLine("Operation successful!");
                    }
                }
            }

            con.Close();
            return newId;
        }


        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e) {
            if (canSave && e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count) {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                DataGridViewComboBoxCell comboBoxCell = row.Cells[1] as DataGridViewComboBoxCell;
                int tipoUsuario = 0;
                if (comboBoxCell != null) {
                    if (comboBoxCell.Value != null) {
                        tipoUsuario = comboBoxCell.Items.IndexOf(comboBoxCell.Value);
                    }
                }
                tipoUsuario++;
                if (tipoUsuario == 1) {
                    row.Cells[1].Value = "Usuário";
                }

                int id = row.Cells[0].Value != null ? Convert.ToInt32(row.Cells[0].Value) : 0;
                string nome = row.Cells[2].Value?.ToString() ?? string.Empty;
                string username = row.Cells[3].Value?.ToString() ?? string.Empty;
                string senha = row.Cells[4].Value?.ToString() ?? string.Empty;
                string cpf = row.Cells[5].Value?.ToString() ?? string.Empty;
                string email = row.Cells[6].Value?.ToString() ?? string.Empty;
                string telefone = row.Cells[7].Value?.ToString() ?? string.Empty;

                if (nome != string.Empty || senha != string.Empty || cpf != string.Empty || email != string.Empty || telefone != string.Empty) {
                    int newId = InsertOrUpdateData(id, tipoUsuario, senha, nome, username, cpf, email, telefone);
                    if (newId > 0) {
                        row.Cells[0].Value = newId;
                    }
                }
            }
        }

        private void btDeletar_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedCells.Count > 0) {
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    int id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);
                    DeleteData(id);
                }
            }
        }
        private void DeleteData(int id) {
            var con = new SQLiteConnection(cs);
            con.Open();

            string sql = "DELETE FROM usuario WHERE idusuario = @id";

            using (var cmd = new SQLiteCommand(sql, con)) {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                ShowData();
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
