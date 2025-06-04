using PetStore.Data.Model;
using PetStore.Data.Repositoriy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data.Repositoriy
{
    public class PetRepository : IPetRepository
    {
        private PetStoreContext context;
        public PetRepository(PetStoreContext context)
        {
            this.context = context;
        }

        public void Add(Pet pet)
        {
            this.context.Add(pet);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
