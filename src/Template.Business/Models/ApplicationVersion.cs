﻿namespace Template.Business.Models
{
    public class ApplicationVersion
    {
        public string AssemblyName { get; set; }

        public string AssemblyVersion { get; set; }

        public string Environment { get; set; }

        public string DeployedAt { get; set; }

        public string StartedAt { get; set; }
    }
}
