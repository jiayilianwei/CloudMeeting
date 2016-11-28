using System;
using System.Collections.Generic;
using System.Text;
using ESPlus.Application.CustomizeInfo.Server;
using ESBasic.Loggers;
using ESPlus.Application.CustomizeInfo;
using OVCS.Core;

namespace OVCS.Server
{
    class CustomizeInfoHandler :IIntegratedCustomizeHandler
    {
        public void HandleInformation(string sourceUserID, int informationType, byte[] info)
        {
            
        }

        public byte[] HandleQuery(string sourceUserID, int informationType, byte[] info)
        {          
            return null;
        }

        public bool CanHandle(int informationType)
        {
            return informationType >= 0 && informationType <= 100;
        }
    }
}
