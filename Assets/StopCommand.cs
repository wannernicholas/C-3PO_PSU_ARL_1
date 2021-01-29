using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Console
{
    public class StopCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }
        public override int ArgLength { get; protected set; }
        public PlayerMovement playerMovement;

        public StopCommand()
        {
            Name = "Stop";
            Command = "stop";
            Description = "Stops the Robot";
            Help = "Usage: stop";
            ArgLength = 0;
            playerMovement = DeveloperConsole.Instance.player.GetComponent<PlayerMovement>();
            AddCommandToConsole();
        }

        public override int RunCommand(string[] input)
        {
            playerMovement.dX = 0;
            playerMovement.dY = 0;
            playerMovement.dZ = 0;
            DeveloperConsole.AddStaticMessageToConsole("[USER] Stopping Robot....");
            return -1;
        }
    }
}
