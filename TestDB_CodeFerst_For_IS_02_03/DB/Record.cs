using System;

namespace TestDB_CodeFerst_For_IS_02_03.DB
{
    /// <summary>
    /// модель базы данных
    /// </summary>
    public class Record
    {
        public int RecordId { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }

        /// <summary>
        /// Дата  записи
        /// </summary>
        public DateTime DateRecord { get; set; }

        /// <summary>
        /// Вывод клиенту
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}