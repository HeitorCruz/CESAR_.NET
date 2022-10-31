using System.Data;
using System.Net;
using DOTNETAPI;
using System.Text.Json;
using System.Text.Json.Serialization;
using MySqlConnector;
using FirebirdSql.Data.FirebirdClient;
using static System.Net.Mime.MediaTypeNames;

namespace LTN
{
    public class MySql
    {
        // FbConnectionStringBuilder sb = new FbConnectionStringBuilder()
        // {
        //     DataSource = "localhost",
        //     Database = @"C:\Program Files\Firebird\HEITOR.FDB",
        //     UserID = "sysdba",
        //     Password = "masterkey",
        //     // SslMode = MySqlSslMode.Required,
        // };
        public class Vendedor
        {
            public string nome {get;set;}
            public string idade {get;set;}
        }
        public class VendedorArray
        {
            public Vendedor[] data {get;set;} 
            public VendedorArray (int counterindex){
                data = new Vendedor[counterindex];
            }
        }
        public void POST(string nome, string idade)
        {
            System.Console.WriteLine($"{nome} {idade}");
            FbConnection cnt = new FbConnection(@"datasource=localhost;database=C:\Program Files\Firebird\Firebird_2_5\HEITOR.fdb;user=sysdba;password=masterkey");
            cnt.Open();                                                     
            FbCommand cmd = new FbCommand($"insert into ENTIDADES (nome, id) values ('{nome}','{idade}')", cnt);
            cmd.ExecuteNonQuery();
            cnt.Close();
        }
        public string GET()
        {
            FbConnection cnt = new FbConnection(@"datasource=localhost;database=C:\Program Files\Firebird\Firebird_2_5\HEITOR.fdb;user=sysdba;password=masterkey");
            cnt.Open();                                                    
            FbCommand cmd = new FbCommand("select * from ENTIDADES",cnt);
            FbCommand cmd2 = new FbCommand("select count(nome) from ENTIDADES",cnt);
            FbDataReader dr = cmd.ExecuteReader();
            FbDataReader counter = cmd2.ExecuteReader();
            // dr.Read();
            counter.Read();
            int counterindex = counter.GetInt16(0);
            VendedorArray ArraydeVendedores = new VendedorArray(counter.GetInt16(0));
            int i = 0;
            while(dr.Read()){
            ArraydeVendedores.data[i] = new Vendedor { nome = dr.GetString(0), idade = dr.GetString(1) };
            i++;
            }
            i=0;
            return JsonSerializer.Serialize(ArraydeVendedores);
            cnt.Close();
        }
        public void DELETE(string nome){
            System.Console.WriteLine(nome);
            FbConnection cnt = new FbConnection(@"datasource=localhost;database=C:\Program Files\Firebird\Firebird_2_5\HEITOR.fdb;user=sysdba;password=masterkey");
            cnt.Open();
            FbCommand cmd = new FbCommand($"delete from ENTIDADES e where e.nome = '{nome}'", cnt);
            cmd.ExecuteNonQuery();
            System.Console.WriteLine($"UPDATE");
            cnt.Close();
        }
        public void UPDATE(string nome, string idade, string str){
            FbConnection cnt = new FbConnection(@"datasource=localhost;database=C:\Program Files\Firebird\Firebird_2_5\HEITOR.fdb;user=sysdba;password=masterkey");
            cnt.Open();
            FbCommand cmd = new FbCommand($"update ENTIDADES e set nome = '{nome}', id = '{idade}' where e.nome = '{str}'",cnt);
            cmd.ExecuteNonQuery();
            cnt.Close();
        }
    }
}