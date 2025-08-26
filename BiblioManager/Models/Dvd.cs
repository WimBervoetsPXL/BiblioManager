using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioManager.Models
{
    public class Dvd : LibraryItem
    {
        public string Director { get; set; }
        public int DurationInMinutes { get; set; }

        public Dvd(string title, string director, int durationInMinutes) : base(title)
        {
            Director = director;
            DurationInMinutes = durationInMinutes;
        }

        public override string GetDetails()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Director: {Director}");
            stringBuilder.AppendLine($"Duration: {DurationInMinutes}");
            return stringBuilder.ToString();
        }
    }
}
