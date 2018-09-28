using System;
using System.Data.Entity;

namespace WebApplication3.Models
{
    public class Event
    {

        public int ID { get; set; }
        public string NazwaWydarzenia { get; set; }
        public string OpisWydarzenia { get; set; }
        public string CenaBiletu { get; set; }
        public string MiejsceWydarzenia { get; set; }
        public DateTime  DataWydarzenia { get; set; }
        public string GodzinaRozpoczeciaImprezy { get; set; }
        

        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


       
    }
}