using PetStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data.Repositoriy.Interface
{
    public interface IPetRepository
    {
        IEnumerable<Pet> FindAll();
        void Add(Pet pet);
        void SaveChanges();

    }
}
