using System.Data.SQLite;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Reservas {
    public partial class formHistorico : Form {

        static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database\\reservas.db");
        string cs = $"URI=file:{databasePath};";

        SQLiteDataReader dr;
        List<string> veiculos;

        public formHistorico() {
            InitializeComponent();
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

        private void ShowData(string veiculo) {
            dataGridView1.Rows.Clear();
            var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "select agenda.idagenda,veiculo.idveiculo,veiculo.descricao,turno.turno,situacao.situacao," +
                "usuario.nomeusuario,usuario.idusuario,agenda.datadevolucao,agenda.datareserva,veiculo.placa from agenda " +
                "left join veiculo on veiculo.idveiculo = agenda.idveiculo " +
                "left join turno on turno.idturno = agenda.idturno " +
                "left join situacao on situacao.idsituacao = agenda.idsituacao " +
                "left join usuario on usuario.idusuario = agenda.idusuario " +
                "where agenda.idveiculo = " + veiculo;
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read()) {
                string nome = $"{dr.GetInt32(6)} - {dr.GetString(5)}";
                string v = dr.GetInt32(1) + " - " + dr.GetString(2) + " (" + dr.GetString(9) + ")";
                dataGridView1.Rows.Insert(0, dr.GetInt32(0), nome, v, dr.GetString(3), ConvertToDDMMYYYY(dr.GetString(8)), ConvertToDDMMYYYY(dr.GetString(7)), dr.GetString(4));
            }
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
        private void formHistorico_Load(object sender, EventArgs e) {
            //comboVeiculos.DataSource = veiculos;
            veiculos = GetVeiculos();
            comboVeiculos.Items.Add("Escolha uma opção");
            foreach (string v in veiculos) {
                comboVeiculos.Items.Add(v);
            }
            comboVeiculos.SelectedIndex = 0;

        }

        private void comboVeiculos_DropDownClosed(object sender, EventArgs e) {

            if (comboVeiculos.SelectedIndex > 0) {
                string veiculo = comboVeiculos.Items[comboVeiculos.SelectedIndex].ToString();
                veiculo = veiculo.Split('-')[0].Trim();
                ShowData(veiculo);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
