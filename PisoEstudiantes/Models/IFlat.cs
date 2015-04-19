using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PisoEstudiantes.Models
{
     public interface IFlat
    {
        //TODO (solo necesitamos estas 2 operaciones para este sprint)
        List<Flat> getLastFlats();
        List<Flat> getFlatsByProvince(string province);
    }
}
