using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFilmsApp
{
    public class CDisplayData 
    {
        public int Id { get; set; }
        public string Display { get; set; }
        public bool Chosen { get; set; }
        public CDisplayData(int Id, string Display, bool Chosen)
        {
            this.Id = Id;
            this.Display = Display;
            this.Chosen = Chosen;
        }
    }
}
