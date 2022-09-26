using System.Data;
using System.Net;
using DOTNETAPI;
using MySqlConnector;
using static System.Net.Mime.MediaTypeNames;

namespace LTN{
    public class MySql{
        MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder(){
                Server = "servermysql1.mysql.database.azure.com",
                Database = "heitor",
                UserID = "heitor",
                Password = "C3I9E5!#",
                SslMode = MySqlSslMode.Required,
        };
    public class Vendedor
        {
            string nome;
            string idade;
        }
        public void GET(string nome,string idade){
            MySqlConnection cnt = new MySqlConnection(sb.ConnectionString);
            cnt.Open();
            MySqlCommand cmd = new MySqlCommand($"insert into ENTIDADES values ('{nome}','{idade}')",cnt);
            cmd.ExecuteNonQuery();
            cnt.Close();
            }
        public void getData()
        {
            MySqlConnection cnt = new MySqlConnection(sb.ConnectionString);
            cnt.Open();
            MySqlCommand cmd = new MySqlCommand("select * from Entidades");
            MySqlDataReader dr = cmd.ExecuteReader();
            cnt.Close();
    }
}