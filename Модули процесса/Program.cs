/* Created by SharpDevelop.
* User: user
* Date: 27.12.2012
* Time: 11:05
*
* To change this template use Tools | Options | Coding |
* Edit Standard Headers. */
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;

namespace app72_proc_modul
{
    class Program
    {
        public static Process theProc;
        public int pID;
        // Метод вывода списка модулей процесса
        static void EnumModsForPid(int pID)
        {
            Process theProc = null;
            try
            { theProc = Process.GetProcessById(pID); }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("Модули, загруженные " +
            "процессором: {0}", theProc.ProcessName);
            try
            {
                ProcessModuleCollection theMods = theProc.Modules;
                // Тип свойства Modules — ProcessModuleCollection,
                // а значение — массив ProcessModule
                foreach (ProcessModule pm in theMods)
                {
                    string info = string.Format("-> Имя модуля: " +
                    "{0}", pm.ModuleName);
                    Console.WriteLine(info);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        } // метод
          // Определение процесса по его идентификатору
        static void EnumThreadsForPid(int pID)
        {
            theProc = null; // Process
            try

            {
                theProc = Process.GetProcessById(pID);
                Console.WriteLine("Имя компьютера: {0}",
                theProc.MachineName);
                if (theProc.MachineName == ".")
                    Console.WriteLine("Имя компьютера: текущий");
            }
catch (ArgumentException ex)
            { Console.WriteLine(ex.Message); }
        }
        public static void Main()
        {
            while (true)
            { // Ввод идентификатора процесса
                Console.WriteLine("Введите идентификатор " +
                "исследуемого процесса (<->) — конец > ");
                Console.Write("PID: ");
                string pID = Console.ReadLine();
                if (pID == "")
                    pID = Console.ReadLine();
                if (pID == "-")
                    break;
                int theProcID = int.Parse(pID);
                EnumThreadsForPid(theProcID);
                EnumModsForPid(theProcID);
                Console.WriteLine("************* ^ " +
                "********************** \n");
                Console.Read();
            } // while
            Console.Read();
        } // Main()
    } // Program
} // NameSpace