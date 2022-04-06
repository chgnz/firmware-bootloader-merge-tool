using System;
using System.Collections.Generic;
using System.Text;

namespace gbox_ll_merge
{
    class LPC1768_Descriptor : IFwDescriptor
    {
        public int GetBootloaderMaxSize()
        {
            return 64 * 1024; // 64 kB
        }

        public int GetOutputFileMaxSize()
        {
            return 512 * 1024; // 64 kB
        }
        public int GetFirmwareFileMaxSize()
        {
            return (this.GetOutputFileMaxSize() - this.GetBootloaderMaxSize());
        }

        public string GetMcuName()
        {
            return "LPC1768";
        }
    }
}
