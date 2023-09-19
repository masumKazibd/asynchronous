using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for even number
            for (int i = 1; i<= 20; i++)
            {

                if (i%2== 0)
                {
                    Run(i);
                }
            }

            //for odd number || Factorial Number
            for (int i = 1; i<=20; i++)
            {
                if(i%2== 1)
                {
                    _Run(i);
                }
            }
            Console.ReadKey();
        }
        private static void Run(int n)
        {
            Task.Run(() => {
                return EvenNumber(n);
            }).ContinueWith(t =>
            {
                Console.WriteLine($"{n}!= {t.Result}");
            });
        }

        static async Task<long> EvenNumber(int n)
        {
            int fact = 1;
            await Task.Run(() =>
            {
                for (int i = 1; i <= n; i++)
                {
                    fact = fact + i;
                }
            });
            return fact;
        }
        //For Odd Number || Factorial Number
        private static  void _Run(int n)
        {
            Task.Run(() =>
            {
                return oddNumber(n);
            }).ContinueWith(t =>
            {
                Console.WriteLine($"{n}! = {t.Result}");
            });
        }
        static async Task<long>oddNumber(int n)
        {
            int fact = 1;
            await Task.Run(() =>
            {
                for(int i=1; i<=n; i++)
                {
                    fact = fact + i;
                }
            });
            return fact;
        } 
    }
}
