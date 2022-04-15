using System;

namespace TestDB_CodeFerst_For_IS_02_03
{
    internal class Program // это view
    {
        static string getRead = "get"; // команды
        static string addRead = "add";
        static string exit = "exit";
        static string AllRemove = "all-dell";
        static string AllReplace = "all-replace";
        static string AllRemoveForerer = "all-dell-forever";
        static string removeReader = "remove";
        static string getStatus = "get-status";
        static string getReadStatus = "get-reader-status";

        static void Main(string[] args)  // ссылка на  гит  https://github.com/frakiec89/TestDB_CodeFerst
        {
            Console.WriteLine("Программа -- мои  записки --- ");

            while (true)
            {
                Console.WriteLine("---- доступные  команды ---- ");
                Console.WriteLine($"для того что  бы  получит  список  записей введите \"{getRead}\"");
                Console.WriteLine($"для того что  бы  добавить  запись введите \"{addRead}\"");
                Console.WriteLine($"для того что  бы  получить  список статусов введите \"{getStatus}\"");
                Console.WriteLine($"для того что  бы  получить  список  записей  по  одному статусу введите \"{getReadStatus}\"");

                Console.WriteLine($"для того что  бы  удалить запись введите \"{removeReader}\"");
                Console.WriteLine($"для того что  бы  удалить  все записи введите \"{AllRemove}\"");
                Console.WriteLine($"для того что  бы  вернуть  все записи введите \"{AllReplace}\"");
                Console.WriteLine();
                Console.WriteLine($"для того что  бы  удалить все записи навсегда введите \"{AllRemoveForerer}\"");
                Console.WriteLine($"для того что  бы  выйти из программы введите \"{exit}\"");
                Console.WriteLine("----   сгк продакшен   ---- ");


                switch (Console.ReadLine().ToLower().TrimStart().TrimEnd())
                {
                    case "get": GetRead(); break;
                    case "add": AddRead(); break;
                    case "exit":; return;
                    case "all-dell": AllDell(); break;
                    case "all-replace": AllReplaceMetod(); break;
                    case "all-dell-forever": AllReplaceMetodForever(); break;
                    case "remove": Remove(); break;
                    case "get-status": GetStatus(); break;
                    case "get-reader-status": GetReaderStatus(); break;


                    default:
                        Console.WriteLine("не корректная команда");
                        break;
                }
                Console.WriteLine();
            }
        }

        private static void GetReaderStatus()
        {
            string s = GetStringContentConsole("Введите статус для поиска записей");
            try
            {
                RecordService.GetRecord(s).ForEach(x => Console.WriteLine(x));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetStringContentConsole(string v)
        {
            throw new NotImplementedException();
        }

        private static void GetStatus()
        {
            throw new NotImplementedException();
        }

        private static void Remove()
        {
            throw new NotImplementedException();
        }

        private static void AllReplaceMetodForever()
        {
            throw new NotImplementedException();
        }

        private static void AllReplaceMetod()
        {
            throw new NotImplementedException();
        }

        private static void AllDell()
        {
            throw new NotImplementedException();
        }

        private static void AddRead()
        {
            throw new NotImplementedException();
        }

        private static void GetRead()
        {
            throw new NotImplementedException();
        }
    }
}
