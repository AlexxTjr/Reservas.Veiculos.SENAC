using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Reservas {
    public partial class formLogin : Form {
        static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database\\reservas.db");
        string cs = $"URI=file:{databasePath};";

        public formLogin() {
            InitializeComponent();
        }


        //validação do usuario e senha junto ao bd
        private void btEntrar_Click(object sender, EventArgs e) {
            string id = txtId.Text;
            string password = txtSenha.Text;
            string usuario = "";
            int idAcessoUsuario = 0;

            using (SQLiteConnection con = new SQLiteConnection(cs)) {
                con.Open();
                string query = "SELECT nomeusuario, emailusuario, idacessousuario FROM usuario WHERE username = @username AND senhausuario = @password";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con)) {
                    cmd.Parameters.AddWithValue("@username", id);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            string nomeUsuario = reader.GetString(0);
                            string emailUsuario = reader.GetString(1);

                            idAcessoUsuario = reader.GetInt32(2);
                            usuario = $"{nomeUsuario} ({emailUsuario})";
                        }
                    }
                }
            }

            //caso a pessoa nao tenha acesso ou tenha digitado errado sobe a msg box
            if (usuario != "") {
                formCalendario form = new formCalendario();
                form.lbUsuario.Text = usuario;
                if (idAcessoUsuario == 2) {
                    form.userEhAdmin = true;
                }
                form.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Id ou Senha inválidos!.");
            }
        }



    }
}
