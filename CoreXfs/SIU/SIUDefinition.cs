﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CoreXfs.SIU
{
    public static class SIUDefinition
    {
        public const int WFS_SERVICE_CLASS_SIU = 8;
        public const int SIU_SERVICE_OFFSET = WFS_SERVICE_CLASS_SIU * 100;
        public const int WFS_SERVICE_CLASS_VERSION_SIU = 0x1403;
        #region SIU Info Commands 
        public const int WFS_INF_SIU_STATUS = SIU_SERVICE_OFFSET + 1;
        public const int WFS_INF_SIU_CAPABILITIES = SIU_SERVICE_OFFSET + 2;
        public const int WFS_INF_SIU_GET_AUTOSTARTUP_TIME = SIU_SERVICE_OFFSET + 3;
        #endregion
        #region SIU Command Verbs
        public const int WFS_CMD_SIU_ENABLE_EVENTS = SIU_SERVICE_OFFSET + 1;
        public const int WFS_CMD_SIU_SET_PORTS = SIU_SERVICE_OFFSET + 2;
        public const int WFS_CMD_SIU_SET_DOOR = SIU_SERVICE_OFFSET + 3;
        public const int WFS_CMD_SIU_SET_INDICATOR = SIU_SERVICE_OFFSET + 4;
        public const int WFS_CMD_SIU_SET_AUXILIARY = SIU_SERVICE_OFFSET + 5;
        public const int WFS_CMD_SIU_SET_GUIDLIGHT = SIU_SERVICE_OFFSET + 6;
        public const int WFS_CMD_SIU_RESET = SIU_SERVICE_OFFSET + 7;
        public const int WFS_CMD_SIU_POWER_SAVE_CONTROL = SIU_SERVICE_OFFSET + 8;
        public const int WFS_CMD_SIU_SET_AUTOSTARTUP_TIME = SIU_SERVICE_OFFSET + 9;
        #endregion
        #region SIU Messages
        public const int WFS_SRVE_SIU_PORT_STATUS = SIU_SERVICE_OFFSET + 1;
        public const int WFS_EXEE_SIU_PORT_ERROR = SIU_SERVICE_OFFSET + 2;
        public const int WFS_SRVE_SIU_POWER_SAVE_CHANGE = SIU_SERVICE_OFFSET + 3;
        #endregion

    }
    public enum GuidLights : ushort
    {
        WFS_SIU_CARDUNIT = 0,
        WFS_SIU_PINPAD = 1,
        WFS_SIU_NOTESDISPENSER = 2,
        WFS_SIU_COINDISPENSER = 3,
        WFS_SIU_RECEIPTPRINTER = 4,
        WFS_SIU_PASSBOOKPRINTER = 5,
        WFS_SIU_ENVDEPOSITORY = 6,
        WFS_SIU_CHEQUEUNIT = 7,
        WFS_SIU_BILLACCEPTOR = 8,
        WFS_SIU_ENVDISPENSER = 9,
        WFS_SIU_DOCUMENTPRINTER = 10,
        WFS_SIU_COINACCEPTOR = 11,
        WFS_SIU_SCANNER = 12
    }
    [Flags]
    public enum LightControl : ushort
    {
        WFS_SIU_OFF = 0x0001,
        WFS_SIU_ON = 0x0002,
        WFS_SIU_SLOW_FLASH = 0x0004,
        WFS_SIU_MEDIUM_FLASH = 0x0008,
        WFS_SIU_QUICK_FLASH = 0x0010,
        WFS_SIU_CONTINUOUS = 0x0080
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSSIUSETGUIDLIGHT
    {
        public ushort wGuidLight;
        public LightControl fwCommand;
    }
}
