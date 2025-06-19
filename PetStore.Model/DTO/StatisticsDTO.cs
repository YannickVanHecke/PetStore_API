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

        public StatisticsDTO(IEnumerable<PetDTO> pets)
        {
            this.Labels = GetPetKind(pets);

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
    }
}
