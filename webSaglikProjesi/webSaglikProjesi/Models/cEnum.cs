﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webSaglikProjesi.Models
{
    public class cEnum
    {
        public enum SatisDurumu : byte {

            siparis=1,
            odemeonay=2,
            hazirlama=3,
            kargo=4,
            tesliim=5,
        }
    }
}