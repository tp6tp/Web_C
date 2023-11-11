using C_Web.Extension.DBConn;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebC.Generic.Repository
{
    public class GenericRepository<TEntity> : DBConnClass, IGenericRepository<TEntity>, IDisposable where TEntity : class 
    {
      private DataContext? dataContext {  get; set; }
        public bool Edits(string sql, object EditList)
        {
            try
            {
                using (var cn = new SqlConnection(GetDBConnString()))
                {
                    cn.Execute(sql, EditList);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TEntity? Get(string sql, object parameters)
        {
            TEntity? info;
            using (var cn = new SqlConnection(GetDBConnString()))
            {
               info = cn.QueryFirstOrDefault<TEntity?>(sql, parameters);
            }
            return info;
        }

        public IQueryable<TResult> GetAlls<TResult>(string sql, object parameters) where TResult : class
        {
            IQueryable<TResult> info;
            using (var cn = new SqlConnection(GetDBConnString()))
            {
                info = cn.Query<TResult>(sql, parameters).AsQueryable();
            }
            return info;
        }
        public IQueryable<TResult> GetAlls<TResult>(string sql) where TResult : class
        {
            IQueryable<TResult> info;
            using (var cn = new SqlConnection(GetDBConnString()))
            {
                info = cn.Query<TResult>(sql).AsQueryable();
            }
            return info;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dataContext != null)
                {
                    this.dataContext.Dispose();
                    this.dataContext = null;
                }
            }
        }
        public void Dispose() 
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
