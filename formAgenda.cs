using System.Data.SQLite;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Reservas {
    public partial class formAgenda : Form {

        static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database\\reservas.db");
        string cs = $"URI=file:{databasePath};";
        bool canSave = false;
        string data;
        List<string> usuarios;
        List<string> veiculos;

        SQLiteDataReader dr;

        public formAgenda(string _data) {
            data = ConvertToYYYYMMDD(_data);
            usuarios = GetUsuarios();
            veiculos = GetVeiculos();
            InitializeComponent();
            label1.Text = "Agenda para o dia " + _data;
        }
        private List<string> GetUsuarios() {
            List<string> userStrings = new List<string>();

            using (SQLiteConnection con = new SQLiteConnection(cs)) {
                con.Open();
                string query = "SELECT idusuario, nomeusuario FROM usuario";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con)) {
                    using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            int idusuario = reader.GetInt32(0);
                            string nomeusuario = reader.GetString(1);
                            string formattedString = $"{idusuario} - {nomeusuario}";
                            userStrings.Add(formattedString);
                        }
                    }
                }
            }

            return userStrings;
        }
        private List<string> GetVeiculos() {
            List<string> veiculoStrings = new List<string>();

            using (SQLiteConnection con = new SQLiteConnection(cs)) {
                con.Open();
                string query = "SELECT idveiculo, descricao, placa FROM veiculo";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con)) {
                    using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            int idveiculo = reader.GetInt32(0);
                            string descricao = reader.GetString(1);
                            string placa = reader.GetString(2);
                            string formattedString = $"{idveiculo} - {descricao} ({placa})";
                            veiculoStrings.Add(formattedString);
                        }
                    }
                }
            }

            return veiculoStrings;
        }

        public void ShowData() {
            canSave = false;
            dataGridView1.Rows.Clear();
            var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "select agenda.idagenda,veiculo.idveiculo,veiculo.descricao,turno.turno,situacao.situacao," +
                "usuario.nomeusuario,usuario.idusuario,agenda.datadevolucao,agenda.datareserva,veiculo.placa from agenda " +
                "left join veiculo on veiculo.idveiculo = agenda.idveiculo " +
                "left join turno on turno.idturno = agenda.idturno " +
                "left join situacao on situacao.idsituacao = agenda.idsituacao " +
                "left join usuario on usuario.idusuario = agenda.idusuario " +
                "where '" + data + "' between agenda.datareserva   and agenda.datadevolucao  ";
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();
            while (dr.Read()) {
                string nome = $"{dr.GetInt32(6)} - {dr.GetString(5)}";
                string veiculo = dr.GetInt32(1) + " - " + dr.GetString(2) + " (" + dr.GetString(9) + ")";
                dataGridView1.Rows.Insert(0, dr.GetInt32(0), nome, veiculo, dr.GetString(3), ConvertToDDMMYYYY(dr.GetString(8)), ConvertToDDMMYYYY(dr.GetString(7)), dr.GetString(4));
            }
            canSave = true;
        }

        private int InsertOrUpdateData(int id, string idusuario, string veiculo, int turno, string datadevolucao, string dataagendamento, int situacao) {

            veiculo = veiculo.Split('-')[0].Trim();
            idusuario = idusuario.Split('-')[0].Trim();

            dataagendamento = ConvertToYYYYMMDD(dataagendamento);
            datadevolucao = ConvertToYYYYMMDD(datadevolucao);

            DateTime dtagenda = DateTime.ParseExact(dataagendamento, "yyyy-MM-dd", null);
            DateTime dtdevol = DateTime.ParseExact(datadevolucao, "yyyy-MM-dd", null);
            if (dtagenda > dtdevol) {
                datadevolucao = dataagendamento;
            }

            var con = new SQLiteConnection(cs);
            con.Open();

            string sql;
            int newId = 0;

            if (id > 0) {
                sql = "UPDATE agenda SET idveiculo = @veiculo, idusuario = @idusuario, idturno = @turno, datadevolucao = @datadevolucao,datareserva = @datareserva, idsituacao = @situacao WHERE idagenda = @id";
            }
            else {
                sql = "INSERT INTO agenda (idveiculo, idusuario, idturno, datadevolucao, idsituacao, datareserva) VALUES (@veiculo, @idusuario, @turno, @datadevolucao, @situacao, @datareserva); SELECT last_insert_rowid();";
            }

            using (var cmd = new SQLiteCommand(sql, con)) {
                cmd.Parameters.AddWithValue("@veiculo", veiculo);
                cmd.Parameters.AddWithValue("@idusuario", idusuario);
                cmd.Parameters.AddWithValue("@turno", turno);
                cmd.Parameters.AddWithValue("@datadevolucao", datadevolucao);
                cmd.Parameters.AddWithValue("@situacao", situacao);
                cmd.Parameters.AddWithValue("@datareserva", dataagendamento);

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
        static string ConvertToYYYYMMDD(string inputDate) {
            if (string.IsNullOrEmpty(inputDate)) {
                return string.Empty;
            }

            DateTime parsedDate;
            if (DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate)) {
                return parsedDate.ToString("yyyy-MM-dd");
            }

            return string.Empty;
        }

        static string ConvertToDDMMYYYY(string inputDate) {
            if (string.IsNullOrEmpty(inputDate)) {
                return string.Empty;
            }

            DateTime parsedDate;
            if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedDate)) {
                return parsedDate.ToString("dd/MM/yyyy");
            }

            return string.Empty;
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

            string sql = "DELETE FROM agenda WHERE idagenda = @id";

            using (var cmd = new SQLiteCommand(sql, con)) {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                ShowData();
            }

            con.Close();
        }
        private void formAgenda_Load(object sender, EventArgs e) {
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[2]).DataSource = veiculos;
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[1]).DataSource = usuarios;

            ((DataGridViewComboBoxColumn)dataGridView1.Columns[2]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            ((DataGridViewComboBoxColumn)dataGridView1.Columns[1]).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            ShowData();
        }

        private void formAgenda_FormClosed(object sender, FormClosedEventArgs e) {
            foreach (Form form in Application.OpenForms) {
                if (form is formCalendario fc) {
                    fc.ConstruirCalendario();
                    break;
                }
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e) {
            if (canSave && e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count) {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                DataGridViewComboBoxCell comboBoxCell = row.Cells[3] as DataGridViewComboBoxCell;
                int turno = 0;
                if (comboBoxCell != null) {
                    if (comboBoxCell.Value != null) {
                        turno = comboBoxCell.Items.IndexOf(comboBoxCell.Value);
                    }
                }
                turno++;
                if (turno == 1) {
                    row.Cells[3].Value = "Manhã";
                }

                DataGridViewComboBoxCell comboBoxCell2 = row.Cells[6] as DataGridViewComboBoxCell;
                int situacao = 0;
                if (comboBoxCell2 != null) {
                    if (comboBoxCell2.Value != null) {
                        situacao = comboBoxCell2.Items.IndexOf(comboBoxCell2.Value);
                    }
                }
                situacao++;
                if (situacao == 1) {
                    row.Cells[6].Value = "Reservado";
                }

                int id = row.Cells[0].Value != null ? Convert.ToInt32(row.Cells[0].Value) : 0;
                string nome = row.Cells[1].Value?.ToString() ?? string.Empty;
                string veiculo = row.Cells[2].Value?.ToString() ?? string.Empty;
                string datadevolucao = row.Cells[5].Value?.ToString() ?? string.Empty;
                string dataagendamento = row.Cells[4].Value?.ToString() ?? string.Empty;

                if (id == 0) {
                    DialogResult result = MessageBox.Show("Tem certeza que deseja criar essa reserva?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No) {
                        return;
                    }
                }

                if (nome != string.Empty || veiculo != string.Empty || datadevolucao != string.Empty) {
                    int newId = InsertOrUpdateData(id, nome, veiculo, turno, datadevolucao, dataagendamento, situacao);
                    if (newId > 0) {
                        row.Cells[0].Value = newId;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
