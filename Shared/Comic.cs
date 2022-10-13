using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrudApp.Shared
{
    public class Comic
    {
        public int Id { set; get; }
        public string Name { set; get; } = string.Empty;
    }
}
