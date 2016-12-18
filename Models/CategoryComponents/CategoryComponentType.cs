using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE.Models.CategoryComponents
{
    public class CategoryComponentType
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public long ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }
    }
}
