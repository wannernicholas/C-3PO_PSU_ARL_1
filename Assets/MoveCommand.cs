using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Console
{
    public class MoveCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }
        public override int ArgLength { get; protected set; }
        public PlayerMovement playerMovement;

        public MoveCommand()
        {
            Name = "Move";
            Command = "move";
            Description = "Move the Robot in specified Direction";
            Help = "Usage: move {up,down,left.right}";
            ArgLength = 1;
            playerMovement = DeveloperConsole.Instance.player.GetComponent<PlayerMovement>();
            AddCommandToConsole();
        }

        public override int RunCommand(string[] input)
        {

            string direction = input[1];

            if (direction == "left")
            {
                playerMovement.command_running = true;
                playerMovement.dX = -playerMovement.speed;
                DeveloperConsole.AddStaticMessageToConsole("[USER] Moving the robot left....");
            }
            else if (direction == "right")
            {
                playerMovement.command_running = true;
                playerMovement.dX = playerMovement.speed;
                DeveloperConsole.AddStaticMessageToConsole("[USER] Moving the robot right....");
            }
            else if (direction == "up")
            {
                playerMovement.command_running = true;
                playerMovement.dZ = playerMovement.speed;
                DeveloperConsole.AddStaticMessageToConsole("[USER] Moving the robot up....");
            }
            else if (direction == "down")
            {
                playerMovement.command_running = true;
                playerMovement.dZ = -playerMovement.speed;
                DeveloperConsole.AddStaticMessageToConsole("[USER] Moving the robot down....");
            }
            else
                return 1;

            return -1;

        }
    }

}
