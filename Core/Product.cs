using Core.helper.Enums;
using Core.helper.Exceptions;

namespace Core
{
    public class Product
    {
        public static int No;
        public Types type {  get; set; }
       
        public string Name;

        private double _price;

        public Product(Types type, string name, double price)
        {
            this.type = type;
            Name = name;
            _price = price;
        }

        public double Price
        {
            get { return _price; }
            set
            {

                if (value > 0)
                {
                    throw new PriceMustBeGratherThanZeroException("Price must be greater than zero");
                }
                else
                {
                    _price = value;
                }
            }

        }






    }
}
/*- No -> her obyekt yarananda +1 vahid artacaq
- Name
- Price -> encapsulation edirsiniz, eger price 0dan ashagi gonderilibse, PriceMustBeGratherThanZeroException geriye qaytarirsiniz
- Type (Baker,Drink,Meat,Diary) Enums
Name, Price, Type deyeri olmadan, Product yarana bilmez.*/