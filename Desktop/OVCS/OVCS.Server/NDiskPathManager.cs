using System;
using System.Collections.Generic;
using System.Text;
using ESFramework.Boost.NetworkDisk.Server;

namespace OVCS.Server
{
    class NDiskPathManager : NetworkDiskPathManager
    {
        public override string GetNetworkDiskIniDirName(string clientUserID, string netDiskID)
        {
            return netDiskID;
        }

        public override ulong GetNetworkDiskSizeUsed(string clientUserID, string netDiskID)
        {
            return 0;
        }     
    }
}
