using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TheHealthyAssistant.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public bool Diabetes { get; set; }
        public bool Hypertension { get; set; }
        public DateTime Date { get; set; }

        //[PrimaryKey, AutoIncrement]
        //public int ID { get; set; }
        //public string Text { get; set; }
        //public DateTime Date { get; set; }
    }
}
