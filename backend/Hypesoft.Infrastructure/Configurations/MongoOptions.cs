using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypesoft.Infrastructure.Configurations
{
    public class MongoOptions
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;

        public string CategoriesCollection { get; set; } = "categories";
        public string ProductsColletion { get; set; } = "products";


    }
}
