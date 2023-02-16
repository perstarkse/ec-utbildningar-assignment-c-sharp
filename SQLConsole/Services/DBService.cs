using Microsoft.Data.SqlClient;
using SQLConsole.Classes;
using SQLConsole.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SQLConsole.Services
{
    internal class DBService
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\P\DESKTOP\SCHOOL-DATABASES\DATALAGRING_KURS_WEEK1.MDF;Integrated Security = True; Connect Timeout = 30";

        internal void SaveSiteToDatabase(Site site)
        {
            var siteEntity = new SiteEntity
            {
                Name = site.Name,
                AddressId = GetOrSaveAddress(site.Address)
            };
            SaveSite(siteEntity);
        }

        public IEnumerable<Site> GetSites()
        {
            var sites = new List<Site>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand("SELECT c.Id, c.Name, a.Address, a.ZipCode, a.City FROM Site c JOIN Address a ON c.AddressId = a.Id", conn);

            var result = cmd.ExecuteReader();
            
            while (result.Read())
            {
                sites.Add(new Site
                {
                    Id = result.GetInt32(0),
                    Name = result.GetString(1),
                    Address = new Address
                    {
                        AddressField= result.GetString(2),
                        ZipCode = result.GetString(3),
                        City= result.GetString(4),
                    }
                }) ;
            }
            return sites;
        }

        public Site GetSite(string siteName) 
        {
            var site = new Site();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand("SELECT c.Id, c.Name, a.Address, a.ZipCode, a.City FROM Site c JOIN Address a ON c.AddressId = a.Id WHERE c.Name = @Name", conn);
            cmd.Parameters.AddWithValue("@Name", siteName);

            var result = cmd.ExecuteReader();

            while (result.Read())
            {
                site.Id = result.GetInt32(0);
                site.Name = result.GetString(1);
                site.Address = new Address
                    {
                        AddressField = result.GetString(2),
                        ZipCode = result.GetString(3),
                        City = result.GetString(4),
                    };
            }
            return site;

        }

        private int GetOrSaveAddress(Address address)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Address WHERE Address = @Address AND ZipCode = @ZipCode AND City = @City) INSERT INTO Address OUTPUT INSERTED.Id VALUES (@Address, @ZipCode, @City) ELSE SELECT Id FROM Address WHERE Address = @Address AND ZipCode = @ZipCode AND City = @City", conn);
            cmd.Parameters.AddWithValue("@Address", address.AddressField);
            cmd.Parameters.AddWithValue("@ZipCode", address.ZipCode);
            cmd.Parameters.AddWithValue("@City", address.City);

            return int.Parse(cmd.ExecuteScalar().ToString());
        }

        private void SaveSite(SiteEntity siteEntity)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            using var cmd = new SqlCommand("IF NOT EXISTS (SELECT Id FROM Site WHERE Name = @Name) INSERT INTO Site VALUES (@Name, @AddressId)", conn);
            cmd.Parameters.AddWithValue("@Name", siteEntity.Name);
            cmd.Parameters.AddWithValue("@AddressId", siteEntity.AddressId);

            cmd.ExecuteNonQuery();
        }
    }
}
