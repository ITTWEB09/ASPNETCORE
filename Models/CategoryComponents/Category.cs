using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE.Models.CategoryComponents
{
    public class Category
    {
        public Category()
        {
            CategoryComponentTypes = new List<CategoryComponentType>();
        }

        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryComponentType> CategoryComponentTypes { get; protected set; }
    }
}
