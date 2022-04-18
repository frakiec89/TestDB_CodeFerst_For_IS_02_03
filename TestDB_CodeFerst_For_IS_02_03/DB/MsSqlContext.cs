using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB_CodeFerst_For_IS_02_03.DB
{
    public class MsSqlContext : DbContext
    {

        /* todo Установить зависимости
        Microsoft.EntityFrameworkCore
        Microsoft.EntityFrameworkCore.SqlServer
        Microsoft.EntityFrameworkCore.Tools
        */

        // я  не  понимаю  этот  код  


        /*
         команды миграции 
        // add-migration name=M1
        // update-database
        */
        static string adress = "192.168.10.134"; // строка  подключения 
        static string name = "AgtyamovTestDb_IS_20_03"; //так будет  называться бд - у каждого своя
        static string login = "stud";
        static string password = "stud";

        string connectionString = $"Server = {adress}; Database = {name}; User Id = {login}; Password = {password};";

        /// <summary>
        /// Переопределение  провайдера
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString); // Sql Сервер
        }

        /// <summary>
        /// Коллекции записей
        /// </summary>
        public DbSet<Record> Records { get; set; } 
    }
}
