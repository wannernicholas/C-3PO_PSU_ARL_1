using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Console
{
    public class BackstoryCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }
        public override int ArgLength { get; protected set; }

        public BackstoryCommand()
        {
            Name = "Backstory";
            Command = "backstory";
            Description = "Gives relevant information on each email";
            Help = "Usage: backstory {email_number}";
            ArgLength = 1;
            AddCommandToConsole();
        }

        public override int RunCommand(string[] input)
        {
            string email_num = input[1];
			
			if(email_num == "1")
			{
				DeveloperConsole.AddStaticMessageToConsole("You receive a group text message from a number that you don't recognize. It contains a link to the social media site tiktak");
			}
			
			if(email_num == "2")
			{
				DeveloperConsole.AddStaticMessageToConsole("You open a goggles signin page from an official looking email you receive asking you to login. You notice that the url seems off");
			}
			
			if(email_num == "3")
			{
				DeveloperConsole.AddStaticMessageToConsole("You receive an email from your friend Victor asking you to download a game. You don't remember him talking about any new game");
			}
			
			if(email_num == "4")
			{
				DeveloperConsole.AddStaticMessageToConsole("You requested that your high school reset your password. You receive this email a short time later");
			}
			
			if(email_num == "5")
			{
				DeveloperConsole.AddStaticMessageToConsole("You applied to Miskatonic University. You receive this email a short time later");
			}
			
			
			
            return -1;
        }
    }
}