using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace semaphore.test
{
    class Program
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(10);
        static System.Threading.Semaphore S = new System.Threading.Semaphore(10,10);
        
        static async Task Main(string[] args)
        {
                        
            RunOnSemaphore();            

            await RunOnShemaphoreSlim();
        }

        private static void RunOnSemaphore()
        {
            System.Diagnostics.Stopwatch watch;
            int i;
            

            watch = System.Diagnostics.Stopwatch.StartNew();
            List<Task> tareas = new List<Task>();
            i = 0;
            while (i < 50)
            {
                i++;
                //Console.WriteLine($"Proceso {i} Lanzado");

                longProccess(i);
            }

             watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Time elapsedMS {elapsedMs.ToString()}");
        }

        private static async Task<int> RunOnShemaphoreSlim()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<Task> tareas = new List<Task>();
            int i = 0;
            while (i < 50)
            {
                i++;
                await semaphoreSlim.WaitAsync();
                //Console.WriteLine($"Proceso {i} Lanzado");

                longProccess3(i);
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Time elapsedMS {elapsedMs.ToString()}");
            return i;
        }

        private static async void longProccess(int i)
        {         
            S.WaitOne();
            Console.WriteLine($"Proceso {i} ejecutado");     
            await Task.Delay(1000);     
            semaphoreSlim.Release();
            S.Release();                 
        }


        private static async void longProccess3(int i)
        {         
            
            Console.WriteLine($"Proceso {i} ejecutado");     
            await Task.Delay(1000);     
            semaphoreSlim.Release();                
        }

    }
}
