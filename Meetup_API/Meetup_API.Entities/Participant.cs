using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup_API.Entities
{
    public class Participant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public Boolean Profession { get; set; }
        public string Locality { get; set; }
        public int NumGuests { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
    }
}
