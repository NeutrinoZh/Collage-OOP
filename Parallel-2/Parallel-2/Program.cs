using System;
using System.Threading.Tasks;

namespace Parallel2 {
    class Program {
        public static double ParTrapezoidalRule(double a, double b, int n, Func<double, double> f) {
            double h = (b - a) / (n + 1);
            double sum = 0.5 * (f(a) + f(b));
            double[] innerSum = new double[n + 1];

            Parallel.For(1, n + 1, i => {
                innerSum[i] = f(a + i * h);
            });


            for (int j = 1; j <= n; j++)
                sum += innerSum[j];

            return h * sum;
        }

        public static double ParTrapezoidalRuleWithCorrection(double a, double b, int n, Func<double, double> f, Func<double, double> fp) {
            double h = (b - a) / (n + 1);
            double sum = 0.5 * (f(a) + f(b));
            double[] innerSum = new double[n + 1];

            Parallel.For(1, n + 1, i => {
                innerSum[i] = f(a + i * h);
            });


            for (int j = 1; j <= n; j++)
                sum += innerSum[j];

            return h * (sum + h * (fp(a) - fp(b)) / 12.0);
        }

        public static void Main(string[] args) {
            Console.WriteLine(ParTrapezoidalRule(0, 10, 4000, (x) => x * x * Math.Sin(x)));
            Console.WriteLine(ParTrapezoidalRuleWithCorrection(0, 10, 4000, (x) => x * x * Math.Sin(x), (x) => x));
        }
    }
}
