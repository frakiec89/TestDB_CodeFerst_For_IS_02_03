using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDB_CodeFerst_For_IS_02_03
{
    internal class RecordService
    {
        internal static void AddRecord(string content, string status)
        {
            try
            {
                using DB.MsSqlContext db = new DB.MsSqlContext();
                db.Records.Add(new DB.Record
                {
                    Content = content,
                    Status = status,
                    DateRecord = DateTime.Now
                });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static List<string> GetRecord()
        {
            try
            {
                using DB.MsSqlContext db = new DB.MsSqlContext();
                List<string> rez = new List<string>();
                db.Records.Where(x => x.IsDeleted == false).ToList().ForEach(r => rez.Add($"id-{r.RecordId}. {r.Content},  {r.Status}, {r.DateRecord}"));
                return rez;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Получение  записей из бд 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal static List<string> GetRecord(string status)
        {
            try
            {
                using DB.MsSqlContext db = new DB.MsSqlContext();
                List<string> rez = new List<string>();
                db.Records.Where(x => x.IsDeleted == false && x.Status.ToLower() == status.ToLower()).ToList().ForEach(r => rez.Add($"id-{r.RecordId}. {r.Content},  {r.Status}, {r.DateRecord}"));
                return rez;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static void AllRemove()
        {
            try
            {
                using DB.MsSqlContext db = new DB.MsSqlContext();
                db.Records.Where(x => x.IsDeleted == false).ToList().ForEach(x => x.IsDeleted = true);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static void AllReplace()
        {
            try
            {
                using DB.MsSqlContext db = new DB.MsSqlContext();
                db.Records.Where(x => x.IsDeleted == true).ToList().ForEach(x => x.IsDeleted = false);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// удаление  записей - навсегда
        /// </summary>
        /// <exception cref="Exception"></exception>
        internal static void DeleteAtAllForever()
        {
            try
            {
                using DB.MsSqlContext db = new DB.MsSqlContext();

                db.Records.RemoveRange(db.Records);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static List<string> GetStatus()
        {
            try
            {
                List<string> list = new List<string>();
                using DB.MsSqlContext db = new DB.MsSqlContext();
                return db.Records.Select(x => x.Status).Distinct().OrderBy(s => s).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Удаление  записи 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        internal static void RemoveRecord(int id)
        {
            try
            {
                using DB.MsSqlContext db = new DB.MsSqlContext();

                if (db.Records.Any(x => x.RecordId == id) == false)
                {
                    throw new Exception("Запись не найдена");
                }

                var r = db.Records.Single(x => x.RecordId == id);
                r.IsDeleted = true;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}