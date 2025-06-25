using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Model.DTO
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AnimalType { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Sex { get; set; }
        public Double Price { get; set; }
    }
}
