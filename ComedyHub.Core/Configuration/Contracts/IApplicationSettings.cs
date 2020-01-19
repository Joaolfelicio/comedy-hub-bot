using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Configuration.Contracts
{
    public interface IApplicationSettings
    {
        string ServicesToFetch { get;}
        string DefaultTags { get; }
        string ImagesExtensions { get; }
        int SizeLimitMegaBytes { get; }
    }
}
