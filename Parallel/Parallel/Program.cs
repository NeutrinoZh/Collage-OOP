using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Text;

namespace MyProgram {
    class Program {
        public static void Main(string[] args) {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            string[] urls = {
                "google.com",
                "jgfhlghdf.com",
                "google.com",
                "jgfhlghdf.com",
                "google.com",
                "jgfhlghdf.com",
                "google.com",
                "jgfhlghdf.com",
                "google.com",
                "jgfhlghdf.com",
                "google.com",
                "jgfhlghdf.com",
                "google.com",
                "jgfhlghdf.com",
                "google.com",
                "jgfhlghdf.com",
                "google.com",
                "jgfhlghdf.com",
                "google.com",
                "jgfhlghdf.com",
            };

            Parallel.ForEach(urls, (url) => {
                PingReply reply = pingSender.Send(url, timeout, buffer, options);

                StringBuilder ss = new StringBuilder();

                ss.AppendLine("Ping to " + url);
                if (reply.Status == IPStatus.Success) {
                    ss.AppendLine("Address: " + reply.Address.ToString());
                    ss.AppendLine("RoundTrip time: " + reply.RoundtripTime);
                    ss.AppendLine("Time to live: " + reply.Options.Ttl);
                    ss.AppendLine("Don't fragment: " + reply.Options.DontFragment);
                    ss.AppendLine("Buffer size: " + reply.Buffer.Length);
                } else {
                    ss.AppendLine("Failed");
                }

                Console.WriteLine(ss.ToString());
            });
        }
    }
}
