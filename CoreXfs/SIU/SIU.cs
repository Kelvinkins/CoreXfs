using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CoreXfs.SIU
{
    public class SIU : DeviceBase
    {
        public void SetGuidLight(GuidLights pos, LightControl con)
        {
            SetGuidLight((int)pos, con);
        }
        public void SetGuidLight(int pos, LightControl con)
        {
            WFSSIUSETGUIDLIGHT guidLight = new WFSSIUSETGUIDLIGHT();
            guidLight.fwCommand = con;
            guidLight.wGuidLight = (ushort)pos;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WFSSIUSETGUIDLIGHT)));
            Marshal.StructureToPtr(guidLight, ptr, false);
            int hResult = Api.WFSAsyncExecute(hService, SIUDefinition.WFS_CMD_SIU_SET_GUIDLIGHT, ptr, 0, Handle, ref requestID);
        }
        protected override int GetEventClass()
        {
            return base.GetEventClass() & (~Definition.USER_EVENTS);
        }
    }
}
