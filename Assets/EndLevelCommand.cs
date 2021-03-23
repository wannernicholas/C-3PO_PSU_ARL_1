using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Console
{
    public class EndLevelCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }
        public override int ArgLength { get; protected set; }

        public EndLevelCommand()
        {
            Name = "End level";
            Command = "endlevel";
            Description = "Returns to town";
            Help = "Usage: End level";
            ArgLength = 0;
            AddCommandToConsole();
        }

        public override int RunCommand(string[] input)
        {
            if (PhishingCommand.email_count == 5)
            {
                SceneManager.LoadScene(1);
                return -1;
            }
            return 1;
        }
    }
}