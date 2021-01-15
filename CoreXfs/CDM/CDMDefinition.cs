using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CoreXfs
{
    public static class CDMDefinition
    {
        public const int WFS_SERVICE_CLASS_CDM = 3;
        public const int WFS_SERVICE_CLASS_VERSION_CDM = 0x1403;
        public const string WFS_SERVICE_CLASS_NAME_CDM = "CDM";
        public const int CDM_SERVICE_OFFSET = WFS_SERVICE_CLASS_CDM * 100;
        #region CDM Info Commands
        public const int WFS_INF_CDM_STATUS = CDM_SERVICE_OFFSET + 1;
        public const int WFS_INF_CDM_CAPABILITIES = CDM_SERVICE_OFFSET + 2;
        public const int WFS_INF_CDM_CASH_UNIT_INFO = CDM_SERVICE_OFFSET + 3;
        public const int WFS_INF_CDM_TELLER_INFO = CDM_SERVICE_OFFSET + 4;
        public const int WFS_INF_CDM_CURRENCY_EXP = CDM_SERVICE_OFFSET + 6;
        public const int WFS_INF_CDM_MIX_TYPES = CDM_SERVICE_OFFSET + 7;
        public const int WFS_INF_CDM_MIX_TABLE = CDM_SERVICE_OFFSET + 8;
        public const int WFS_INF_CDM_PRESENT_STATUS = CDM_SERVICE_OFFSET + 9;
        #endregion
        #region CDM Execute Commands
        public const int WFS_CMD_CDM_DENOMINATE = CDM_SERVICE_OFFSET + 1;
        public const int WFS_CMD_CDM_DISPENSE = CDM_SERVICE_OFFSET + 2;
        public const int WFS_CMD_CDM_PRESENT = CDM_SERVICE_OFFSET + 3;
        public const int WFS_CMD_CDM_REJECT = CDM_SERVICE_OFFSET + 4;
        public const int WFS_CMD_CDM_RETRACT = CDM_SERVICE_OFFSET + 5;
        public const int WFS_CMD_CDM_OPEN_SHUTTER = CDM_SERVICE_OFFSET + 7;
        public const int WFS_CMD_CDM_CLOSE_SHUTTER = CDM_SERVICE_OFFSET + 8;
        public const int WFS_CMD_CDM_SET_TELLER_INFO = CDM_SERVICE_OFFSET + 9;
        public const int WFS_CMD_CDM_SET_CASH_UNIT_INFO = CDM_SERVICE_OFFSET + 10;
        public const int WFS_CMD_CDM_START_EXCHANGE = CDM_SERVICE_OFFSET + 11;
        public const int WFS_CMD_CDM_END_EXCHANGE = CDM_SERVICE_OFFSET + 12;
        public const int WFS_CMD_CDM_OPEN_SAFE_DOOR = CDM_SERVICE_OFFSET + 13;
        public const int WFS_CMD_CDM_CALIBRATE_CASH_UNIT = CDM_SERVICE_OFFSET + 15;
        public const int WFS_CMD_CDM_SET_MIX_TABLE = CDM_SERVICE_OFFSET + 20;
        public const int WFS_CMD_CDM_RESET = CDM_SERVICE_OFFSET + 21;
        public const int WFS_CMD_CDM_TEST_CASH_UNITS = CDM_SERVICE_OFFSET + 22;
        public const int WFS_CMD_CDM_COUNT = CDM_SERVICE_OFFSET + 23;
        public const int WFS_CMD_CDM_SET_GUIDANCE_LIGHT = CDM_SERVICE_OFFSET + 24;
        public const int WFS_CMD_CDM_POWER_SAVE_CONTROL = CDM_SERVICE_OFFSET + 25;
        public const int WFS_CMD_CDM_PREPARE_DISPENSE = CDM_SERVICE_OFFSET + 26;
        #endregion
        #region CDM Messages
        public const int WFS_SRVE_CDM_SAFEDOOROPEN = CDM_SERVICE_OFFSET + 1;
        public const int WFS_SRVE_CDM_SAFEDOORCLOSED = CDM_SERVICE_OFFSET + 2;
        public const int WFS_USRE_CDM_CASHUNITTHRESHOLD = CDM_SERVICE_OFFSET + 3;
        public const int WFS_SRVE_CDM_CASHUNITINFOCHANGED = CDM_SERVICE_OFFSET + 4;
        public const int WFS_SRVE_CDM_TELLERINFOCHANGED = CDM_SERVICE_OFFSET + 5;
        public const int WFS_EXEE_CDM_DELAYEDDISPENSE = CDM_SERVICE_OFFSET + 6;
        public const int WFS_EXEE_CDM_STARTDISPENSE = CDM_SERVICE_OFFSET + 7;
        public const int WFS_EXEE_CDM_CASHUNITERROR = CDM_SERVICE_OFFSET + 8;
        public const int WFS_SRVE_CDM_ITEMSTAKEN = CDM_SERVICE_OFFSET + 9;
        public const int WFS_EXEE_CDM_PARTIALDISPENSE = CDM_SERVICE_OFFSET + 10;
        public const int WFS_EXEE_CDM_SUBDISPENSEOK = CDM_SERVICE_OFFSET + 11;
        public const int WFS_SRVE_CDM_ITEMSPRESENTED = CDM_SERVICE_OFFSET + 13;
        public const int WFS_SRVE_CDM_COUNTS_CHANGED = CDM_SERVICE_OFFSET + 14;
        public const int WFS_EXEE_CDM_INCOMPLETEDISPENSE = CDM_SERVICE_OFFSET + 15;
        public const int WFS_EXEE_CDM_NOTEERROR = CDM_SERVICE_OFFSET + 16;
        public const int WFS_SRVE_CDM_MEDIADETECTED = CDM_SERVICE_OFFSET + 17;
        public const int WFS_EXEE_CDM_INPUT_P6 = CDM_SERVICE_OFFSET + 18;
        public const int WFS_SRVE_CDM_DEVICEPOSITION = CDM_SERVICE_OFFSET + 19;
        public const int WFS_SRVE_CDM_POWER_SAVE_CHANGE = CDM_SERVICE_OFFSET + 20;
        #endregion
        public const int WFS_CDM_INDIVIDUAL = 0;
        public const int WFS_CDM_MIX_MINIMUM_NUMBER_OF_BILLS = 1;
        public const int WFS_CDM_MIX_EQUAL_EMPTYING_OF_CASH_UNITS = 2;
        public const int WFS_CDM_MIX_MAXIMUM_NUMBER_OF_CASH_UNITS = 3;

    }
    [Flags]
    public enum OutputPosition:ushort
    {
        WFS_CDM_POSNULL = 0x0000,
        WFS_CDM_POSLEFT = 0x0001,
        WFS_CDM_POSRIGHT = 0x0002,
        WFS_CDM_POSCENTER = 0x0004,
        WFS_CDM_POSTOP = 0x0040,
        WFS_CDM_POSBOTTOM = 0x0080,
        WFS_CDM_POSFRONT = 0x0800,
        WFS_CDM_POSREAR = 0x1000
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSCDMDENOMINATION
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] cCurrencyID;
        public int ulAmount;
        public ushort usCount;
        public IntPtr lpulValues;
        public int ulCashBox;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSCDMDISPENSE
    {
        public ushort usTellerID;
        public ushort usMixNumber;
        public OutputPosition fwPosition;
        public bool bPresent;
        public IntPtr lpDenomination;
    }
}
