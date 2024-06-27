using System;

namespace TPExt.Host.Model
{
    public class EnvironmentInfo
    {
        public string Username { get; set; }
        public string Hostname { get; set; }
        public string UserDomainName { get; set; }

        public EnvironmentInfo()
        {
            this.Username = Environment.UserName;
            this.Hostname = Environment.MachineName;
            this.UserDomainName = Environment.UserDomainName;
        }
    }
}
