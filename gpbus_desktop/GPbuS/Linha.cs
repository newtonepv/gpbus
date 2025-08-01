using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GPbuS
{
    class Linha
    {

        private String Numero;
        private String Nome;
        private String Empresa;
        private String Sentido1;
        private String Sentido2;
        private String Tipo;
        private String HrPartidaS1;
        private String HrPartidaS2;

        public Linha()
        {
        }

        public Linha(string numero, string nome, string empresa, string sentido1, string sentido2, string tipo, string hrPartidaS1, string hrPartidaS2)
        {
            Numero = numero;
            Nome = nome;
            Empresa = empresa;
            Sentido1 = sentido1;
            Sentido2 = sentido2;
            Tipo = tipo;
            HrPartidaS1 = hrPartidaS1;
            HrPartidaS2 = hrPartidaS2;
        }

        public string Numero1 { get => Numero; set => Numero = value; }
        public string Nome1 { get => Nome; set => Nome = value; }
        public string Empresa1 { get => Empresa; set => Empresa = value; }
        public string Sentido11 { get => Sentido1; set => Sentido1 = value; }
        public string Sentido21 { get => Sentido2; set => Sentido2 = value; }
        public string Tipo1 { get => Tipo; set => Tipo = value; }
        public string HrPartidaS11 { get => HrPartidaS1; set => HrPartidaS1 = value; }
        public string HrPartidaS21 { get => HrPartidaS2; set => HrPartidaS2 = value; }

        public bool cadastrarLinha()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into TCC_Linha(NumeroLINHA, NomeLINHA, EmpresaLINHA, Sentido1LINHA, Sentido2LINHA, TipoLINHA, HrPartidaS1LINHA, HrPartidaS2LINHA)" + "values ('" + Numero + "', '" + Nome + "', '" + Empresa + "', '" + Sentido1 + "','" + Sentido2 + "', '" + Tipo + "', '" + HrPartidaS1 + "', '" + HrPartidaS2 + "')", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return cad;
        }

        public MySqlDataReader consultarCodigoLinhas()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT NumeroLINHA FROM TCC_Linha", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarTodasLinhas()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM TCC_Linha", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public bool excluirLinha()
        {
            bool excluiu = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclusao = new MySqlCommand("DELETE from TCC_Linha WHERE NumeroLINHA = '" + Numero + "'", DAO_Conexao.con);
                exclusao.ExecuteNonQuery();
                excluiu = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return excluiu;
        }

        public bool atualizarLinha()
        {
            bool alterou = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand alteracao = new MySqlCommand("UPDATE TCC_Linha SET NomeLINHA = @Nome, NumeroLINHA = @Numero, EmpresaLINHA = @Empresa, Sentido1LINHA = @Sentido1, Sentido2LINHA = @Sentido2, TipoLINHA = @Tipo, HrPartidaS1LINHA = @hrsaida1, HrPartidaS2LINHA = @hrsaida2 WHERE NumeroLinha = @NumeroAntigo", DAO_Conexao.con);
                alteracao.Parameters.AddWithValue("@Nome", Nome);
                alteracao.Parameters.AddWithValue("@Numero", Numero);
                alteracao.Parameters.AddWithValue("@Empresa", Empresa);
                alteracao.Parameters.AddWithValue("@Sentido1", Sentido1);
                alteracao.Parameters.AddWithValue("@Sentido2", Sentido2);
                alteracao.Parameters.AddWithValue("@Tipo", Tipo);
                alteracao.Parameters.AddWithValue("@hrsaida1", HrPartidaS1);
                alteracao.Parameters.AddWithValue("@hrsaida2", HrPartidaS2);
                alteracao.Parameters.AddWithValue("@NumeroAntigo", Numero);

                alteracao.ExecuteNonQuery();
                alterou = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return alterou;
        }
    }

    }

