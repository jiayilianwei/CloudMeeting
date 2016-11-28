using System;
using System.Collections.Generic;
using System.Text;
using ESPlus.Application.Basic.Server;
using ESBasic.Loggers;
using System.Configuration;
using System.Security.Cryptography;


namespace OVCS.Server
{
    class BasicBusinessHandler : IBasicHandler
    {
        public bool VerifyUser(string systemToken, string userID, string password, out string failureCause)
        {
            failureCause = null;
            return true;
        }
    }    
}
