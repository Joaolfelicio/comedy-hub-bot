using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Configuration.Contracts
{
    public interface IApplicationSettings
    {
        string ServicesToFetch { get; set; }
    }
}
