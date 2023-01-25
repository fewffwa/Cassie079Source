using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using PlayerRoles;
using UnityEngine;

namespace Cassie079
{
    class Plugin

    {
        public static Plugin Singleton { get; private set; }

        [PluginConfig] public Config Config;

        public const string Version = "1.0.0";

        [PluginPriority(LoadPriority.Highest)]
        [PluginEntryPoint("Cassie079", Version,
            "Allow SCP-079 to use the CASSIE announcement system", "Fewffwa")]
        void LoadPlugin()
        {
            Singleton = this;
            PluginAPI.Events.EventManager.RegisterEvents(this);
        }
    }

}

