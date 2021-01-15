using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using CoreXfs;

namespace CoreXfs.PIN
{
    public static class PINDefinition
    {
        public const int WFS_SERVICE_CLASS_PIN = 4;
        public const int PIN_SERVICE_OFFSET = WFS_SERVICE_CLASS_PIN * 100;
        public const int WFS_SERVICE_CLASS_VERSION_PIN = 0x1403;
        public const string WFS_SERVICE_CLASS_NAME_PIN = "PIN";
        #region PIN Info Commands 
        public const int WFS_INF_PIN_STATUS = PIN_SERVICE_OFFSET + 1;
        public const int WFS_INF_PIN_CAPABILITIES = PIN_SERVICE_OFFSET + 2;
        public const int WFS_INF_PIN_KEY_DETAIL = PIN_SERVICE_OFFSET + 4;
        public const int WFS_INF_PIN_FUNCKEY_DETAIL = PIN_SERVICE_OFFSET + 5;
        public const int WFS_INF_PIN_HSM_TDATA = PIN_SERVICE_OFFSET + 6;
        public const int WFS_INF_PIN_KEY_DETAIL_EX = PIN_SERVICE_OFFSET + 7;
        public const int WFS_INF_PIN_SECUREKEY_DETAIL = PIN_SERVICE_OFFSET + 8;
        public const int WFS_INF_PIN_QUERY_LOGICAL_HSM_DETAIL = PIN_SERVICE_OFFSET + 9;
        public const int WFS_INF_PIN_QUERY_PCIPTS_DEVICE_ID = PIN_SERVICE_OFFSET + 10;
        #endregion
        #region  PIN Command Verbs
        public const int WFS_CMD_PIN_CRYPT = PIN_SERVICE_OFFSET + 1;
        public const int WFS_CMD_PIN_IMPORT_KEY = PIN_SERVICE_OFFSET + 3;
        public const int WFS_CMD_PIN_GET_PIN = PIN_SERVICE_OFFSET + 5;
        public const int WFS_CMD_PIN_GET_PINBLOCK = PIN_SERVICE_OFFSET + 7;
        public const int WFS_CMD_PIN_GET_DATA = PIN_SERVICE_OFFSET + 8;
        public const int WFS_CMD_PIN_INITIALIZATION = PIN_SERVICE_OFFSET + 9;
        public const int WFS_CMD_PIN_LOCAL_DES = PIN_SERVICE_OFFSET + 10;
        public const int WFS_CMD_PIN_LOCAL_EUROCHEQUE = PIN_SERVICE_OFFSET + 11;
        public const int WFS_CMD_PIN_LOCAL_VISA = PIN_SERVICE_OFFSET + 12;
        public const int WFS_CMD_PIN_CREATE_OFFSET = PIN_SERVICE_OFFSET + 13;
        public const int WFS_CMD_PIN_DERIVE_KEY = PIN_SERVICE_OFFSET + 14;
        public const int WFS_CMD_PIN_PRESENT_IDC = PIN_SERVICE_OFFSET + 15;
        public const int WFS_CMD_PIN_LOCAL_BANKSYS = PIN_SERVICE_OFFSET + 16;
        public const int WFS_CMD_PIN_BANKSYS_IO = PIN_SERVICE_OFFSET + 17;
        public const int WFS_CMD_PIN_RESET = PIN_SERVICE_OFFSET + 18;
        public const int WFS_CMD_PIN_HSM_SET_TDATA = PIN_SERVICE_OFFSET + 19;
        public const int WFS_CMD_PIN_SECURE_MSG_SEND = PIN_SERVICE_OFFSET + 20;
        public const int WFS_CMD_PIN_SECURE_MSG_RECEIVE = PIN_SERVICE_OFFSET + 21;
        public const int WFS_CMD_PIN_GET_JOURNAL = PIN_SERVICE_OFFSET + 22;
        public const int WFS_CMD_PIN_IMPORT_KEY_EX = PIN_SERVICE_OFFSET + 23;
        public const int WFS_CMD_PIN_ENC_IO = PIN_SERVICE_OFFSET + 24;
        public const int WFS_CMD_PIN_HSM_INIT = PIN_SERVICE_OFFSET + 25;
        public const int WFS_CMD_PIN_IMPORT_RSA_PUBLIC_KEY = PIN_SERVICE_OFFSET + 26;
        public const int WFS_CMD_PIN_EXPORT_RSA_ISSUER_SIGNED_ITEM = PIN_SERVICE_OFFSET + 27;
        public const int WFS_CMD_PIN_IMPORT_RSA_SIGNED_DES_KEY = PIN_SERVICE_OFFSET + 28;
        public const int WFS_CMD_PIN_GENERATE_RSA_KEY_PAIR = PIN_SERVICE_OFFSET + 29;
        public const int WFS_CMD_PIN_EXPORT_RSA_EPP_SIGNED_ITEM = PIN_SERVICE_OFFSET + 30;
        public const int WFS_CMD_PIN_LOAD_CERTIFICATE = PIN_SERVICE_OFFSET + 31;
        public const int WFS_CMD_PIN_GET_CERTIFICATE = PIN_SERVICE_OFFSET + 32;
        public const int WFS_CMD_PIN_REPLACE_CERTIFICATE = PIN_SERVICE_OFFSET + 33;
        public const int WFS_CMD_PIN_START_KEY_EXCHANGE = PIN_SERVICE_OFFSET + 34;
        public const int WFS_CMD_PIN_IMPORT_RSA_ENCIPHERED_PKCS7_KEY = PIN_SERVICE_OFFSET + 35;
        public const int WFS_CMD_PIN_EMV_IMPORT_PUBLIC_KEY = PIN_SERVICE_OFFSET + 36;
        public const int WFS_CMD_PIN_DIGEST = PIN_SERVICE_OFFSET + 37;
        public const int WFS_CMD_PIN_SECUREKEY_ENTRY = PIN_SERVICE_OFFSET + 38;
        public const int WFS_CMD_PIN_GENERATE_KCV = PIN_SERVICE_OFFSET + 39;
        public const int WFS_CMD_PIN_SET_GUIDANCE_LIGHT = PIN_SERVICE_OFFSET + 41;
        public const int WFS_CMD_PIN_MAINTAIN_PIN = PIN_SERVICE_OFFSET + 42;
        public const int WFS_CMD_PIN_KEYPRESS_BEEP = PIN_SERVICE_OFFSET + 43;
        public const int WFS_CMD_PIN_SET_PINBLOCK_DATA = PIN_SERVICE_OFFSET + 44;
        public const int WFS_CMD_PIN_SET_LOGICAL_HSM = PIN_SERVICE_OFFSET + 45;
        public const int WFS_CMD_PIN_IMPORT_KEYBLOCK = PIN_SERVICE_OFFSET + 46;
        public const int WFS_CMD_PIN_POWER_SAVE_CONTROL = PIN_SERVICE_OFFSET + 47;
        #endregion
        #region PIN Messages
        public const int WFS_EXEE_PIN_KEY = PIN_SERVICE_OFFSET + 1;
        public const int WFS_SRVE_PIN_INITIALIZED = PIN_SERVICE_OFFSET + 2;
        public const int WFS_SRVE_PIN_ILLEGAL_KEY_ACCESS = PIN_SERVICE_OFFSET + 3;
        public const int WFS_SRVE_PIN_OPT_REQUIRED = PIN_SERVICE_OFFSET + 4;
        public const int WFS_SRVE_PIN_HSM_TDATA_CHANGED = PIN_SERVICE_OFFSET + 5;
        public const int WFS_SRVE_PIN_CERTIFICATE_CHANGE = PIN_SERVICE_OFFSET + 6;
        public const int WFS_SRVE_PIN_HSM_CHANGED = PIN_SERVICE_OFFSET + 7;
        public const int WFS_EXEE_PIN_ENTERDATA = PIN_SERVICE_OFFSET + 8;
        public const int WFS_SRVE_PIN_DEVICEPOSITION = PIN_SERVICE_OFFSET + 9;
        public const int WFS_SRVE_PIN_POWER_SAVE_CHANGE = PIN_SERVICE_OFFSET + 10;
        #endregion
        public const XFSPINKey NumerKeys = XFSPINKey.WFS_PIN_FK_0 | XFSPINKey.WFS_PIN_FK_1 | XFSPINKey.WFS_PIN_FK_2 | XFSPINKey.WFS_PIN_FK_3 | XFSPINKey.WFS_PIN_FK_4 |
            XFSPINKey.WFS_PIN_FK_5 | XFSPINKey.WFS_PIN_FK_6 | XFSPINKey.WFS_PIN_FK_7 | XFSPINKey.WFS_PIN_FK_8 | XFSPINKey.WFS_PIN_FK_9;
    }
    [Flags]
    public enum XFSPINKey : uint
    {
        WFS_PIN_FK_UNUSED = 0,
        WFS_PIN_FK_0 = 0x00000001,
        WFS_PIN_FK_1 = 0x00000002,
        WFS_PIN_FK_2 = 0x00000004,
        WFS_PIN_FK_3 = 0x00000008,
        WFS_PIN_FK_4 = 0x00000010,
        WFS_PIN_FK_5 = 0x00000020,
        WFS_PIN_FK_6 = 0x00000040,
        WFS_PIN_FK_7 = 0x00000080,
        WFS_PIN_FK_8 = 0x00000100,
        WFS_PIN_FK_9 = 0x00000200,
        WFS_PIN_FK_ENTER = 0x00000400,
        WFS_PIN_FK_CANCEL = 0x00000800,
        WFS_PIN_FK_CLEAR = 0x00001000,
        WFS_PIN_FK_BACKSPACE = 0x00002000,
        WFS_PIN_FK_HELP = 0x00004000,
        WFS_PIN_FK_DECPOINT = 0x00008000,
        WFS_PIN_FK_00 = 0x00010000,
        WFS_PIN_FK_000 = 0x00020000,
        WFS_PIN_FK_RES1 = 0x00040000,
        WFS_PIN_FK_RES2 = 0x00080000,
        WFS_PIN_FK_RES3 = 0x00100000,
        WFS_PIN_FK_RES4 = 0x00200000,
        WFS_PIN_FK_RES5 = 0x00400000,
        WFS_PIN_FK_RES6 = 0x00800000,
        WFS_PIN_FK_RES7 = 0x01000000,
        WFS_PIN_FK_RES8 = 0x02000000,
        WFS_PIN_FK_OEM1 = 0x04000000,
        WFS_PIN_FK_OEM2 = 0x08000000,
        WFS_PIN_FK_OEM3 = 0x10000000,
        WFS_PIN_FK_OEM4 = 0x20000000,
        WFS_PIN_FK_OEM5 = 0x40000000,
        WFS_PIN_FK_OEM6 = 0x80000000
    }
    public enum PINCompletion : ushort
    {
        WFS_PIN_COMPAUTO = 0,
        WFS_PIN_COMPENTER = 1,
        WFS_PIN_COMPCANCEL = 2,
        WFS_PIN_COMPCONTINUE = 6,
        WFS_PIN_COMPCLEAR = 7,
        WFS_PIN_COMPBACKSPACE = 8,
        WFS_PIN_COMPFDK = 9,
        WFS_PIN_COMPHELP = 10,
        WFS_PIN_COMPFK = 11,
        WFS_PIN_COMPCONTFDK = 12
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSPINKEY
    {
        public PINCompletion wCompletion;
        public XFSPINKey ulDigit;
    }
    [StructLayout(LayoutKind.Sequential, Pack = Constants.STRUCTPACKSIZE, CharSet = Constants.CHARSET)]
    public struct WFSPINGETDATA
    {
        public ushort usMaxLen;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bAutoEnd;
        public XFSPINKey ulActiveFDKs;
        public XFSPINKey ulActiveKeys;
        public XFSPINKey ulTerminateFDKs;
        public XFSPINKey ulTerminateKeys;
    }
}
