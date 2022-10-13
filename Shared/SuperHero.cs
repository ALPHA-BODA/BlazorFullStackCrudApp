using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrudApp.Shared
{
    public class SuperHero
    {
        public int Id { set; get; }
        public string FirstName { set; get; } = string.Empty;

        public string LastName { set; get; } = string.Empty;

        public string HeroName { set; get; } = string.Empty; 
        public Comic? Comic  { set; get; }

        public int ComicId { set; get; }



    }
}
