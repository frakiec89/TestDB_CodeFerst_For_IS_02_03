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

        private static string GetStringContentConsole(string message)
        {
            Console.WriteLine(message);
            string content = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("Не корректный ввод");
                Console.WriteLine("Попробуйте еще раз");
                return GetStringContentConsole(message);
            }
            return content.TrimStart().TrimEnd();
        }

        private static void GetStatus()
        {
            Console.WriteLine("Список всех статусов в  записях:");
            try
            {
                RecordService.GetStatus().ForEach(x => Console.WriteLine(x));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Remove()
        {
            Console.WriteLine("удаление записи");
            int id = GetInetegerContentConsole("укажите  id записи");

            try
            {
                RecordService.RemoveRecord(id);
                Console.WriteLine("запись удалена!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static int GetInetegerContentConsole(string message)
        {
            var s = GetStringContentConsole(message);
            try
            {
                var id = int.Parse(s);
                if (id < 0)
                {
                    Console.WriteLine("вы ввели отрицательный  id - так не  пойдет!");
                    Console.WriteLine("Попробуйте еще раз");
                    return GetInetegerContentConsole(message);
                }
                return Convert.ToInt32(s);
            }
            catch (Exception ex)
            {
                Console.WriteLine("нам очень жаль но вы ввели не число ( ");
                Console.WriteLine("Попробуйте еще раз");
                return GetInetegerContentConsole(message);
            }
        }

        private static void AllReplaceMetodForever()
        {
            Console.WriteLine("Удаление  всех записей - Вы уверены (yes/no)");
            try
            {
                if (Console.ReadLine().ToLower().TrimStart().TrimEnd() == "yes")
                {
                    RecordService.DeleteAtAllForever();
                    Console.WriteLine("Все записи  удалены (  , серьезно все ");
                }
                else
                {
                    Console.WriteLine("мы рады что  вы передумали");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AllReplaceMetod()
        {
            try
            {
                RecordService.AllReplace();
                Console.WriteLine("Записи восстановлены");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AllDell()
        {
            try
            {
                RecordService.AllRemove();
                Console.WriteLine("Записи удалены");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddRead()
        {
            Console.WriteLine("Добавление новой записи:");
            string content = GetStringContentConsole("Введи контент");
            string status = GetStringContentConsole("укажите статус  сообщения");

            try
            {
                RecordService.AddRecord(content, status);
                Console.WriteLine("Запись добавлена - ура");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetRead()
        {
            Console.WriteLine("Список активных записей:");
            try
            {
                RecordService.GetRecord().ForEach(x => Console.WriteLine(x));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
