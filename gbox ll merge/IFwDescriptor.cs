namespace gbox_ll_merge
{
    interface IFwDescriptor
    {
        int GetBootloaderMaxSize();
        int GetFirmwareFileMaxSize();
        int GetOutputFileMaxSize();
        string GetMcuName();
    }
}
