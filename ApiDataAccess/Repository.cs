﻿

namespace ApiDataAccess
{
    using ApiRepositories;
    using Dapper.Contrib.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text;
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string _connectionString;

        public Repository(string _connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"[{type.Name}]"; };
            this._connectionString = _connectionString;
        }
        public virtual bool Delete(T entity)
        {
            using (var connection =new SqlConnection(_connectionString))
            {
                return connection.Delete(entity);
            }
        }

        public virtual T GetById(Int64 id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<T>((Int64)id);
            }
        }

        public T GetByIdString(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<T>((string)id);
            }
        }

        public virtual IEnumerable<T> GetList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<T>();
            }
        }
        public virtual int Insert(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
                
            }
        }

        public virtual bool Update(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Update(entity);
            }
        }
    }
}
