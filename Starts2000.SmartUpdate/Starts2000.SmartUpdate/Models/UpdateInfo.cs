using System;

namespace Starts2000.SmartUpdate.Models
{
    [Serializable]
    public class UpdateInfo
    {
        public int Id { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Version { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string DowloadUrl { get; set; }
        public int ClientType { get; set; }
        public bool HasNewVersion { get; set; }
    }
}
