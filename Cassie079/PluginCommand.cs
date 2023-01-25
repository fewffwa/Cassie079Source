
namespace Cassie079
{
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
    using CommandSystem;
    using System;
    using PlayerRoles;
    using PlayerStatsSystem;
    using PlayerRoles.PlayableScps.Scp079;
    using UnityEngine;


    [CommandHandler(typeof(ClientCommandHandler))]
    public class PluginCommand : ICommand
    {

        public string Command { get; } = "CassieComputer";

        public string[] Aliases { get; } = new string[] { "CC", "Cassputer" };

        public string Description { get; } = "Test command.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var ply = Player.Get(sender);
            if (ply.ReferenceHub.roleManager.CurrentRole is Scp079Role scp079Role)
            {
                scp079Role.SubroutineModule.TryGetSubroutine<Scp079AuxManager>(out Scp079AuxManager Scp079AuxManager);
                scp079Role.SubroutineModule.TryGetSubroutine<Scp079TierManager>(out Scp079TierManager Scp079TierManager);
                var lvl = Scp079TierManager.AccessTierLevel;
                var power = Scp079AuxManager.CurrentAux;
                if (lvl >= Plugin.Singleton.Config.RequiredTier)
                {
                    if (power >= Plugin.Singleton.Config.RequiredPower)
                    {
                        string cassieText = "";

                        foreach (string args in arguments)
                        {
                            cassieText += " " + args;
                        }
                        Cassie.Message(cassieText, false, true, false);

                        Scp079AuxManager.CurrentAux = Scp079AuxManager.CurrentAux - Plugin.Singleton.Config.RequiredPower;
                        response = $"Success! Told CASSIE to say {cassieText}";
                        return true;
                    }
                    response = $"You do not have the required power of {Plugin.Singleton.Config.RequiredPower}";
                    return true;
                }
                response = $"You are not the required Tier of {Plugin.Singleton.Config.RequiredTier}";
                return true;
            }
            response = "Failure! You are not 079!";
            return true;
        }
    }
}

