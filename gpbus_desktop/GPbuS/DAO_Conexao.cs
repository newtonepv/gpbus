using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GPbuS
{
    class DAO_Conexao
    {
        public static MySqlConnection con;

        public static Boolean getConexao(String local, String banco, String user, String senha)
        {
            Boolean retorno = false;
            try
            {
                con = new MySqlConnection("server=" + local + ";User ID=" + user + ";database=" + banco + ";password=" + senha + "; SslMode = none");
                //con.Open();
                retorno = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //con.Close();
            }
            /*finally //não faz diferença nesse caso
            {
                //con.Close();
            }*/
            return retorno;
        }

        public static bool loginAdministrador(String email, String senha)
        {
            bool loginSucesso = false;
            try
            {
                con.Open();
                MySqlCommand login = new MySqlCommand("Select * from TCC_Administrador where EmailADM ='" + email + "' and SenhaADM ='" + senha + "'", con);
                MySqlDataReader resultado = login.ExecuteReader();
                if (resultado.Read())
                {
                    loginSucesso = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return loginSucesso;

        }

        public static bool verificaEmail(String email)
        {
            bool emailSucesso = false;
            try
            {
                con.Open();
                MySqlCommand email1 = new MySqlCommand("Select * from TCC_Administrador where EmailADM ='" + email + "'", con);
                MySqlDataReader resultado = email1.ExecuteReader();
                if (resultado.Read())
                {
                    emailSucesso = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return emailSucesso;
        }

        
    }
}
    

