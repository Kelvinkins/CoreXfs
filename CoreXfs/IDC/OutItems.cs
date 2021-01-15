using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreXfs
{
    public class IDCCardData
    {
        public IDCDataSource DataSource { get; set; }
        public IDCSourceStatus Status { get; set; }
        public IDCWriteMethods WriteMethod { get; set; }
        public byte[] Data { get; set; }
        public string Value
        {
            get
            {
                if (Data != null && Data.Length > 0)
                    return Encoding.Default.GetString(Data);
                return string.Empty;
            }
        }
    }
}
