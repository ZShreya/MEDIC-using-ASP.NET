using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medic.Entities
{
    public class Product : BaseEntity
    {
        
        public string ImageURL { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }

        [Range(1, 100000)]
        public decimal Price { get; set; }
    }
}
