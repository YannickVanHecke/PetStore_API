using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Model.DTO.ChartDTO
{
    public class ChartSerie
    {
        public string Name { get; set; }
        public int[] Data { get; set; }
        public string[] Labels = new string[] { "vogel", "kat", "hond", "vis" };
        public ChartSerie(string Name, IEnumerable<PetDTO> pets)
        {
            this.Name = Name;
            var petsDictionary = this.MapPets(pets);
            this.Data = petsDictionary.Values.ToArray();
        }

        private Dictionary<string, int> MapPets(IEnumerable<PetDTO> pets)
        {
            var result = new Dictionary<string, int>();


            foreach (var petKind in this.Labels)
            {
                var number = pets.Count(pet => pet.AnimalType == Array.IndexOf(Labels, petKind));
                result.Add(petKind, number);
            }

            return result;
        }
    }
}
