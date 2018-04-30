using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<MySuggestionDb>(
                new DropCreateDatabaseIfModelChanges<MySuggestionDb>());
            // NEVER USE IN PRODUCTION
            var db = new MySuggestionDb();
            db.SaveChanges();

            db.Communications.Add(new Communication
            {
                TimeStamp = DateTime.UtcNow,
                Sender = new Sender { Email = "Yaakov" },
                Receivers = new List<Receiver> {
                    new Receiver{ Email = "Menashe"},
                    new Receiver{ Email = "Moshe"}},
               

            });
            db.SaveChanges();
            Console.WriteLine(db.Communications.Count());

            foreach (Communication c in db.Communications)
            {
                Console.WriteLine(c.Channel);
                Console.WriteLine(c.Sender.Email + "=>>>" + c.Receivers.Count);
            }


            var r = new Receiver
            {
                CommunicationId = 1,
                Email = "NotEdon"
            };
            db.Receivers.Add(r);
            db.SaveChanges();


            r = new Receiver
            {
                //CommunicationId = 1,
                Communication = db.Communications.First(),
                Email = "NotEdonAgain!!!!"
            };
            db.Receivers.Add(r);
            db.SaveChanges();

            var comm = db.Communications.First();
            comm.Receivers.Add(new Receiver
            {
                Email = "BobEdon"
            });
            db.SaveChanges();

            var list2 = db.Communications.Where(c => Contains(c.Sender.Email,"v"))
                .ToList();
            foreach (var c in list2)
            {
                Console.WriteLine(c.Sender.Email);
            }


            Console.ReadLine();
        }

        private static bool Contains(string senderEmail, string s)
        {
            return senderEmail.Contains(s);
        }
    }
}
