﻿using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO_s
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
