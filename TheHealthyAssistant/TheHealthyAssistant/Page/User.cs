using System;
using System.Collections.Generic;
using System.Text;

namespace TheHealthyAssistant.Page
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public bool Diabetes { get; set; }
        public bool Hypertension { get; set; }
    }
}
