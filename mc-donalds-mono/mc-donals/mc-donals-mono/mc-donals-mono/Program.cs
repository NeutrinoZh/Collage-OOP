using System;
using System.Threading.Tasks;
using System.Threading;

namespace mcdonals {
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
                new Task(() => {
                    Thread.Sleep(3000);
                    Console.WriteLine("Finish Task 1");
                }),
                new Task(() => {
                    Thread.Sleep(2000);
                    Console.WriteLine("Finish Task 2");
                }),
                new Task(() => {
                    Thread.Sleep(1000);
                    Console.WriteLine("Finish Task 3");
                })
            };

            foreach (var item in tasks)
                item.Start();

            Task.WaitAll(tasks);
        }

        public static void First() {
            Console.WriteLine("First:");

            Task[] tasks = new Task[3] {
                new Task(() => {
                    Thread.Sleep(3000);
                    Console.WriteLine("Finish Task 1");
                }),
                new Task(() => {
                    Thread.Sleep(2000);
                    Console.WriteLine("Finish Task 2");
                }),
                new Task(() => {
                    Thread.Sleep(1000);
                    Console.WriteLine("Finish Task 3");
                })
            };

            foreach (var item in tasks)
                item.Start();

            Task.WaitAny(tasks);
        }

        public static void All() {
            Console.WriteLine("All:");

            Task[] tasks = new Task[3] {
                new Task(() => {
                    Thread.Sleep(3000);
                    Console.WriteLine("Finish Task 1");
                }),
                new Task(() => {
                    Thread.Sleep(2000);
                    Console.WriteLine("Finish Task 2");
                }),
                new Task(() => {
                    Thread.Sleep(1000);
                    Console.WriteLine("Finish Task 3");
                })
            };

            foreach (var item in tasks)
                item.Start();

            Thread.Sleep(5000);
        }

        public static void Main(string[] args) {
            Successively();
            Wait();
            All();
            First();
        }
    }
}