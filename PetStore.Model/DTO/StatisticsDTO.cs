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
        public Dictionary<string, int> Data { get; set; }

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

        private Dictionary<string, int> MapPets(IEnumerable<PetDTO> pets) { 
            var data = new Dictionary<string, int>();
            foreach (var pet in pets)
            {
                if(!data.Keys.Contains(pet.Name)) {
                    data.Add(pet.Name, 1);
                }
                else
                {
                    var numberOfPets = data[pet.Name];
                    numberOfPets++;
                    data.Remove(pet.Name);
                    data.Add(pet.Name, numberOfPets);
                }
            }
            return data;
        }

    }
}
