using Dapper;
using Microsoft.Data.SqlClient;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Shop.DataAccess
{
    public class Repository
    {
        private readonly DbConnection connection;
        private readonly string connectionString;

        public Repository(DbConnection connection)
        {
            this.connection = connection;
        }
        public void AddUSer(User user)
        {
            var sql = "Insert into Users(" +
                "@Id, " +
                "@PhoneNumber," +
                "@Password," +
                "@Email," +
                "@VerificationCode," +
                "@Address," +
                "@CreationDate," +
                "@DeleteDate);";
            using (var connection = new SqlConnection(connectionString))
            {
                //обязательно нужна строка подключения
                var transaction = connection.BeginTransaction();
                var rowAffected = connection.Execute(sql,user ,transaction);
                if (rowAffected != 1)

                {
                    throw new Exception("Беда");
                }
            }
        }
        public void UpdateUSer(User user)
        {
            var sql = "Update Users Set " +
                "Id=@Id," +
                " PhoneNumber = @PhoneNumber," +
                "CreationDate=@CreationDate," +
                "DeleteDate=@DeleteDate," +
                "Password =@Password," +
                "Email = @Email," +
                "VerificationCode = @VerificationCode," +
                "Address = @Address where PhoneNumber = @PhoneNumber;";

            using (var connection = new SqlConnection(connectionString))
            {

                var transaction = connection.BeginTransaction();
                var rowAffected = connection.Execute(sql, user, transaction);
                if (rowAffected != 1)
                {
                    throw new Exception("Беда");
                }
            }
        }
        public void DeleteUSer(User user)
        {
            var sql = "Update Users Set " +
                "DeleteDate=@DeleteDate,where Id = @Id;";

            using (var connection = new SqlConnection(connectionString))
            {

                var transaction = connection.BeginTransaction();
                var rowAffected = connection.Execute(sql, user, transaction);
                if (rowAffected != 1)
                {
                    throw new Exception("Беда");
                }
            }
        }
        public void AddCategory(Category category)
        {
            var sql = "Insert into Category(" +
                "@id," +
                "@CreationDate," +
                "@DeleteDate," +
                "@Name," +
                "@ImagePath);";
            using (var connection = new SqlConnection(connectionString))
            {
                //обязательно нужна строка подключения
                var transaction = connection.BeginTransaction();
                var rowAffected = connection.Execute(sql, category, transaction);
                if (rowAffected != 1)

                {
                    throw new Exception("Беда");
                }
            }

        }
        public void UpdateCategory(Category category)
        {
            var sql = "Update Category Set " +
                "Id=@Id" +
                "CreationDate = @CreationDate," +
                "DeleteDate=@DeleteDate," +
                "Name=@Name," +
                "ImagePath=@ImagePath where Name=@Name;";
            var transaction = connection.BeginTransaction();
            var rowAffected = connection.Execute(sql, category, transaction);
            if (rowAffected != 1)

            {
                throw new Exception("Беда");
            }
        }
        public void DeleteCategory(Category category)
        {
            var sql = "Update Category Set " +
                "DeleteDate=@DeleteDate," +
                 "where Name=@Name;";
            var transaction = connection.BeginTransaction();
            var rowAffected = connection.Execute(sql, category, transaction);
            if (rowAffected != 1)

            {
                throw new Exception("Беда");
            }
        }
        public void AddItem(Item item)
        {
            var sql = "Insert into Item(" +
                "@Id," +
                "@Name," +
                "@ImagePath" +
                "@CreationDate," +
                "@DeleteDate," +
                "@Price, " +
                "@Description," +
                "@AvgRating, " +
                "@Category);";
            var transaction = connection.BeginTransaction();
            var rowAffected = connection.Execute(sql,item, transaction);
            if (rowAffected != 1)
            {
                throw new Exception("Беда");
            }
        }
        public void UpdateItem(Item item)
        {
            var sql = "Update Item Set " +
                "id=@Id," +
                "Name=@Name," +
                "ImagePath=@ImagePath" +
                "CreationDate=@CreationDate," +
                "DeleteDate=@DeleteDate," +
                "Price=@Price, " +
                "Description=@Description," +
                "AvgRating=@AvgRating, " +
                "Category=@Category where Id=@id;";
            var transaction = connection.BeginTransaction();
            var rowAffected = connection.Execute(sql, item, transaction);
            if (rowAffected != 1)
            {
                throw new Exception("Беда");
            }
        }
        public void DeleteItem(Item item)
        {
            var sql = "Update Item Set " +
                "DeleteDate=@DeleteDate," +
                "where Price=@Price;";
            var transaction = connection.BeginTransaction();
            var rowAffected = connection.Execute(sql, item, transaction);
            if (rowAffected != 1)
            {
                throw new Exception("Беда");
            }
        }
        public User GetUserById(Guid id)
        {
            var sql = "Select TOP(1) from Users where Id=@Id;";
            using (var connection = new SqlConnection())
            {
                
                return connection.QuerySingleOrDefault<User>(sql, new { Id = id });
            }
        }
        public Category GetCategoryById(Guid id)
        {
            var sql = "Select TOP(1) from Category where Id=@Id;";
            using (var connection = new SqlConnection())
            {
                return connection.QuerySingleOrDefault<Category>(sql, new { Id = id });
            }
        }
        public Item GetItemById(Guid id)
        {
            var sql = "Select TOP(1) from Item where Id=@Id;";
            using (var connection = new SqlConnection())
            {
                return connection.QuerySingleOrDefault<Item>(sql, new { Id = id });
            }
        }

    }

}
