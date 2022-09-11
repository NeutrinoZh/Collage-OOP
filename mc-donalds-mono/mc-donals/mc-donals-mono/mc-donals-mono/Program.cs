using System;
using System.Threading.Tasks;
using System.Threading;

namespace mcdonalsmono {
    class Program {
        private static void Successively() {
            Console.WriteLine("Successively:");

            Thread.Sleep(3000);
            Console.WriteLine("Finish Task 1");

            Thread.Sleep(2000);
            Console.WriteLine("Finish Task 2");

            Thread.Sleep(1000);
            Console.WriteLine("Finish Task 3");
        }

        private static void Wait() {
            Console.WriteLine("Wait:");

            Task[] tasks = new Task[3] {
                () => {
                    Thread.Sleep(3000);
                    Console.WriteLine("Finish Task 1");
                },
                () => {
                    Thread.Sleep(2000);
                    Console.WriteLine("Finish Task 2");
                },
                () => {
                    Thread.Sleep(1000);
                    Console.WriteLine("Finish Task 3");
                }
            }
        

            foreach (var item in tasks)
                    item.Start();
        }

        public static async Task Main(string[] args) {
            Successively();
            Wait();
        }
    }
}
