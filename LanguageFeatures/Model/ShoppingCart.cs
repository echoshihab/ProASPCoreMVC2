using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Model
{
    public class ShoppingCart
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
