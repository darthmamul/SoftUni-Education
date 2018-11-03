using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SequenceWithQueue
{
    class SequenceWithQueue
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Queue<long> sequence = new Queue<long>();

            Console.Write($"{n} ");
            sequence.Enqueue(n);
            int count = 1;

            while (count < 50)
            {
                n = sequence.Dequeue();

                long s1 = n + 1;
                Console.Write($"{s1} ");
                sequence.Enqueue(s1);
                count++;

                if (count >= 50)
                {
                    break;
                }

                long s2 = 2 * n + 1;
                Console.Write($"{s2} ");
                sequence.Enqueue(s2);
                count++;

                if (count >= 50)
                {
                    break;
                }

                long s3 = n + 2;
                Console.Write($"{s3} ");
                sequence.Enqueue(s3);
                count++;

            }
        }
    }
}
