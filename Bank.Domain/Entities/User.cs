﻿using Bank.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Entities
{
    public class User : Auditable
    {
        public string Ism { get; set; }
        public string Familya { get; set; }
        public int Yoshi { get; set; }

    }
}
