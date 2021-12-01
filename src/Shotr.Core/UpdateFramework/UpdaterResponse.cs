namespace Shotr.Core.UpdateFramework
{
    public class UpdaterResponse
    {
        public UpdaterResponse()
        {
            // To disable nullable context warnings
            Version = string.Empty;
            Changes = string.Empty;
        }
        
        public string Version { get; set; }
        public string Changes { get; set; }
        public string ChannelType { get; set; }
        public int ChannelTypeId { get; set; }
        public string DownloadUrl { get; set; }
        public string InstallerUrl { get; set; }
    }
}
