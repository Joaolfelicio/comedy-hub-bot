using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Components
{
    public class MemeOrchestrator : IMemeOrchestrator
    {
        private readonly IMemeProcessor _memeProcessor;

        public MemeOrchestrator(IMemeProcessor memeProcessor)
        {
            _memeProcessor = memeProcessor;
        }

        public void Process()
        {
            try
            {
                var meme = _memeProcessor.ProcessMeme();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
