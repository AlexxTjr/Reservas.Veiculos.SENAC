using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reservas {
    public partial class PainelDia : UserControl {

        string data;
        public Dictionary<int, Label> labels;
        public PainelDia() {
            InitializeComponent();
            labels = new Dictionary<int, Label> {
                { 1, label1 },
                { 2, label2 },
                { 3, label3 },
                { 4, label4 }
            };
        }

        public void Inicializar() {
            lbDia.Text = "";
            BorderStyle = BorderStyle.None;
            Cursor = Cursors.Default;
            EsconderLabelsNaoPreenchidas();
        }

        //lança as datas conforme calendario, ajustando finais de semana mais escuros que os dias da semana
        public void Inicializar(int dia, int mes, int ano) {
            data = string.Format("{0:D2}/{1:D2}/{2}", dia, mes, ano);
            lbDia.Text = dia.ToString();

            if (EhFimDeSemana(new DateTime(ano, mes, dia))) {
                BackColor = Color.LightGray;
            }
        }
        static bool EhFimDeSemana(DateTime date) {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        //setei as cores conforme solicitação do nairo
        public void PreencheLabel(int index, string labelText, string turno) {
            if (turno == "Manhã") {
                labels[index].BackColor = Color.Turquoise;
            }
            if (turno == "Tarde") {
                labels[index].BackColor = Color.Lime;
            }
            if (turno == "Noite") {
                labels[index].BackColor = Color.Yellow;
            }
            labels[index].Text = labelText;
            if (labelText != "") {
                labels[index].Margin = new Padding(5, 0, 0, 0);
            }
            if (index == 4) {
                lbDia.BackColor = label4.BackColor;
            }

            // colocamos um x no campo tag para marcar como preenchido,
            // mais tarde vamos esconder os labels não preenchidos
            labels[index].Tag = "x";
        }
        private void AbrirFormAgenda(object sender, EventArgs e) {
            formAgenda modalForm = new formAgenda(data);
            modalForm.ShowDialog();
        }
        public void EsconderLabelsNaoPreenchidas() {
            for (int i = 1; i <= 4; i++) {
                if (labels[i].Tag != "x") {
                    labels[i].Size = new Size(0, 17);
                }
            }
        }
        //ve o a linha livre pra preencher as datas
        public int GetPrimeiraLabelLivre() {
            int labelIndex = 0;
            for (int i = 1; i <= 4; i++) {
                if (labels[i].Tag != "x") {
                    labelIndex = i;
                    break;
                }
            }
            return labelIndex;
        }
    }
}
