﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos.UserDtos
{
    public class PasswordChangeDto
    {
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
