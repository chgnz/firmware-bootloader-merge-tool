using System;
using System.Collections.Generic;
using System.Text;

namespace gbox_ll_merge
{
    class STM32H7_Descriptor : IFwDescriptor
    {
        public int GetBootloaderMaxSize()
        {
            return 128 * 1024; // 128 kB
        }

        public int GetOutputFileMaxSize()
        {
            return 1024 * 1024; // 1024 kB (1MB)
        }
        public int GetFirmwareFileMaxSize()
        {
            return (this.GetOutputFileMaxSize() - this.GetBootloaderMaxSize());
        }

        public string GetMcuName()
        {
            return "STM32 H7xxx";
        }

    }
}
