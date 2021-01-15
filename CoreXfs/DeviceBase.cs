using CoreXfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoreXfs
{
    public class DeviceBase : UserControl
    {
        #region Events
        public event Action OpenComplete;
        public event Action<int> OpenError;
        public event Action CloseComplete;
        public event Action RegisterComplete;
        public event Action<int> RegisterError;
        protected ushort hService;
        protected bool autoRegister = false;
        protected int requestID = 0;
        protected bool isStartup = false;
        public int TimeOut { get; set; }
        /// <summary>
        /// dulication of handle for crossing thread
        /// </summary>
        protected IntPtr MessageHandle;
        #endregion
        public DeviceBase()
        {
            this.Width = this.Height = 0;
            this.Visible = false;
            MessageHandle = Handle;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg >= Definition.WFS_OPEN_COMPLETE &&
                m.Msg <= Definition.WFS_TIMER_EVENT)
            {
                WFSRESULT result = new WFSRESULT();
                if (m.LParam != IntPtr.Zero)
                    Util.PtrToStructure(m.LParam, ref result);
                switch (m.Msg)
                {
                    case Definition.WFS_OPEN_COMPLETE:
                        OnOpenComplete();
                        break;
                    case Definition.WFS_CLOSE_COMPLETE:
                        OnCloseComplete();
                        break;
                    case Definition.WFS_REGISTER_COMPLETE:
                        OnRegisterComplete();
                        break;
                    case Definition.WFS_EXECUTE_COMPLETE:
                        OnExecuteComplete(ref result);
                        break;
                    case Definition.WFS_EXECUTE_EVENT:
                        OnExecuteEvent(ref result);
                        break;
                    case Definition.WFS_SERVICE_EVENT:
                        OnServiceEvent(ref result);
                        break;
                    case Definition.WFS_USER_EVENT:
                        OnUserEvent(ref result);
                        break;
                    case Definition.WFS_SYSTEM_EVENT:
                        OnSystemEvent(ref result);
                        break;
                }
                Api.WFSFreeResult(ref result);
            }
            else
                base.WndProc(ref m);
        }

        protected virtual void OnOpenComplete()
        {
            if (OpenComplete != null)
                OpenComplete();
            if (autoRegister)
            {
                InnerRegister(GetEventClass());
            }
        }
        protected virtual int InnerGetInfo<T>(int category, T inParam)
        {
            
            //Api.WFSGetInfo(hService, category,)
            return 0;
        }
        protected virtual int InnerGetInfo<T>(int category)
        {
            IntPtr pOutParam = IntPtr.Zero;
            //Api.WFSGetInfo(hService, category, IntPtr.Zero, TimeOut, ref pOutParam);
            return 0;
        }
        protected void InnerRegister(int eventClasses)
        {
            int hResult = Api.WFSAsyncRegister(hService, eventClasses, MessageHandle
                , MessageHandle, ref requestID);
            if (hResult != Definition.WFS_SUCCESS)
            {
                OnRegisterError(hResult);
            }
        }
        protected virtual int GetEventClass()
        {
            return Definition.EXECUTE_EVENTS | Definition.SERVICE_EVENTS
                | Definition.SYSTEM_EVENTS | Definition.USER_EVENTS;
        }
        protected virtual void OnOpenError(int code)
        {
            if (OpenError != null)
                OpenError(code);
        }
        protected virtual void OnCloseComplete()
        {
            if (CloseComplete != null)
                CloseComplete();
        }
        protected virtual void OnRegisterComplete()
        {
            if (RegisterComplete != null)
                RegisterComplete();
        }
        protected virtual void OnRegisterError(int code)
        {
            if (RegisterError != null)
                RegisterError(code);
        }
        protected virtual void OnExecuteComplete(ref WFSRESULT result)
        { }
        protected virtual void OnExecuteEvent(ref WFSRESULT result)
        { }
        protected virtual void OnServiceEvent(ref WFSRESULT result)
        { }
        protected virtual void OnUserEvent(ref WFSRESULT result)
        { }
        protected virtual void OnSystemEvent(ref WFSRESULT result)
        { }
        public void Open(string logicName, bool paramAutoRegister = true,
            string appID = "CoreXfs", string lowVersion = "3.0",
            string highVersion = "3.0")
        {
            autoRegister = paramAutoRegister;
            int requestVersion = Util.ParseVersionString(lowVersion,
                highVersion);
            WFSVERSION srvcVersion = new WFSVERSION();
            WFSVERSION spVersion = new WFSVERSION();
            int hResult = 0;
            if (!isStartup)
            {
                hResult = Api.WFSStartUp(requestVersion, ref spVersion);
                if (hResult != Definition.WFS_SUCCESS &&
                    hResult != Definition.WFS_ERR_ALREADY_STARTED)
                {
                    OnOpenError(hResult);
                    return;
                }
            }
            hResult = Api.WFSAsyncOpen(logicName, IntPtr.Zero, appID, 0,
                Constants.WFS_INDEFINITE_WAIT, ref hService,
            MessageHandle, requestVersion, ref srvcVersion, ref spVersion,
            ref requestID);
            if (hResult != Definition.WFS_SUCCESS)
            {
                OnOpenError(hResult);
            }
        }


        public void Register(int eventClasses = Definition.EXECUTE_EVENTS |
            Definition.SERVICE_EVENTS | Definition.SYSTEM_EVENTS |
            Definition.USER_EVENTS)
        {
            InnerRegister(eventClasses);
        }

        public void Close()
        {
            //
        }

        public void Reset()
        {
            //
        }
        public void Cancel()
        {
            Api.WFSCancelAsyncRequest(hService, requestID);
        }
    }
}
