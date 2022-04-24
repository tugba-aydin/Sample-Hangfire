using System;

namespace HangfireExample.Service
{
    public class JobService : IJobService
    {
        /* Recurring Jobs
        Belirlenen CRON zamanlamasına göre tekrarlanan işler tanımlanır.*/

        /*Fire-And-Forget Jobs
        İş tanımlanır ve hemen ardından bir kereye mahsus tetiklenir.*/

        /*Delayed Jobs
        Oluşturulduktan belirli bir zaman sonra sadece bir seferliğine tetiklenecek olan görevler tanımlanır. */

        /* Continuations Jobs
        Birbiriyle ilişkili işlerin olduğu durumlarda alınan aksiyondur. Bir jobun tetiklenebilmesi için bir öncekinin tamamlanması gerekmektedir.*/

        public void ContinuationJob()
        {
            Console.WriteLine("Hello from a Continuation job!");
        }

        public void DelayedJob()
        {
            Console.WriteLine("Hello from a Delayed job!");
        }

        public void FireAndForgetJob()
        {
            Console.WriteLine("Hello from a Fire and Forget job!");
        }

        public void ReccuringJob()
        {
            Console.WriteLine("Hello from a Reccuring job!");
        }
    }
}
