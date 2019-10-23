using System;
using System.Threading.Tasks;

namespace sync_program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicia el programa");

            int proc1 = longProcess(1);
            Console.WriteLine("Tarea 1 Finalizada con {0} ms", proc1);
            int proc2 = longProcess(2);
            Console.WriteLine("Tarea 2 Finalizada con {0} ms", proc2);
            int proc3 = longProcess(3);
            Console.WriteLine("Tarea 3 Finalizada con {0} ms", proc3);

        }

        private static int longProcess(int proccessID)
        {
            Random random = new Random();
            int val = proccessID == 1 ? random.Next(10000) : random.Next(1000);
            System.Threading.Thread.Sleep(val);

            return val;
        }

        
    }
}
