using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioManager.Models
{
    public class Book : LibraryItem
    {
        public string Author { get; set; }
        public int Pages { get; set; }

        public Book(string title, string author, int pages) : base(title)
        {
            this.Author = author;
            this.Pages = pages;
        }

        public override string GetDetails()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Author: {Author}");
            stringBuilder.AppendLine($"Pages: {Pages}");
            return stringBuilder.ToString();
        }
    }
}
