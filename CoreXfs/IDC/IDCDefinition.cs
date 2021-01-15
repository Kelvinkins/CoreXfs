using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CoreXfs
{
    public static class IDCDefinition
    {
        public const int WFS_SERVICE_CLASS_IDC = 2;
        public const int IDC_SERVICE_OFFSET = WFS_SERVICE_CLASS_IDC * 100;
        public const string WFS_SERVICE_CLASS_NAME_IDC = "IDC";
        public const int WFS_SERVICE_CLASS_VERSION_IDC = 0x1403;
        #region IDC Info Commands
        public const int WFS_INF_IDC_STATUS = IDC_SERVICE_OFFSET + 1;
        public const int WFS_INF_IDC_CAPABILITIES = IDC_SERVICE_OFFSET + 2;
        public const int WFS_INF_IDC_FORM_LIST = IDC_SERVICE_OFFSET + 3;
        public const int WFS_INF_IDC_QUERY_FORM = IDC_SERVICE_OFFSET + 4;
        public const int WFS_INF_IDC_QUERY_IFM_IDENTIFIER = IDC_SERVICE_OFFSET + 5;
        #endregion
        #region IDC Execute Commands 
        public const int WFS_CMD_IDC_READ_TRACK = IDC_SERVICE_OFFSET + 1;
        public const int WFS_CMD_IDC_WRITE_TRACK = IDC_SERVICE_OFFSET + 2;
        public const int WFS_CMD_IDC_EJECT_CARD = IDC_SERVICE_OFFSET + 3;
        public const int WFS_CMD_IDC_RETAIN_CARD = IDC_SERVICE_OFFSET + 4;
        public const int WFS_CMD_IDC_RESET_COUNT = IDC_SERVICE_OFFSET + 5;
        public const int WFS_CMD_IDC_SETKEY = IDC_SERVICE_OFFSET + 6;
        public const int WFS_CMD_IDC_READ_RAW_DATA = IDC_SERVICE_OFFSET + 7;
        public const int WFS_CMD_IDC_WRITE_RAW_DATA = IDC_SERVICE_OFFSET + 8;
        public const int WFS_CMD_IDC_CHIP_IO = IDC_SERVICE_OFFSET + 9;
        public const int WFS_CMD_IDC_RESET = IDC_SERVICE_OFFSET + 10;
        public const int WFS_CMD_IDC_CHIP_POWER = IDC_SERVICE_OFFSET + 11;
        public const int WFS_CMD_IDC_PARSE_DATA = IDC_SERVICE_OFFSET + 12;
        public const int WFS_CMD_IDC_SET_GUIDANCE_LIGHT = IDC_SERVICE_OFFSET + 13;
        public const int WFS_CMD_IDC_POWER_SAVE_CONTROL = IDC_SERVICE_OFFSET + 14;
        public const int WFS_CMD_IDC_PARK_CARD = IDC_SERVICE_OFFSET + 15;
        #endregion
        #region Message
        public const int WFS_EXEE_IDC_INVALIDTRACKDATA = IDC_SERVICE_OFFSET + 1;
        public const int WFS_EXEE_IDC_MEDIAINSERTED = IDC_SERVICE_OFFSET + 3;
        public const int WFS_SRVE_IDC_MEDIAREMOVED = IDC_SERVICE_OFFSET + 4;
        public const int WFS_SRVE_IDC_CARDACTION = IDC_SERVICE_OFFSET + 5;
        public const int WFS_USRE_IDC_RETAINBINTHRESHOLD = IDC_SERVICE_OFFSET + 6;
        public const int WFS_EXEE_IDC_INVALIDMEDIA = IDC_SERVICE_OFFSET + 7;
        public const int WFS_EXEE_IDC_MEDIARETAINED = IDC_SERVICE_OFFSET + 8;
        public const int WFS_SRVE_IDC_MEDIADETECTED = IDC_SERVICE_OFFSET + 9;
        public const int WFS_SRVE_IDC_RETAINBININSERTED = IDC_SERVICE_OFFSET + 10;
        public const int WFS_SRVE_IDC_RETAINBINREMOVED = IDC_SERVICE_OFFSET + 11;
        public const int WFS_EXEE_IDC_INSERTCARD = IDC_SERVICE_OFFSET + 12;
        public const int WFS_SRVE_IDC_DEVICEPOSITION = IDC_SERVICE_OFFSET + 13;
        public const int WFS_SRVE_IDC_POWER_SAVE_CHANGE = IDC_SERVICE_OFFSET + 14;
        public const int WFS_EXEE_IDC_TRACKDETECTED = IDC_SERVICE_OFFSET + 15;
        #endregion
        public const int WFS_IDC_GUIDLIGHTS_SIZE = 32;
        public const int WFS_IDC_GUIDLIGHTS_MAX = WFS_IDC_GUIDLIGHTS_SIZE - 1;
        public const int WFS_IDC_GUIDANCE_CARDUNIT = 0;
    }

    public enum IDCMediaStatus : ushort
    {
        WFS_IDC_MEDIAPRESENT = 1,
        WFS_IDC_MEDIANOTPRESENT = 2,
        WFS_IDC_MEDIAJAMMED = 3,
        WFS_IDC_MEDIANOTSUPP = 4,
        WFS_IDC_MEDIAUNKNOWN = 5,
        WFS_IDC_MEDIAENTERING = 6,
        WFS_IDC_MEDIALATCHED = 7
    }
    public enum IDCRetainBinStatus : ushort
    {
        WFS_IDC_RETAINBINOK = 1,
        WFS_IDC_RETAINNOTSUPP = 2,
        WFS_IDC_RETAINBINFULL = 3,
        WFS_IDC_RETAINBINHIGH = 4,
        WFS_IDC_RETAINBINMISSING = 5
    }
    public enum IDCSecurityStatus : ushort
    {
        WFS_IDC_SECNOTSUPP = 1,
        WFS_IDC_SECNOTREADY = 2,
        WFS_IDC_SECOPEN = 3
    }
    public enum IDCChipPowerStatus : ushort
    {
        WFS_IDC_CHIPONLINE = 0,
        WFS_IDC_CHIPPOWEREDOFF = 1,
        WFS_IDC_CHIPBUSY = 2,
        WFS_IDC_CHIPNODEVICE = 3,
        WFS_IDC_CHIPHWERROR = 4,
        WFS_IDC_CHIPNOCARD = 5,
        WFS_IDC_CHIPNOTSUPP = 6,
        WFS_IDC_CHIPUNKNOWN = 7
    }
    [Flags]
    public enum IDCGuidLightStatus
    {
        WFS_IDC_GUIDANCE_NOT_AVAILABLE = 0x00000000,
        WFS_IDC_GUIDANCE_OFF = 0x00000001,
        WFS_IDC_GUIDANCE_ON = 0x00000002,
        WFS_IDC_GUIDANCE_SLOW_FLASH = 0x00000004,
        WFS_IDC_GUIDANCE_MEDIUM_FLASH = 0x00000008,
        WFS_IDC_GUIDANCE_QUICK_FLASH = 0x00000010,
        WFS_IDC_GUIDANCE_CONTINUOUS = 0x00000080,
        WFS_IDC_GUIDANCE_RED = 0x00000100,
        WFS_IDC_GUIDANCE_GREEN = 0x00000200,
        WFS_IDC_GUIDANCE_YELLOW = 0x00000400,
        WFS_IDC_GUIDANCE_BLUE = 0x00000800,
        WFS_IDC_GUIDANCE_CYAN = 0x00001000,
        WFS_IDC_GUIDANCE_MAGENTA = 0x00002000,
        WFS_IDC_GUIDANCE_WHITE = 0x00004000
    }
    [Flags]
    public enum IDCDataSource : ushort
    {
        WFS_IDC_TRACK1 = 0x0001,
        WFS_IDC_TRACK2 = 0x0002,
        WFS_IDC_TRACK3 = 0x0004,
        WFS_IDC_FRONT_TRACK_1 = 0x0080,
        WFS_IDC_TRACK1_JIS1 = 0x0400,
        WFS_IDC_TRACK3_JIS1 = 0x0800,
        WFS_IDC_CHIP = 0x0008,
        WFS_IDC_SECURITY = 0x0010,
        WFS_IDC_FLUXINACTIVE = 0x0020,
        WFS_IDC_TRACK_WM = 0x8000,
        WFS_IDC_MEMORY_CHIP = 0x0040,
        WFS_IDC_FRONTIMAGE = 0x0100,
        WFS_IDC_BACKIMAGE = 0x0200,
        WFS_IDC_DDI = 0x4000
    }
    public enum IDCSourceStatus : ushort
    {
        WFS_IDC_DATAOK = 0,
        WFS_IDC_DATAMISSING = 1,
        WFS_IDC_DATAINVALID = 2,
        WFS_IDC_DATATOOLONG = 3,
        WFS_IDC_DATATOOSHORT = 4,
        WFS_IDC_DATASRCNOTSUPP = 5,
        WFS_IDC_DATASRCMISSING = 6
    }
    [Flags]
    public enum IDCWriteMethods : ushort
    {
        WFS_IDC_LOCO = 0x0002,
        WFS_IDC_HICO = 0x0004,
        WFS_IDC_AUTO = 0x0008
    }
    public enum IDCChipModule : ushort
    {
        WFS_IDC_CHIPMODOK = 1,
        WFS_IDC_CHIPMODINOP = 2,
        WFS_IDC_CHIPMODUNKNOWN = 3,
        WFS_IDC_CHIPMODNOTSUPP = 4
    }
    public enum IDCMagModule : ushort
    {
        WFS_IDC_MAGMODOK = 1,
        WFS_IDC_MAGMODINOP = 2,
        WFS_IDC_MAGMODUNKNOWN = 3,
        WFS_IDC_MAGMODNOTSUPP = 4
    }
    public enum IDCImageModule : ushort
    {
        WFS_IDC_IMGMODOK = 1,
        WFS_IDC_IMGMODINOP = 2,
        WFS_IDC_IMGMODUNKNOWN = 3,
        WFS_IDC_IMGMODNOTSUPP = 4
    }
    public enum IDCDevicePosition : ushort
    {
        WFS_IDC_DEVICEINPOSITION = 0,
        WFS_IDC_DEVICENOTINPOSITION = 1,
        WFS_IDC_DEVICEPOSUNKNOWN = 2,
        WFS_IDC_DEVICEPOSNOTSUPP = 3
    }
    public enum IDCAntiFraudModule : ushort
    {
        WFS_IDC_AFMNOTSUPP = 0,
        WFS_IDC_AFMOK = 1,
        WFS_IDC_AFMINOP = 2,
        WFS_IDC_AFMDEVICEDETECTED = 3,
        WFS_IDC_AFMUNKNOWN = 4
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public unsafe struct WFSIDCSTATUS
    {
        public DEVSTATUS fwDevice;
        public IDCMediaStatus fwMedia;
        public IDCRetainBinStatus fwRetainBin;
        public IDCSecurityStatus fwSecurity;
        public ushort usCards;
        public IDCChipPowerStatus fwChipPower;
        public IntPtr lpszExtra;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = IDCDefinition.WFS_IDC_GUIDLIGHTS_SIZE)]
        public IDCGuidLightStatus[] dwGuidLights;
        public IDCChipModule fwChipModule;
        public IDCMagModule fwMagReadModule;
        public IDCMagModule fwMagWriteModule;
        public IDCImageModule fwFrontImageModule;
        public IDCImageModule fwBackImageModule;
        public IDCDevicePosition wDevicePosition;
        public ushort usPowerSaveRecoveryTime;
        public ushort* lpwParkingStationMedia;
        public IDCAntiFraudModule wAntiFraudModule;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public unsafe struct WFSIDCCAPS
    {
        ushort wClass;
        ushort fwType;
        bool bCompound;
        ushort fwReadTracks;
        ushort fwWriteTracks;
        ushort fwChipProtocols;
        ushort usCards;
        ushort fwSecType;
        ushort fwPowerOnOption;
        ushort fwPowerOffOption;
        bool bFluxSensorProgrammable;
        bool bReadWriteAccessFollowingEject;
        ushort fwWriteMode;
        ushort fwChipPower;
        string lpszExtra;
        ushort fwDIPMode;
        ushort* lpwMemoryChipProtocols;
        ushort fwEjectPosition;
        bool bPowerSaveControl;
        ushort usParkingStations;
        bool bAntiFraudModule;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCFORM
    {
        string lpszFormName;
        char cFieldSeparatorTrack1;
        char cFieldSeparatorTrack2;
        char cFieldSeparatorTrack3;
        ushort fwAction;
        string lpszTracks;
        bool bSecure;
        string lpszTrack1Fields;
        string lpszTrack2Fields;
        string lpszTrack3Fields;
        string lpszFrontTrack1Fields;
        char cFieldSeparatorFrontTrack1;
        string lpszJIS1Track1Fields;
        string lpszJIS1Track3Fields;
        char cFieldSeparatorJIS1Track1;
        char cFieldSeparatorJIS1Track3;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCIFMIDENTIFIER
    {
        ushort wIFMAuthority;
        string lpszIFMIdentifier;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCWRITETRACK
    {
        string lpstrFormName;
        string lpstrTrackData;
        ushort fwWriteMethod;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCRETAINCARD
    {
        ushort usCount;
        ushort fwPosition;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCSETKEY
    {
        ushort usKeyLen;
        IntPtr lpbKeyValue;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    internal struct WFSIDCCardData
    {
        public IDCDataSource wDataSource;
        public IDCSourceStatus wStatus;
        public uint ulDataLength;
        public IntPtr lpbData;
        public IDCWriteMethods fwWriteMethod;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCCHIPIO
    {
        ushort wChipProtocol;
        ulong ulChipDataLength;
        IntPtr lpbChipData;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCCHIPPOWEROUT
    {
        ulong ulChipDataLength;
        IntPtr lpbChipData;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCPARSEDATA
    {
        string lpstrFormName;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCSETGUIDLIGHT
    {
        ushort wGuidLight;
        int dwCommand;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCEJECTCARD
    {
        ushort wEjectPosition;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCPOWERSAVECONTROL
    {
        ushort usMaxPowerSaveRecoveryTime;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCPARKCARD
    {
        ushort wDirection;
        ushort usParkingStation;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCTRACKEVENT
    {
        ushort fwStatus;
        string lpstrTrack;
        string lpstrData;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCCARDACT
    {
        ushort wAction;
        ushort wPosition;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCDEVICEPOSITION
    {
        ushort wPosition;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCPOWERSAVECHANGE
    {
        ushort usPowerSaveRecoveryTime;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSIDCTRACKDETECTED
    {
        ushort fwTracks;
    }
}
