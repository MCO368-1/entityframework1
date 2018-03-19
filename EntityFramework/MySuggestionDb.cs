using System.Data.Entity;

namespace EntityFramework
{
    class MySuggestionDb : DbContext
    {
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Receiver> Receivers { get; set; }
        // public DbSet<Foobar> Foobars { get; set; }
    }

    class Foobar
    {
        public int FoobarId{ get; set; }
    }
}