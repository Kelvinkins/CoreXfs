using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using CoreXfs;

namespace CoreXfs.PIN
{
    public unsafe class PIN : DeviceBase
    {
        public event Action<int> GetDataError;
        public event Action<string> PINKey;
        public void GetData(ushort maxLen, bool autoEnd, XFSPINKey activeKeys, XFSPINKey terminateKeys, XFSPINKey activeFDKs = XFSPINKey.WFS_PIN_FK_UNUSED,
            XFSPINKey terminateFDKs = XFSPINKey.WFS_PIN_FK_UNUSED)
        {
            WFSPINGETDATA inputData = new WFSPINGETDATA();
            inputData.usMaxLen = maxLen;
            inputData.bAutoEnd = autoEnd;
            inputData.ulActiveFDKs = activeFDKs;
            inputData.ulActiveKeys = activeKeys;
            inputData.ulTerminateFDKs = terminateFDKs;
            inputData.ulTerminateKeys = terminateKeys;
            int len = Marshal.SizeOf(typeof(WFSPINGETDATA));
            IntPtr ptr = Marshal.AllocHGlobal(len);
            Marshal.StructureToPtr(inputData, ptr, false);
            int hResult = Api.WFSAsyncExecute(hService, PINDefinition.WFS_CMD_PIN_GET_DATA, ptr, 0, Handle, ref requestID);
            Marshal.FreeHGlobal(ptr);
            if (hResult != Definition.WFS_SUCCESS)
                OnGetDataError(hResult);
        }
        protected override void OnExecuteComplete(ref WFSRESULT result)
        {
            switch(result.dwCommandCodeOrEventID)
            {
                case PINDefinition.WFS_CMD_PIN_GET_DATA:
                    if (result.hResult != Definition.WFS_SUCCESS)
                        OnGetDataError(result.hResult);
                    break;
            }
        }
        protected override void OnExecuteEvent(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {
                case PINDefinition.WFS_EXEE_PIN_KEY:
                    WFSPINKEY key = new CoreXfs.PIN.WFSPINKEY();
                    Util.PtrToStructure(result.lpBuffer, ref key);
                    OnPINKey(ref key);
                    break;
            }
        }
        protected virtual void OnGetDataError(int code)
        {
            if (GetDataError != null)
                GetDataError(code);
        }
        protected virtual void OnPINKey(ref WFSPINKEY key)
        {
            if (PINKey != null)
                PINKey(key.ulDigit.ToString().Substring(11));
        }
    }
}
