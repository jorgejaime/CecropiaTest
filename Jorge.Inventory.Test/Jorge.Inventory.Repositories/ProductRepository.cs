using Dapper;
using Jorge.Inventory.IRepositories;
using Jorge.Inventory.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Jorge.Inventory.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly string _connectionString;
        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
            
        }

        private IDbConnection _connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public virtual void Add(Product entity)
        {

            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Id", entity.Id, DbType.Int32, ParameterDirection.InputOutput);
            parameter.Add("@Sku", entity.Sku, DbType.String, ParameterDirection.Input);
            parameter.Add("@Description", entity.Description, DbType.String, ParameterDirection.Input);
            parameter.Add("@QuantityStock", entity.QuantityStock, DbType.Decimal, ParameterDirection.Input);
            parameter.Add("@FinalPrice", entity.FinalPrice, DbType.Decimal, ParameterDirection.Input);
            parameter.Add("@RegularPrice", entity.RegularPrice, DbType.Decimal, ParameterDirection.Input);
            parameter.Add("@ApplyTaxes", entity.ApplyTaxes, DbType.Boolean, ParameterDirection.Input);
            parameter.Add("@TaxRate", entity.TaxRate, DbType.Decimal, ParameterDirection.Input);
            parameter.Add("@Location", entity.Location, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Image", entity.Image, DbType.Binary, ParameterDirection.Input);



            using (var conn = _connection)
            {
                conn.Open();

                conn.Execute("Insert_Product",
                    parameter,
                    commandType: CommandType.StoredProcedure);
            }

            entity.Id = parameter.Get<int>("@Id");
        }

        public virtual void Update(Product entity)
        {
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Id", entity.Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Sku", entity.Sku, DbType.String, ParameterDirection.Input);
            parameter.Add("@Description", entity.Description, DbType.String, ParameterDirection.Input);
            parameter.Add("@QuantityStock", entity.QuantityStock, DbType.Decimal, ParameterDirection.Input);
            parameter.Add("@FinalPrice", entity.FinalPrice, DbType.Decimal, ParameterDirection.Input);
            parameter.Add("@RegularPrice", entity.RegularPrice, DbType.Decimal, ParameterDirection.Input);
            parameter.Add("@ApplyTaxes", entity.ApplyTaxes, DbType.Boolean, ParameterDirection.Input);
            parameter.Add("@TaxRate", entity.TaxRate, DbType.Decimal, ParameterDirection.Input);
            parameter.Add("@Location", entity.Location, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Image", entity.Image);

  

            using (var conn = _connection)
            {
               conn.Open();

                conn.Execute("Update_Product",
                    parameter,
                    commandType: CommandType.StoredProcedure);
            }

        }

       

        public virtual IEnumerable<Product> FindAll()
        {

            using (var conn = _connection)
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
            parameter.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            using (var conn = _connection)
            {
                conn.Open();
                entity = conn.QuerySingleOrDefault<Product>("GetById_Product",
                    parameter,
                    commandType: CommandType.StoredProcedure);
            }

            return entity;
        }

        public virtual void Remove(Product entity)
        {
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Id", entity.Id, DbType.Int32, ParameterDirection.Input);


            using (var conn = _connection)
            {
                conn.Open();

                conn.Execute("Delete_Product",
                    parameter,
                    commandType: CommandType.StoredProcedure);
            }

        }
    
      
    }
}
