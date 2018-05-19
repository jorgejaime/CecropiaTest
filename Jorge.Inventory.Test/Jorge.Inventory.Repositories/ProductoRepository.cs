using Dapper;
using Jorge.Inventory.IRepositories;
using Jorge.Inventory.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Jorge.Inventory.Repositories
{
    public class ProductoRepository : IProductoRepository
    {

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection("Data Source=den1.mssql3.gear.host;Initial Catalog=factura;User ID=factura;Password=Kq3KOmi?lI2~;Connection Timeout=9000; MultipleActiveResultSets=True;");
            }
        }

        public virtual void Add(Product entity)
        {

            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Id", entity.Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Sku", entity.Sku, DbType.String, ParameterDirection.Input);
           

            using (var conn = Connection)
            {
                conn.Open();

                conn.Execute("Insert_Product",
                    parameter,
                    commandType: CommandType.StoredProcedure);
            }

            
        }

        public virtual void Update(Product entity)
        {
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Id", entity.Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Sku", entity.Sku, DbType.String, ParameterDirection.Input);


            using (var conn = Connection)
            {
                conn.Open();

                conn.Execute("Update_Product",
                    parameter,
                    commandType: CommandType.StoredProcedure);
            }

        }

        //public virtual IEnumerable<Product> Find(string where = null)
        //{
        //    var query = $"SELECT * FROM {_tableName} ";
        //    if (!string.IsNullOrWhiteSpace(where))
        //        query += where;

        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        return conn.Query<T>(query);
        //    }
        //}

        public virtual IEnumerable<Product> FindAll()
        {

            using (var conn = Connection)
            {
                conn.Open();

                return conn.Query<Product> ("GetAll_Product",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
           
        }

        public virtual Product FindById(int id)
        {
            var entity = default(Product);
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Id", entity.Id, DbType.Int32, ParameterDirection.Input);

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                entity = cn.QuerySingleOrDefault<Product>("GetById_Product",
                    parameter,
                    commandType: CommandType.StoredProcedure);
            }

            return entity;
        }

        public virtual void Remove(Product entity)
        {
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Id", entity.Id, DbType.Int32, ParameterDirection.Input);


            using (var conn = Connection)
            {
                conn.Open();

                conn.Execute("Delete_Product",
                    parameter,
                    commandType: CommandType.StoredProcedure);
            }

        }
    
      
    }
}
