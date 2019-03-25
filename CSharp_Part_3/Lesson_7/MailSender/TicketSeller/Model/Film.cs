using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSeller.Model
{
    public class Film
    {
        public string Title { get; set; }

        public Film() { }
        public Film(string title)
        {
            Title = title;
        }
    }
}
