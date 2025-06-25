using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Model.DTO.ChartDTO
{
    public class XAxis
    {
        public XAxis(List<string> Categories)
        {
            this.Categories = Categories;
        }
        public List<string> Categories { get; set; }
    }
}
