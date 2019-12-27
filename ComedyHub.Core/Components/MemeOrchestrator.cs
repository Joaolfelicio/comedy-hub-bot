using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Components
{
    public class MemeOrchestrator : IMemeOrchestrator
    {
        private readonly IMemeFetcher _memeFetcher;

        public MemeOrchestrator(IMemeFetcher memeFetcher)
        {
            _memeFetcher = memeFetcher;
        }

        public void MemeProcessor()
        {
            try
            {
                var meme = _memeFetcher.GetMeme();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
