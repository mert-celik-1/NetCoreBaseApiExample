using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Core.Dtos.CategoryDtos
{
    public class CategoryAddDto
    {
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
