﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shakelx.EFSimple.Core.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string HuKou { get; set; }
    }
}
