using System.Data.SqlClient;

namespace DateMicroservice.Data
{
    public abstract class BaseSqlQueryResult
    {
        public abstract BaseSqlQueryResult HandleReader(SqlDataReader reader);
    }
}
