using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebC.Generic.Repository
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        bool Edits(string sql, object EditList);

        TEntity? Get(string sql, object parameters);
        IQueryable<TResult> GetAlls<TResult>(string sql) where TResult : class;
        IQueryable<TResult> GetAlls<TResult>(string sql, object parameters) where TResult : class;

    }
}
