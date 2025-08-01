using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPbuS
{
    public class ADM
    {

        private string Nome;
        private string DataNasc;
        private string Email;
        private string NomeUsuario;
        private string Senha;
        private string Celular;
        private string CPF;
        private byte[] FotoPerfil;
        private string BusBucks;
        private string Cidade;
        private string Estado;
        private string Endereco;
        private string CEP;

        public ADM(string nome, string dataNasc, string email, string nomeUsuario, string senha, string celular, string cPF, byte[] fotoPerfil, string cidade, string estado, string endereco, string cEP)
        {
            Nome = nome;
            DataNasc = dataNasc;
            Email = email;
            NomeUsuario = nomeUsuario;
            Senha = senha;
            Celular = celular;
            CPF = cPF;
            FotoPerfil = fotoPerfil;
            Cidade = cidade;
            Estado = estado;
            Endereco = endereco;
            CEP = cEP;
        }

        public ADM()
        {

        }

        public string Nome1 { get => Nome; set => Nome = value; }
        public string DataNasc1 { get => DataNasc; set => DataNasc = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Senha1 { get => Senha; set => Senha = value; }
        public string Celular1 { get => Celular; set => Celular = value; }
        public string CPF1 { get => CPF; set => CPF = value; }
        public byte[] FotoPerfil1 { get => FotoPerfil; set => FotoPerfil = value; }
        public string BusBucks1 { get => BusBucks; set => BusBucks = value; }
        public string Cidade1 { get => Cidade; set => Cidade = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
        public string Endereco1 { get => Endereco; set => Endereco = value; }
        public string CEP1 { get => CEP; set => CEP = value; }
        public string NomeUsuario1 { get => NomeUsuario; set => NomeUsuario = value; }

        public bool cadastrarAdministrador()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("INSERT INTO TCC_Administrador(NomeADM, DataNascADM, EmailADM, NomeUsuarioADM, SenhaADM, CelularADM, CPFADM, FotoPerfilADM, CidadeADM, EstadoADM, EnderecoADM, CEPADM) " +
            "VALUES (@Nome, @DataNasc, @Email, @NomeUsuario, @Senha, @Celular, @CPF, @FotoPerfil, @Cidade, @Estado, @Endereco, @CEP)", DAO_Conexao.con);

                insere.Parameters.AddWithValue("@Nome", Nome);
                insere.Parameters.AddWithValue("@DataNasc", DataNasc);
                insere.Parameters.AddWithValue("@Email", Email);
                insere.Parameters.AddWithValue("@NomeUsuario", NomeUsuario1);
                insere.Parameters.AddWithValue("@Senha", Senha1);
                insere.Parameters.AddWithValue("@Celular", Celular);
                insere.Parameters.AddWithValue("@CPF", CPF);
                insere.Parameters.AddWithValue("@FotoPerfil", FotoPerfil);
                insere.Parameters.AddWithValue("@Cidade", Cidade);
                insere.Parameters.AddWithValue("@Estado", Estado);
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

        public MySqlDataReader retornaUserName(string email, string senha)
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT NomeUsuarioADM FROM TCC_Administrador WHERE EmailADM = @Email AND SenhaADM = @Senha", DAO_Conexao.con);
                consulta.Parameters.AddWithValue("@Email", email);
                consulta.Parameters.AddWithValue("@Senha", senha);
                resultado = consulta.ExecuteReader();
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public bool AtualizarSenha(string novoEmail, string novaSenha)
        {
            bool atualizado = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualizaSenha = new MySqlCommand("UPDATE TCC_Administrador SET SenhaADM = @NovaSenha WHERE EmailADM = @Email", DAO_Conexao.con);
                atualizaSenha.Parameters.AddWithValue("@NovaSenha", novaSenha);
                atualizaSenha.Parameters.AddWithValue("@Email", novoEmail);
                int rowsAffected = atualizaSenha.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    this.Senha1 = novaSenha; // Atualiza a senha na instância atual
                    atualizado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return atualizado;
        }


    }
}
