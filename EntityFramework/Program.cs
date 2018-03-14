using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class MySuggestionDb : DbContext
    {
        public DbSet<Communication> Communications { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var db = new MySuggestionDb();

            db.Communications.Add(new Communication
            {
                TimeStamp = DateTime.UtcNow,
                Sender = new Sender { Email = "Yaakov"},
                Receivers = new List<Receiver> {
                    new Receiver{ Email = "Menashe"},
                    new Receiver{ Email = "Moshe"}}

            });
            db.SaveChanges();
            Console.WriteLine(db.Communications.Count());

            foreach (Communication c in db.Communications)
            {
                Console.WriteLine(c.Sender.Email + "=>>>" + c.Receivers.Count);
            }
            Console.ReadLine();
        }
    }
}
