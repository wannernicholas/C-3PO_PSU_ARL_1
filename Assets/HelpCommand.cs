using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Console
{
    public class HelpCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }
        public override int ArgLength { get; protected set; }
        public PlayerMovement playerMovement;
        private Dictionary<string, ConsoleCommand> Commands;

        public HelpCommand(Dictionary<string, ConsoleCommand> Commands)
        {
            Name = "Help";
            Command = "help";
            Description = "Shows how to use the command specified after help";
            Help = "Usage: help {any command}";
            ArgLength = 1;
            playerMovement = DeveloperConsole.Instance.player.GetComponent<PlayerMovement>();
            this.Commands = Commands;
            AddCommandToConsole();
        }

        public override int RunCommand(string[] input)
        {

            string command = input[1];

            if (Commands.ContainsKey(command))
            {
                Commands[command].DisplayCommand();
                return -1;
            }

            return 1;

        }
    }
}