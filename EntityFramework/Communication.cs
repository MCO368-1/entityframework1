using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework
{
    public class Communication
    {
        public int CommunicationId{ get; set; }
        public DateTime TimeStamp {get; set; }

        public Channel Channel { get; set; }

        [ForeignKey("Sender")]
        public int SenderId { get; set; }


        // Navigation Property ..not a real DB field (rather reesult join)
        public virtual Sender Sender { get; set; }
        public virtual List<Receiver> Receivers { get; set; }

    }

    public enum Channel
    {
        None = 0, Email = 2, WhatsApp = 7,
        [Obsolete]
        Sms = 10, 
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


        public int CommunicationId { get; set; }

        // Navigation Prop
        public Communication Communication { get; set; }
    }
}
