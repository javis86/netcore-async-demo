using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace async_1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var task1 = longProcessAsync(1);
            Console.WriteLine("Tarea Creada 1");

            var task2 = longProcessAsync(2);
            Console.WriteLine("Tarea Creada 2");

            var task3 = longProcessAsync(3);
            Console.WriteLine("Tarea Creada 3");


            // AWAIT 1 a 1
            
            int resultado1 = await task1;
            Console.WriteLine("Tarea 1 Finalizada con {0}", resultado1.ToString());
            int resultado2 = await task2;
            Console.WriteLine("Tarea 2 Finalizada con {0}", resultado2.ToString());
            int resultado3 = await task3;
            Console.WriteLine("Tarea 3 Finalizada con {0}", resultado3.ToString());
            
             

            // WHEN ALL
            /*
            int[] whenResults = await Task.WhenAll(task1, task2, task3);            
            Console.WriteLine("Todas las Tareas finalizadas");

            int i = 1;
            foreach(int taskValue in whenResults)
                Console.WriteLine("Tarea {0} Finalizada con {1} ms", i++, taskValue);
            
             */

            // WHEN ANY
            /*
            var allTasks = new List<Task<int>> { task1, task2, task3 };

            while (allTasks.Any())
            {
                Task<int> finished = await Task.WhenAny(allTasks);
                if (finished == task1)
                {
                    Console.WriteLine("Tarea 1 Finalizada con {0} ms", finished.Result);
                }
                else if (finished == task2)
                {
                    Console.WriteLine("Tarea 2 Finalizada con {0} ms", finished.Result);
                }
                else if (finished == task3)
                {
                    Console.WriteLine("Tarea 3 Finalizada con {0} ms", finished.Result);
                }
                allTasks.Remove(finished);
            }
            Console.WriteLine("Todas las Tareas finalizadas");
             */
        }

        private static async Task<int> longProcessAsync(int proccessID)
        {
            Random random = new Random();
            int val = proccessID == 1 ? random.Next(10000) : random.Next(1000);
            await Task.Delay(val);

            return val;
        }
    }
}
