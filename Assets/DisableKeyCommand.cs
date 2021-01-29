using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Console
{
    public class DisableKeyCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }
        public override int ArgLength { get; protected set; }
        public PlayerMovement playerMovement;

        public DisableKeyCommand()
        {
            Name = "Disable";
            Command = "disable";
            Description = "Disables the Robot's key movement";
            Help = "Usage: disable true/false";
            ArgLength = 1;
            playerMovement = DeveloperConsole.Instance.player.GetComponent<PlayerMovement>();
            AddCommandToConsole();
        }

        public override int RunCommand(string[] input)
        {
            var enable = (string)input[1];
            if(enable.ToLower() == "true")
            {
                playerMovement.keys_disabled = true;
                DeveloperConsole.AddStaticMessageToConsole("[USER] Disabling Robot controls....");
            }
            else if (enable.ToLower() == "false")
            {
                playerMovement.keys_disabled = false;
                DeveloperConsole.AddStaticMessageToConsole("[USER] Enabling Robot controls....");
            }
            else {
                return 1;
            }
            
            return -1;
        }
    }
}
