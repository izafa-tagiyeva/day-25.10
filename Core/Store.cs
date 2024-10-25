using Core.helper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Store
    {


        private Product[] _products = new Product[0];
        private int _count = 0;

       
        public void AddProduct(Product product)
        {
            if (_count >= _products.Length)
            {
                Array.Resize(ref _products, _count + 1);
            }
            _products[_count] = product;
            _count++;
        }

        
        public void RemoveProductByNo(int no)
        {
        }

        
        public Product? GetProduct(int? no)
        {
            if (no == null) return null;

            for (int i = 0; i < _count; i++)
            {
                if (Product.No == no)
                {
                    return _products[i];
                }
            }
            return null;
        }

        
        public Product[] FilterProductsByType(Types type)
        {
            int filterCount = 0;
            for (int i = 0; i < _count; i++)
            {
                if (_products[i].type == type)
                {
                    filterCount++;
                }
            }

            Product[] filteredProducts = new Product[filterCount];
            int index = 0;
            for (int i = 0; i < _count; i++)
            {
                if (_products[i].type == type)
                {
                    filteredProducts[index++] = _products[i];
                }
            }
            return filteredProducts;
        }

       
        public Product[] FilterProductByName(string name)
        {
            int filterCount = 0;
            for (int i = 0; i < _count; i++)
            {
                if (_products[i].Name.ToLower().Contains(name.ToLower()))
                {
                    filterCount++;
                }
            }

            Product[] filteredProducts = new Product[filterCount];
            int index = 0;
            for (int i = 0; i < _count; i++)
            {
                if (_products[i].Name.ToLower().Contains(name.ToLower()))
                {
                    filteredProducts[index++] = _products[i];
                }
            }
            return filteredProducts;
        }
    }

}

/*Store class
- Products
- AddProduct()
- RemoveProductByNo() - no dəyəri qəbul edir və həmin dəyərli product obyektini products siyahısından çıxarır
- GetProduct() -> nullable int No deyeri qebul edir eger hemin no'ya uygun product varsa geriye qaytarir
- FilterProductsByType() - type dəyəri qəbul edir və həmin dəyərli productlardan ibarət array qaytarır
- FilterProductByName() - string dəyər qəbul edir və name dəyərində həmin string dəyər olan bütün productlardan ibarət siyahı qaytarır
*/