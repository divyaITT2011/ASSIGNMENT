using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Publication
    {
        public String bookPublisher;
        // Price of the publication.
        private double price;

        public String getbookPubl()
        {
            return this.bookPublisher;
        }

        public void setbookPub(String bookPublisher)
        {
            this.bookPublisher = bookPublisher;
        }

        public void setPrice(double price)
        {
            if (price > 0)
            {
                this.price = price;
            }
            else
            {
                Console.WriteLine("Invalid price");
            }
        }

        public double getPrice()
        {
            return this.price;
        }
    }
}
