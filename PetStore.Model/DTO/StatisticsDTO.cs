using PetStore.Model.DTO.ChartDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Model.DTO
{
    public class StatisticsDTO
    {
        public List<ChartSerie> series { get; set; }
        public List<XAxis> xaxis { get; set; }

        public StatisticsDTO(IEnumerable<PetDTO> pets)
        {
            var chartSerie = new ChartSerie("Overzicht van de huisdieren", pets);
            this.series = [chartSerie];
            this.xaxis = [new XAxis(chartSerie.Labels.ToList())];
        }

        
    }
}
