using System.Data.SQLite;
using System.Diagnostics;

namespace Reservas {
    public partial class formVeiculo : Form {

        static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database\\reservas.db");
        string cs = $"URI=file:{databasePath};";
        bool canSave = false;

        SQLiteDataReader dr;

        public formVeiculo() {
            InitializeComponent();
        }

        private void ShowData() {
            canSave = false;
            dataGridView1.Rows.Clear();
            var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * from veiculo";
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) {
                dataGridView1.Rows.Insert(0, dr.GetInt32(0), dr.GetString(1), dr.GetString(2));
            }
            canSave = true;
        }

        private void formVeiculo_Load(object sender, EventArgs e) {
            ShowData();
        }

        private int InsertOrUpdateData(int id, string descricao, string placa) {
            var con = new SQLiteConnection(cs);
            con.Open();

            string sql;
            int newId = 0;

            if (id > 0) {
                sql = "UPDATE veiculo SET descricao = @descricao, placa = @placa WHERE idveiculo = @id";
            }
            else {
                sql = "INSERT INTO veiculo (descricao, placa) VALUES (@descricao, @placa); SELECT last_insert_rowid();";
            }

            using (var cmd = new SQLiteCommand(sql, con)) {
                cmd.Parameters.AddWithValue("@placa", placa);
                cmd.Parameters.AddWithValue("@descricao", descricao);

                if (id > 0) {
                    cmd.Parameters.AddWithValue("@id", id);
                }

                if (id == 0) {
                    newId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0) {
                        Debug.WriteLine("Sucesso!");
                    }
                }
            }

            con.Close();
            return newId;
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e) {
            if (canSave && e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count) {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                int id = row.Cells[0].Value != null ? Convert.ToInt32(row.Cells[0].Value) : 0;
                string descricao = row.Cells[1].Value?.ToString() ?? string.Empty;
                string placa = row.Cells[2].Value?.ToString() ?? string.Empty;

                if (descricao != string.Empty || placa != string.Empty) {
                    int newId = InsertOrUpdateData(id, descricao, placa);
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

            string sql = "DELETE FROM veiculo WHERE idveiculo = @id";

            using (var cmd = new SQLiteCommand(sql, con)) {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                ShowData();
            }

            con.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            // setando placa em maiusculas
            if (e.ColumnIndex == 2 && e.Value != null) {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
