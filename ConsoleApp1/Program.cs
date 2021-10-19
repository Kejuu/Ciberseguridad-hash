using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            getHash("1");

        }
        public static void getHash(string n)
        {
            int iteraciones = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (true)
            {

                
                iteraciones = iteraciones + 1;
                var bytes = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(bytes);
                }
                string hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                string ncharacters = hash.Substring(0, Convert.ToInt32(n));
                var comparador = StringComparer.InvariantCultureIgnoreCase;
                Console.WriteLine(ncharacters + "\n\n");

                var result = from a in ncharacters.ToUpper().ToCharArray()
                             where a.Equals('0')
                             group a by a into g
                             select new
                             {
                                 Repeticiones = g.Count()
                             };

            
                if(result.FirstOrDefault() != null)
                {
                    int num = result.FirstOrDefault().Repeticiones;
                    if ( num == Convert.ToInt32(n))
                    {
                        Console.WriteLine(hash);
                        Console.WriteLine("Iteracciones: " + iteraciones);
                        sw.Stop(); 
                        Console.WriteLine("Time elapsed: {0}", sw.Elapsed.ToString("hh\\:mm\\:ss\\.fff"));
                        break;
                    }

                }
               
      
            }
        }


        }
    }

