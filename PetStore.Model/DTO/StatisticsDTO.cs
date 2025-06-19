using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Model.DTO
{
    public class StatisticsDTO
    {
        public List<string> Labels { get; set; }
        public Dictionary<int, int> Data { get; set; }

        public StatisticsDTO(IEnumerable<PetDTO> pets)
        {
            this.Labels = GetPetKind(pets);
            this.Data = MapPets(pets);

        }

        private List<string> GetPetKind(IEnumerable<PetDTO> pets)
        {
            var labels = new List<string>();

            foreach (var pet in pets)
            {
                if (!labels.Contains(pet.Name))
                {
                    labels.Add(pet.Name);
                }
            }

            return labels;
        }

        private Dictionary<int, int> MapPets(IEnumerable<PetDTO> pets) { 
            var data = new Dictionary<int, int>();
            foreach (var pet in pets)
            {
                if(!data.Keys.Contains(pet.AnimalType)) {

                    data.Add(pet.AnimalType, 1);
                }
                else
                {
                    var numberOfPets = data[pet.AnimalType];
                    numberOfPets++;
                    data.Remove(pet.AnimalType);
                    data.Add(pet.AnimalType, numberOfPets);
                }
            }
            return data;
        }
    }
}
