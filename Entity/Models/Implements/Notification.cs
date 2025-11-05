using Entity.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Implements
{
    public class Notification : BaseModel
    {

        public int UserPlantId { get; set; }
        public UserPlant UserPlant { get; set; }

        /// <summary>
        /// Nivel de la notificación (Info, Warning, Critical)
        /// </summary>
        public string Level { get; set; } = "Info";

        public string Title { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Fecha y hora en que el usuario leyo la notificación
        /// </summary>
        public DateTime? AcknowledgedAt { get; set; }
    }
}
