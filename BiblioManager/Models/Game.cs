using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioManager.Models
{
    public class Game : LibraryItem
    {
        public string Platform { get; set; }
        public int Pegi { get; set; }

        public Game(string title, string platform, int pegi) : base(title) 
        {
            Platform = platform;
            Pegi = pegi;
        }

        public override string GetDetails()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Platform: {Platform}");
            stringBuilder.AppendLine($"Pegi: {Pegi}");
            return stringBuilder.ToString();
        }
    }
}
