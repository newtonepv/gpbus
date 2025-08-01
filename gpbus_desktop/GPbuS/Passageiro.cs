using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPbuS
{
    class Passageiro
    {
        private string Nome;
        private string DataNasc;
        private string Email;
        private string Senha;
        private string Ocupacao;
        private string Celular;
        private string CPF;
        private byte[] FotoPerfil;
        private string BusBucks;
        private string Cidade;
        private string Estado;
        private string CEP;

        public Passageiro()
        {
        }

        public Passageiro(string nome, string dataNasc, string email, string ocupacao, string celular, string cPF, string cidade, string estado, string cEP)
        {
            Nome = nome;
            DataNasc = dataNasc;
            Email = email;
            Ocupacao = ocupacao;
            Celular = celular;
            CPF = cPF;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
        }

        public Passageiro(string nome, string dataNasc, string email, string senha, string ocupacao, string celular, string cPF, byte[] fotoPerfil, string busBucks, string cidade, string estado, string cEP)
        {
            Nome = nome;
            DataNasc = dataNasc;
            Email = email;
            Senha = senha;
            Ocupacao = ocupacao;
            Celular = celular;
            CPF = cPF;
            FotoPerfil = fotoPerfil;
            BusBucks = busBucks;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
        }



        public string CPF1 { get => CPF; set => CPF = value; }
        public string Nome1 { get => Nome; set => Nome = value; }
        public string DataNasc1 { get => DataNasc; set => DataNasc = value; }
        public string Senha1 { get => Senha; set => Senha = value; }
        public string Ocupacao1 { get => Ocupacao; set => Ocupacao = value; }
        public string CEP1 { get => CEP; set => CEP = value; }
        public string Cidade1 { get => Cidade; set => Cidade = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
        public string Celular1 { get => Celular; set => Celular = value; }
        public string Email1 { get => Email; set => Email = value; }
        public byte[] FotoPerfil1 { get => FotoPerfil; set => FotoPerfil = value; }
        public string BusBucks1 { get => BusBucks; set => BusBucks = value; }

        public bool cadastrarPassageiro()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into TCC_Passageiro (NomePass, DataNascPass, EmailPass, OcupacaoPass, CelularPass, CPFPass, EstadoPass, CidadePass, CEPPass)" + "values ('" + Nome + "', '" + DataNasc + "', '" + Email + "', '" + Ocupacao + "', '" + Celular + "', '" + CPF + "', '"+Estado+"', '" + Cidade + "', '" +CEP+"')", DAO_Conexao.con);
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
    }
}
