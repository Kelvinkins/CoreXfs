using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreXfs;
using System.Runtime.InteropServices;

namespace CoreXfs
{
    public unsafe class IDC : DeviceBase
    {
        public event Action<int> ReadRawDataError;
        public event Action<IDCCardData[]> ReadRawDataComplete;
        public event Action EjectComplete;
        public event Action<int> EjectError;
        public event Action MediaInserted;
        public event Action MediareMoved;
        protected override void OnExecuteComplete(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {
                case IDCDefinition.WFS_CMD_IDC_READ_RAW_DATA:
                    if (result.hResult == Definition.WFS_SUCCESS)
                    {
                        WFSIDCCardData[] data = Util.XFSPtrToArray<WFSIDCCardData>(result.lpBuffer);
                        IDCCardData[] outerData = new IDCCardData[data.Length];
                        for (int i = 0; i < data.Length; ++i)
                        {
                            outerData[i] = new IDCCardData();
                            outerData[i].DataSource = data[i].wDataSource;
                            outerData[i].WriteMethod = data[i].fwWriteMethod;
                            outerData[i].Status = data[i].wStatus;
                            if (data[i].ulDataLength > 0)
                            {
                                outerData[i].Data = new byte[data[i].ulDataLength];
                                for (int j = 0; j < data[i].ulDataLength; ++j)
                                    outerData[i].Data[j] = Marshal.ReadByte(data[i].lpbData, j);
                            }
                        }
                        OnReadRawDataComplete(outerData);
                    }
                    else
                    {
                        OnReadRawDataError(result.hResult);
                    }
                    break;
                case IDCDefinition.WFS_CMD_IDC_EJECT_CARD:
                    if (result.hResult == Definition.WFS_SUCCESS)
                    {
                        OnEjectComplete();
                    }
                    else
                    {
                        OnEjectError(result.hResult);
                    }
                    break;
            }
        }
        protected override void OnExecuteEvent(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {
                case IDCDefinition.WFS_EXEE_IDC_MEDIAINSERTED:
                    OnMediaInserted();
                    break;
            }
        }
        protected override void OnServiceEvent(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {
                case IDCDefinition.WFS_SRVE_IDC_MEDIAREMOVED:
                    OnMediareMoved();
                    break;
            }
        }

        /// <summary>
        /// Reads the raw data from the inserted card
        /// </summary>
        /// <param name="sources">The card source</param>
        public void ReadRawData(IDCDataSource sources)
        {
            int hResult = Api.WFSAsyncExecute(hService, IDCDefinition.WFS_CMD_IDC_READ_RAW_DATA, new IntPtr(&sources), 0,
                Handle, ref requestID);
            if (hResult != Definition.WFS_SUCCESS)
                OnReadRawDataError(hResult);
        }

        /// <summary>
        /// Ejects the Atm Card
        /// </summary>
        public void EjectCard()
        {
            int hResult = Api.WFSAsyncExecute(hService, IDCDefinition.WFS_CMD_IDC_EJECT_CARD, IntPtr.Zero, 0, Handle, ref requestID);
            if (hResult != Definition.WFS_SUCCESS)
            {
                OnEjectError(hResult);
            }
        }

        #region Event handler
        protected virtual void OnReadRawDataError(int code)
        {
            if (ReadRawDataError != null)
                ReadRawDataError(code);
        }

        protected virtual void OnReadRawDataComplete(IDCCardData[] data)
        {
            if (ReadRawDataComplete != null)
                ReadRawDataComplete(data);
        }


        protected virtual void OnEjectError(int code)
        {
            if (EjectError != null)
            {
                EjectError(code);
            }
        }


        protected virtual void OnEjectComplete()
        {
            if (EjectComplete != null)
                EjectComplete();
        }


        protected virtual void OnMediaInserted()
        {
            if (MediaInserted != null)
                MediaInserted();
        }
        protected virtual void OnMediareMoved()
        {
            if (MediareMoved != null)
                MediareMoved();
        }
        #endregion
    }
}
