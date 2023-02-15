using Microsoft.Data.SqlClient;
using SQLConsole.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConsole.Services
{
    internal class DBService
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=C:\\USERS\\P\\DESKTOP\\SCHOOL-DATABASES\\DATALAGRING_KURS_WEEK1.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int GetOrSaveAddress(Address address)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Address WHERE Address = @Address AND ZipCode = @ZipCode AND City = @City) INSERT INTO Address OUTPUT INSERTED.Id VALUES (@Address, @ZipCode, @City) ELSE SELECT Id FROM Address WHERE Address = @Address AND ZipCode = @ZipCode AND City = @City", conn);
            cmd.Parameters.AddWithValue("@Address", address.AddressField);
            cmd.Parameters.AddWithValue("@ZipCode", address.ZipCode);
            cmd.Parameters.AddWithValue("@City", address.City);

            var result = int.Parse(cmd.ExecuteScalar().ToString());
        }
        internal void SaveToDatabase(Site site)
        {

        }
    }
}
