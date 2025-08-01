using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaterialSkin.Controls.MaterialForm;

namespace GPbuS
{
    class Motorista
    {

        private string Nome;
        private string DataNasc;
        private string CNH;
        private string Email;
        private int NumeroOnibus;
        private byte[] FotoPerfil;
        private string Avaliação;
        private string Celular;
        private string Estado;
        private string Cidade;
        private string Endereco;
        private string CEP;

        public Motorista(string nome, string dataNasc, string cNH, string email, int numeroOnibus, byte[] fotoPerfil, string avaliação, string celular, string estado, string cidade, string endereco, string cEP)
        {
            Nome = nome;
            DataNasc = dataNasc;
            CNH = cNH;
            Email = email;
            NumeroOnibus = numeroOnibus;
            FotoPerfil = fotoPerfil;
            Avaliação = avaliação;
            Celular = celular;
            Estado = estado;
            Cidade = cidade;
            Endereco = endereco;
            CEP = cEP;
        }

        public Motorista()
        {

        }

        public string Nome1 { get => Nome; set => Nome = value; }
        public string DataNasc1 { get => DataNasc; set => DataNasc = value; }
        public string CNH1 { get => CNH; set => CNH = value; }
        public string Email1 { get => Email; set => Email = value; }
        public int NumeroOnibus1 { get => NumeroOnibus; set => NumeroOnibus = value; }
        public byte[] FotoPerfil1 { get => FotoPerfil; set => FotoPerfil = value; }
        public string Avaliação1 { get => Avaliação; set => Avaliação = value; }
        public string Celular1 { get => Celular; set => Celular = value; }
        public string Cidade1 { get => Cidade; set => Cidade = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
        public string Endereco1 { get => Endereco; set => Endereco = value; }
        public string CEP1 { get => CEP; set => CEP = value; }

        public bool cadastrarMotorista()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("INSERT INTO TCC_Motorista(NomeMOTO, DataNascMOTO, CNHMOTO, EmailMOTO, NumeroOnibusMOTO, FotoPerfilMOTO, AvaliacaoMOTO, CelularMOTO, EstadoMOTO, CidadeMOTO, EnderecoMOTO, CEPMOTO) " +
                    "VALUES (@Nome, @DataNasc, @CNH, @Email, @NumeroOnibus, @FotoPerfil, @Avaliacao, @Celular, @Estado, @Cidade, @Endereco, @CEP)", DAO_Conexao.con);

                insere.Parameters.AddWithValue("@Nome", Nome);
                insere.Parameters.AddWithValue("@DataNasc", DataNasc);
                insere.Parameters.AddWithValue("@CNH", CNH);
                insere.Parameters.AddWithValue("@Email", Email);
                insere.Parameters.AddWithValue("@NumeroOnibus", NumeroOnibus);
                insere.Parameters.AddWithValue("@FotoPerfil", FotoPerfil);
                insere.Parameters.AddWithValue("@Avaliacao", Avaliação);
                insere.Parameters.AddWithValue("@Celular", Celular);
                insere.Parameters.AddWithValue("@Estado", Estado);
                insere.Parameters.AddWithValue("@Cidade", Cidade);
                insere.Parameters.AddWithValue("@Endereco", Endereco);
                insere.Parameters.AddWithValue("@CEP", CEP);

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


        public MySqlDataReader consultarTodosMotoristas()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM TCC_Motorista", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public bool excluirMotorista()
        {
            bool excluiu = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclusao = new MySqlCommand("DELETE from TCC_Motorista WHERE CNHMOTO = '" + CNH + "'", DAO_Conexao.con);
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

        public bool atualizarMotorista()
        {
            bool alterou = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand alteracao = new MySqlCommand("UPDATE TCC_Motorista SET NomeMOTO = @Nome, DataNascMOTO = @DataNasc, CNHMOTO = @CNH, EmailMOTO = @Email, NumeroOnibusMOTO = @NumeroOnibus, CelularMOTO = @Celular, EstadoMOTO = @Estado, CidadeMOTO = @Cidade, EnderecoMOTO = @Endereco, CEPMOTO = @CEP WHERE CNHMOTO = @CNHAntiga", DAO_Conexao.con);
                alteracao.Parameters.AddWithValue("@Nome", Nome);
                alteracao.Parameters.AddWithValue("@DataNasc", DataNasc);
                alteracao.Parameters.AddWithValue("@CNH", CNH);
                alteracao.Parameters.AddWithValue("@Email", Email);
                alteracao.Parameters.AddWithValue("@NumeroOnibus", NumeroOnibus);
                alteracao.Parameters.AddWithValue("@Celular", Celular);
                alteracao.Parameters.AddWithValue("@Estado", Estado);
                alteracao.Parameters.AddWithValue("@Cidade", Cidade);
                alteracao.Parameters.AddWithValue("@Endereco", Endereco);
                alteracao.Parameters.AddWithValue("@CEP", CEP);
                alteracao.Parameters.AddWithValue("@CNHAntiga", CNH); // Usado para localizar o registro específico a ser atualizado

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
