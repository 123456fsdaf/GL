﻿using GenshinImpact_Lanucher.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinImpact_Lanucher.EventArgs
{
    public class Models
    {
    }

    public class ProxyEvnetArgs
    {
        public ProxyArgs Proxy { get; set; }
        public XmlProxy Stuate { get; set; }
    }

    public enum XmlProxy
    {
        Add,Remove,Updata
    }
}