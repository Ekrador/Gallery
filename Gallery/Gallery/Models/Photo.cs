using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Models
{
    public class Photo
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Date { get; set; }

        public Photo(string name, string fullName, DateTime date)
        {
            Name = name;
            FullName = fullName;
            Date = date.ToShortDateString();
        }
    }
}
