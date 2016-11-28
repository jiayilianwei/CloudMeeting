using System;
using System.Collections.Generic;
using System.Text;

namespace OVCS.Core
{
    /// <summary>
    /// 自定义信息的类型
    /// </summary>
    public static class InformationTypes
    {
        #region 广播消息
        /// <summary>
        /// 广播聊天信息
        /// </summary>
        public const int BroadcastChat = 0;
        /// <summary>
        /// 广播Sharing desktop
        /// </summary>
        public const int BroadcastShareDesk = 1;       
        #endregion

        #region p2p消息

        /// <summary>
        /// 授权或者取消远程控制
        /// </summary>
        public const int ControlDesktop = 52;
        /// <summary>
        /// Sharing desktop
        /// </summary>
        public const int ShareDesk = 53;    
        #endregion      
       
    }
}
