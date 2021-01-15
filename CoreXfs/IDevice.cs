using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreXfs
{
    public interface IDevice
    {
        void Open(string logicName, bool paramAutoRegister = true, string appID = "CoreXfs", string lowVersion = "3.0", string highVersion = "3.0");
        void Close();
        void Reset();
        event Action OpenComplete;
        event Action RegisterComplete;
    }
}
