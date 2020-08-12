using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ecommerce.Models.acessoBD
{
    public class UserDAO
    {
        public ConexaoBD conexaoDB { get; set; }
        public UserDAO(ConexaoBD conexaoDB)
        {
            this.conexaoDB = conexaoDB;
        }

        // verifica user pelo nome
        public Users_r verifica_login(string nome, string senha)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexaoDB.ObjetoConexao;
                cmd.CommandText = "SELECT id, nome, senha FROM users_r WHERE nome = '" + nome + "';";
                conexaoDB.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    Users_r user = new Users_r();
                    while (registro.Read())
                    {
                        user.id = Convert.ToInt32(registro["id"]);
                        user.nome = Convert.ToString(registro["nome"]).Trim();
                        user.senha = Convert.ToString(registro["senha"]).Trim();
                    }
                    if (autentica(senha, user.senha))
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }

                    
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                conexaoDB.Desconectar();
            }
        }

        private static bool autentica(string senha, string senha_hash)
        {
            if (string.IsNullOrEmpty(senha_hash))
                throw new NullReferenceException("Cadastre uma senha.");
            System.Diagnostics.Debug.WriteLine("senha digitada: " + senha);

            var secrets = "dfusasf998dfspd";
            byte[] secretkeyBytes = Encoding.UTF8.GetBytes(secrets);
            var hmac = new System.Security.Cryptography.HMACSHA512(secretkeyBytes);
            var encryptedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            var sb = new StringBuilder();

            foreach (var caractere in encryptedPassword)
            {
                sb.Append(caractere.ToString("X2"));
            }

            System.Diagnostics.Debug.WriteLine("senha digitada e hashzada: " + sb.ToString());
            System.Diagnostics.Debug.WriteLine("senha hash salva no bd: " + senha_hash);

            return sb.ToString() == senha_hash;
        }

        // registra user
        public Boolean registra(string nome, string senha)
        {
            Users_r user = new Users_r();
            try
            {
                if(nome != null && senha != null) {
                    user.nome = nome;
                    user.senha = cria_hash_(senha);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conexaoDB.ObjetoConexao;
                    cmd.CommandText = "INSERT INTO users_r(nome, senha) VALUES('" + user.nome.ToString() + "','" + user.senha.ToString() + "');";
                    conexaoDB.Conectar();
                    cmd.ExecuteReader();
                    conexaoDB.Desconectar();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                conexaoDB.Desconectar();
            }
        }

        private static string cria_hash_(string senha)
        {
            var secrets = "dfusasf998dfspd";
            byte[] secretkeyBytes = Encoding.UTF8.GetBytes(secrets);
            var hmac = new System.Security.Cryptography.HMACSHA512(secretkeyBytes);
            var senha_hash_cript = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

            var sb = new StringBuilder();
            foreach (var i in senha_hash_cript)
            {
                sb.Append(i.ToString("X2"));
            }

            return sb.ToString();
        }

    }
}