using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Reservas {
    public partial class formCalendario : Form
    {
        static int month;
        static int year;
        Dictionary<int, PainelDia> listaDias = new Dictionary<int, PainelDia>();
        static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database\\reservas.db");
        string cs = $"URI=file:{databasePath};";
        SQLiteDataReader dr;
        public bool userEhAdmin = false;

        public formCalendario()
        {
            InitializeComponent();
        }
        private void formCalendario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //bloqueio de acesso para usuarios não admin
        private void btUsuarios_Click(object sender, EventArgs e)
        {
            if (userEhAdmin)
            {
                formUsuario modalForm = new formUsuario();
                modalForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário sem permissão", "Erro");
            }

        }
        private void btVeiculos_Click(object sender, EventArgs e)
        {
            if (userEhAdmin)
            {
                formVeiculo modalForm = new formVeiculo();
                modalForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário sem permissão", "Erro");
            }
        }

        private void btHistorico_Click(object sender, EventArgs e)
        {
            if (userEhAdmin)
            {
                formHistorico modalForm = new formHistorico();
                modalForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário sem permissão", "Erro");
            }
        }

        public void ConstruirCalendario()
        {
            lbMes.Text = GetFullMonthDate();
            layoutCalendar.Controls.Clear();

            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            DateTime endOfTheMonth = startOfTheMonth.AddDays(daysInMonth - 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d")) + 1;
            string firstDayOfMonthFormatted = startOfTheMonth.ToString("yyyy-MM-dd");
            string lastDayOfMonthFormatted = endOfTheMonth.ToString("yyyy-MM-dd");

            //criando paineis vazios pra preencher espaço até o primeiro dia do mes
            for (int i = 1; i < dayoftheweek; i++)
            {
                PainelDia dia = new PainelDia();
                dia.Inicializar();
                layoutCalendar.Controls.Add(dia);
            }

            //criando os paineis dos dias do mes
            listaDias.Clear();
            for (int i = 1; i <= days; i++)
            {
                PainelDia dia = new PainelDia();
                dia.Inicializar(i, month, year);
                layoutCalendar.Controls.Add(dia);
                listaDias.Add(i, dia);
            }

            //busca no sqlite e lança os dados na tabela
            var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "select agenda.*,veiculo.descricao,turno.turno,situacao.situacao,usuario.nomeusuario,veiculo.placa from agenda " +
                "left join veiculo on veiculo.idveiculo = agenda.idveiculo " +
                "left join turno on turno.idturno = agenda.idturno " +
                "left join situacao on situacao.idsituacao = agenda.idsituacao " +
                "left join usuario on usuario.idusuario = agenda.idusuario " +
                "where agenda.idsituacao = 1 and " +
                "((datareserva   between '" + firstDayOfMonthFormatted + "' and '" + lastDayOfMonthFormatted + "') " +
                "   or (datadevolucao between '" + firstDayOfMonthFormatted + "' and '" + lastDayOfMonthFormatted + "')) ";

            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string reserva = dr.GetString(dr.GetOrdinal("datareserva"));
                string devolucao = dr.GetString(dr.GetOrdinal("datadevolucao"));
                string desc = "";
                string placa = "";
                try
                {
                    desc = dr.GetString(dr.GetOrdinal("descricao"));
                    placa = dr.GetString(dr.GetOrdinal("placa"));

                }
                catch
                {
                    desc = "Excesão";
                    placa = "Raridade";
                }
               
                string turno = dr.GetString(dr.GetOrdinal("turno"));
                string placa = dr.GetString(dr.GetOrdinal("placa"));

                DateTime dataAgenda;
                DateTime dataDevolucao;

                DateTime.TryParseExact(reserva, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataAgenda);
                DateTime.TryParseExact(devolucao, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataDevolucao);

                int labelLivre = 0;

                //esse loop descobre uma sequencia de labels livres nos dias que vai marcar o agendamento no calendario
                for (DateTime currentDate = dataAgenda; currentDate <= dataDevolucao; currentDate = currentDate.AddDays(1))
                {
                    if (currentDate >= startOfTheMonth && currentDate <= endOfTheMonth)
                    {
                        int menorLabelDesteDia = listaDias[currentDate.Day].GetPrimeiraLabelLivre();
                        if (labelLivre < menorLabelDesteDia)
                        {
                            labelLivre = menorLabelDesteDia;
                        }
                    }
                }
                int cont = 0;
                //esse loop preenche essas labels livres, se tiver espaço
                if (labelLivre > 0)
                {
                    for (DateTime currentDate = dataAgenda; currentDate <= dataDevolucao; currentDate = currentDate.AddDays(1))
                    {
                        if (currentDate >= startOfTheMonth && currentDate <= endOfTheMonth)
                        {
                            string descricao = "";
                            if (cont == 0)
                            {
                                descricao = desc + " " + placa + " " + turno;
                            }
                            listaDias[currentDate.Day].PreencheLabel(labelLivre, descricao, turno);
                            cont++;
                        }
                    }
                }
            }

            foreach (KeyValuePair<int, PainelDia> kvp in listaDias)
            {
                PainelDia painelDia = kvp.Value;
                painelDia.EsconderLabelsNaoPreenchidas();
            }
        }

        private void formCalendario_Load(object sender, EventArgs e)
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
            ConstruirCalendario();
        }
        private void btMesAnterior_Click(object sender, EventArgs e)
        {
            month--;
            if (month < 1)
            {
                month = 12;
                year--;
            }
            ConstruirCalendario();
        }

        private void btProximoMes_Click(object sender, EventArgs e)
        {
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            ConstruirCalendario();
        }
        public static string GetFullMonthDate()
        {
            DateTime currentDate = new DateTime(year, month, 1);
            CultureInfo culture = new CultureInfo("pt-BR");
            string monthName = culture.DateTimeFormat.GetMonthName(month);
            monthName = culture.TextInfo.ToTitleCase(monthName);
            return $"{monthName} {year}";
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}