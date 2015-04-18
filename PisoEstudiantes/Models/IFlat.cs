using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PisoEstudiantes.Models
{
    interface IFlat
    {
        //TODO (solo necesitamos estas 2 operaciones para este sprint)
        public List<Flat> getAllFlats();
        public List<Flat> getFlatsByProvince(string province);
    }
}
