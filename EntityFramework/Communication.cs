using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework
{
    public class Communication
    {
        public int CommunicationId{ get; set; }
        public DateTime TimeStamp {get; set; }

        // Navigation Property ..not a real DB field
        public Sender Sender { get; set; }
        public List<Receiver> Receivers { get; set; }

    }

    public class Sender
    {
        public int SenderId { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
    }

    public class Receiver
    {
        public int ReceiverId { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
    }
}
