using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.DTOs
{
    public class UserAddressDto
    {
       
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Cannot put the empty House number and street")]
        public string Street { get; set; }
        public string WardId { get; set; }
        [Required(ErrorMessage = "Cannot put the empty name reminiscent")]
        public string NameReminiscent { get; set; }
        public string PhoneNumber { get; set; }
    }
}
