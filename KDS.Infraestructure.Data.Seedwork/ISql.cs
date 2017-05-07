using System.Collections.Generic;

namespace KDS.Infrastructure.Data.Seedwork
{
    public interface ISql
    {
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);

        int ExecuteCommand(string sqlCommand, params object[] parameters);
    }
}
