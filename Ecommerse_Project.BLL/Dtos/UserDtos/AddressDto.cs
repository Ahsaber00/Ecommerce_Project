using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos.UserDtos
{
    public class AddressDto
    {
        public string Country { get; set; }

        public string Governorate { get; set; }

        public string City { get; set; }
   
        public string Street { get; set; }
    }
}
