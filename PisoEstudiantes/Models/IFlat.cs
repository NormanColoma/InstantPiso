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
        List<Flat> getLastFlats();
        List<Flat> getFlatsByProvince(string province);
        List<Flat> getFlatsByOwner(string email);
        bool insertFlat(Flat f);

        Flat getFlat(int id);

        List<Schedule> getSchedule(int id_flat);

        
    }
}
