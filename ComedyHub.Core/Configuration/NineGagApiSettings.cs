﻿using ComedyHub.Core.Configuration.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Configuration
{
    public class NineGagApiSettings : INineGagApiSettings
    {
        public string Url { get ; set ; }
    }
}