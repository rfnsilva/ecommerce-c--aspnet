using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
 
namespace ecommerce.Models.acessoBD
{
    public class RestritoDAO
    {
        public ConexaoBD conexaoDB { get; set; }
        public RestritoDAO(ConexaoBD conexaoDB)
        {
            this.conexaoDB = conexaoDB;
        }

        // TODOS OS PRODUTOS
        public List<Produto> retorna_produtos()
        {
            List<Produto> nota = new List<Produto>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_RETORNA_PRODUTOS");
                cmd.Connection = conexaoDB.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conexaoDB.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        Produto notaFiscalSaida = new Produto();

                        notaFiscalSaida.id = Convert.ToInt32(registro["id"]);
                        notaFiscalSaida.nome = Convert.ToString(registro["nome"]).Trim();
                        notaFiscalSaida.descricao = Convert.ToString(registro["descricao"]).Trim();
                        notaFiscalSaida.imagem = Convert.ToString(registro["imagem"]).Trim();
                        notaFiscalSaida.valor = Convert.ToInt32(registro["valor"]);
                        notaFiscalSaida.fav = Convert.ToString(registro["fav"]).Trim();

                        nota.Add(notaFiscalSaida);
                    }

                }
                return nota;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conexaoDB.Desconectar();
            }

        }

        // RETORNA DESTAQUES
        public List<Produto> retorna_destaques()
        {

            List<Produto> nota = new List<Produto>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_RETORNA_DESTAQUE_ID");
                cmd.Connection = conexaoDB.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conexaoDB.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        Produto notaFiscalSaida = new Produto();

                        notaFiscalSaida.id = Convert.ToInt32(registro["id"]);
                        notaFiscalSaida.nome = Convert.ToString(registro["nome"]).Trim();
                        notaFiscalSaida.imagem = Convert.ToString(registro["imagem"]).Trim();
                        notaFiscalSaida.valor = Convert.ToInt32(registro["valor"]);
                        notaFiscalSaida.destaque = Convert.ToString(registro["destaque"]).Trim();

                        nota.Add(notaFiscalSaida);
                    }
                }
                return nota;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conexaoDB.Desconectar();
            }

        }

        // UM PRODUTOS
        public Produto retorna_produto(int id)
        {

            Produto notaFiscalSaida = new Produto();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_RETORNA_PRODUTO_ID");
                cmd.Connection = conexaoDB.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);

                conexaoDB.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        notaFiscalSaida.id = Convert.ToInt32(registro["id"]);
                        notaFiscalSaida.nome = Convert.ToString(registro["nome"]).Trim();
                        notaFiscalSaida.descricao = Convert.ToString(registro["descricao"]).Trim();
                        notaFiscalSaida.imagem = Convert.ToString(registro["imagem"]).Trim();
                        notaFiscalSaida.valor = Convert.ToInt32(registro["valor"]);
                    }

                }
                return notaFiscalSaida;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conexaoDB.Desconectar();
            }

        }

        public List<Carrinho> retorna_card(int id_user)
        {
            List<Carrinho> nota = new List<Carrinho>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_RETORNA_CARD");
                cmd.Connection = conexaoDB.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conexaoDB.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        Carrinho notaFiscalSaida = new Carrinho();

                        notaFiscalSaida.id = Convert.ToInt32(registro["id"]);
                        notaFiscalSaida.nome = Convert.ToString(registro["nome"]).Trim();
                        notaFiscalSaida.descricao = Convert.ToString(registro["descricao"]).Trim();
                        notaFiscalSaida.valor = Convert.ToInt32(registro["valor"]);

                        nota.Add(notaFiscalSaida);
                    }

                }
                return nota;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conexaoDB.Desconectar();
            }
        }

            public bool regitra_prod_card(int id_user, int id_prod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_REGISTRA_CARD");
                cmd.Connection = conexaoDB.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id_user);
                cmd.Parameters.AddWithValue("@PRODUTO", id_prod);

                conexaoDB.Conectar();
                cmd.ExecuteReader();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conexaoDB.Desconectar();
            }
        }

        // TODOS OS PRODUTOS
        public List<Produto> retorna_fav()
        {
            List<Produto> nota = new List<Produto>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_RETORNA_FAV");
                cmd.Connection = conexaoDB.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conexaoDB.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        Produto notaFiscalSaida = new Produto();

                        notaFiscalSaida.id = Convert.ToInt32(registro["id"]);
                        notaFiscalSaida.nome = Convert.ToString(registro["nome"]).Trim();
                        notaFiscalSaida.descricao = Convert.ToString(registro["descricao"]).Trim();
                        notaFiscalSaida.imagem = Convert.ToString(registro["imagem"]).Trim();
                        notaFiscalSaida.valor = Convert.ToInt32(registro["valor"]);
                        notaFiscalSaida.fav = Convert.ToString(registro["fav"]).Trim();

                        nota.Add(notaFiscalSaida);
                    }

                }
                return nota;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conexaoDB.Desconectar();
            }

        }

        // SLIDERS
        public List<Slider> retorna_sliders()
        {
            List<Slider> nota = new List<Slider>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_RETORNA_SLIDERS");
                cmd.Connection = conexaoDB.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conexaoDB.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        Slider notaFiscalSaida = new Slider();

                        notaFiscalSaida.id = Convert.ToInt32(registro["id"]);
                        notaFiscalSaida.descricao = Convert.ToString(registro["descricao"]).Trim();
                        notaFiscalSaida.imagem = Convert.ToString(registro["imagem"]).Trim();

                        nota.Add(notaFiscalSaida);
                    }

                }
                return nota;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conexaoDB.Desconectar();
            }

        }

        // CATEGORIAS
        public List<Categoria> retorna_categorias()
        {
            List<Categoria> nota = new List<Categoria>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_RETORNA_CATEGORIAS");
                cmd.Connection = conexaoDB.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conexaoDB.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        Categoria notaFiscalSaida = new Categoria();

                        notaFiscalSaida.id = Convert.ToInt32(registro["id"]);
                        notaFiscalSaida.nome = Convert.ToString(registro["nome"]).Trim();
                        notaFiscalSaida.descricao = Convert.ToString(registro["descricao"]).Trim();
                        notaFiscalSaida.imagem = Convert.ToString(registro["imagem"]).Trim();

                        nota.Add(notaFiscalSaida);
                    }

                }
                return nota;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conexaoDB.Desconectar();
            }

        }


        // SOCIAIS
        public List<Social> retorna_sociais()
        {
            List<Social> nota = new List<Social>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_RETORNA_SOCIAIS");
                cmd.Connection = conexaoDB.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conexaoDB.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    while (registro.Read())
                    {
                        Social notaFiscalSaida = new Social();

                        notaFiscalSaida.id = Convert.ToInt32(registro["id"]);
                        notaFiscalSaida.nome = Convert.ToString(registro["nome"]).Trim();
                        notaFiscalSaida.descricao = Convert.ToString(registro["descricao"]).Trim();
                        notaFiscalSaida.imagem = Convert.ToString(registro["imagem"]).Trim();

                        nota.Add(notaFiscalSaida);
                    }

                }
                return nota;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            finally
            {
                conexaoDB.Desconectar();
            }

        }

        public Carrinho pega_carrinho()
        {
            return null;
        }
    }
}