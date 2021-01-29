using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Console
{
    public class ListCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }
        public override int ArgLength { get; protected set; }
        public PlayerMovement playerMovement;
        private Dictionary<string, ConsoleCommand> Commands;

        public ListCommand(Dictionary<string, ConsoleCommand> Commands)
        {
            Name = "List";
            Command = "commands";
            Description = "Lists all commands";
            Help = "Usage: commands";
            ArgLength = 0;
            playerMovement = DeveloperConsole.Instance.player.GetComponent<PlayerMovement>();
            this.Commands = Commands;
            AddCommandToConsole();
        }

        public override int RunCommand(string[] input)
        {
            Dictionary<string, ConsoleCommand>.KeyCollection keys = Commands.Keys;
            string display = "\n             List of All Commands" +
                             "\n**************************************************";
            foreach(string key in keys)
            {
                display += string.Format("\n{0} : {1}\n", Commands[key].Command, Commands[key].Description);
            }

            DeveloperConsole.AddStaticMessageToConsole(display);

            return -1;
        }
    }
}
