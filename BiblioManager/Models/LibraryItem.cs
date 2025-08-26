using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioManager.Models
{
    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public bool IsAvailable { get; set; }
        public string Borrower { get; set; }

        public string ItemType => GetType().Name; // "Book", "Dvd", "Game"

        protected LibraryItem(string Title)
        {
            this.Title = Title;
            this.IsAvailable = true;
        }

        public bool LoanTo(string borrowerName)
        {
            if (!IsAvailable)
            {
                return false;
            }

            if(string.IsNullOrEmpty(borrowerName))
            {
                return false;
            }
            
            IsAvailable = false;
            Borrower = borrowerName;
            return true;
        }

        public void Return()
        {
            IsAvailable = true;
            Borrower = null;
        }

        private string GetStatus()
        {
            if(IsAvailable)
            {
                return "Available";
            }
            else
            {
                return "Loaned to " + Borrower;
            }
        }

        public abstract string GetDetails();

        public override string ToString()
        {
            return $"{ItemType}: {Title} - {GetStatus()}";
        }
    }
}
