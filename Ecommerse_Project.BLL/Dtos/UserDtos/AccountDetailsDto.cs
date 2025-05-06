using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos.UserDtos
{
    public class AccountDetailsDto
    {


        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }

        public List<AddressDto> Address { get; set; }


    }
}
