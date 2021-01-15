using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CoreXfs.Xfs
{
    class XfsConnection
    {
        private string logicalName = "";
        XfsConnection(string logicalName)
        {
            this.logicalName = logicalName;
        }

        //public void Connect(string logicalName, Device device)
        //{
        //    switch(device)
        //    {
        //        case Device.CAM:
        //            break;
        //        case Device.CDM:
        //            CDM cdm = new CDM();
        //            cdm.Open(logicalName);
        //            break;
        //        case Device.IDC:
        //            IDC idc = new IDC();
        //            idc.Open(logicalName);
        //            break;
        //        case Device.PIN:
        //            break;
        //        case Device.PTR:
        //            break;
        //        case Device.SIU:
        //            break;
             
        //    }
        //}

    }
}
