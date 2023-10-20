using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOOSportTovars.Classes
{
    internal class Helper
    {
        // Объявление объекта
        public static Model.SportTovarsEntities DB { get; set; }
        public static List<Model.User> Users = new List<Model.User>();
    }
}
