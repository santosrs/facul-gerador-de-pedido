using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Dapper;

namespace ProjetoFacul.DAL
{
    public static class Db
    {
#if DEBUG
        private static string _conexao = @"Data Source=DESKTOP-U02BULH\SQLEXPRESS;
                         Initial Catalog=ProjetoFacul;
                         Integrated Security=true";
#else
        private static string _conexao = @"Data Source=DESKTOP-U02BULH\SQLEXPRESS;
                         Initial Catalog=ProjetoFaculDb;
                         Integrated Security=true";
        //private static string _conexao = "server=mysql.meuprovedor.com.br;database=contadb;user=admin;password=123";
#endif

        private static SqlConnection ObterConnection()
        {
            var cn = new SqlConnection();
            cn.ConnectionString = _conexao;
            return cn;
        }


        public static int Execute(string storedProcedure, object param)
        {
            int total;
            using (var cn = ObterConnection())
            {
                total = cn.Execute(storedProcedure, param, commandType: CommandType.StoredProcedure);
            }
            return total;
        }

        public static IEnumerable<T> QueryColecao<T>(string storedProcedure, object param)
        {
            IEnumerable<T> retorno;
            using (var cn = ObterConnection())
            {
                retorno = cn.Query<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);

            }
            return retorno;
        }


        public static T QueryEntidade<T>(string storedProcedure, object param)
        {
            T retorno;
            using (var cn = ObterConnection())
            {
                retorno = cn.QueryFirstOrDefault<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);

            }
            return retorno;
        }

       

    }
}
