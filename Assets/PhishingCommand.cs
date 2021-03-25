using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Console
{
    public class PhishingCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }
        public override int ArgLength { get; protected set; }
        public PlayerMovement playerMovement;
		ISet<int> set = new HashSet<int>();


		public static int email_count = 0;

        public PhishingCommand()
        {
            Name = "Phishing";
            Command = "phishing";
            Description = "Collects the answer if an email is phishing or not";
            Help = "Usage: phishing {email number}_{real/fake}"; //fake if email is phishing, real if email is not phishing
            ArgLength = 2;
            playerMovement = DeveloperConsole.Instance.player.GetComponent<PlayerMovement>();
            AddCommandToConsole();
        }

        public override int RunCommand(string[] input)
        {

            string email_num = input[1]; //which email is being selected
			string phishing_state = input[2];
			
			if(email_num == "1")
			{
				if(phishing_state == "real") //Phishing_text_popup incorrect
				{
					DeveloperConsole.AddStaticMessageToConsole("That is incorrect");
					DeveloperConsole.AddStaticMessageToConsole("This text message may be phishing because it was sent to multiple numbers, none of which you recognize");
				}
				else if(phishing_state == "fake") //Phishing_text_popup correct
				{
					if (set.Contains(1))
					{
						DeveloperConsole.AddStaticMessageToConsole("You've already completed this task");
					}
					else
					{
						DeveloperConsole.AddStaticMessageToConsole("That is correct");
						DeveloperConsole.AddStaticMessageToConsole("This text message may be phishing because it was sent to multiple numbers, none of which you recognize");
						set.Add(1);
						email_count++;
						if (email_count == 5)
						{
							DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
						}
					}
				}
			}
			else if (email_num == "2")
			{
				if(phishing_state == "real") //Phishing_goggle_signup_popup incorrect
				{
					DeveloperConsole.AddStaticMessageToConsole("That is incorrect");
					DeveloperConsole.AddStaticMessageToConsole("This may be phishing because the URL at the top of the page does not match what the Goggle signin page should be");
				}
				else if(phishing_state == "fake") //Phishing_goggle_signup_popup correct
				{
					if (set.Contains(2))
					{
						DeveloperConsole.AddStaticMessageToConsole("You've already completed this task");
					}
					else
					{
						DeveloperConsole.AddStaticMessageToConsole("That is correct");
						DeveloperConsole.AddStaticMessageToConsole("This may be phishing because the URL at the top of the page does not match what the Goggle signin page should be");
						set.Add(2);
						email_count++;
						if (email_count == 5)
						{
							DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
						}
					}
				}
			}
			else if(email_num == "3")
			{
				if(phishing_state == "real") //New Video Game incorrect
				{
					DeveloperConsole.AddStaticMessageToConsole("That is incorrect");
					DeveloperConsole.AddStaticMessageToConsole("This may be phishing because the email address at the top does not match the email address in the sign off");
				}
				else if(phishing_state == "fake") //New Video Game correct
				{
					if (set.Contains(3))
					{
						DeveloperConsole.AddStaticMessageToConsole("You've already completed this task");
					}
					else
					{
						DeveloperConsole.AddStaticMessageToConsole("That is correct");
						DeveloperConsole.AddStaticMessageToConsole("This may be phishing because the email address at the top does not match the email address in the sign off");
						set.Add(3);
						email_count++;
						if (email_count == 5)
						{
							DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
						}
					}
				}
			}
			else if(email_num == "4")
			{
				if(phishing_state == "real") //Highschool password reset correct
				{
					if (set.Contains(4))
					{
						DeveloperConsole.AddStaticMessageToConsole("You've already completed this task");
					}
					else
					{
						DeveloperConsole.AddStaticMessageToConsole("That is correct");
						DeveloperConsole.AddStaticMessageToConsole("This is real because you requested that your password be reset");
						set.Add(4);
						email_count++;
						if (email_count == 5)
						{
							DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
						}
					}
				}
				else if (phishing_state == "fake") //Highschool password reset incorrect
				{
					DeveloperConsole.AddStaticMessageToConsole("That is incorrect");
					DeveloperConsole.AddStaticMessageToConsole("This is real because you requested that your password be reset");
				}
			}
			else if(email_num == "5")
			{
				if(phishing_state == "real") //University correct
				{
					if (set.Contains(5))
					{
						DeveloperConsole.AddStaticMessageToConsole("You've already completed this task");
					}
					else
					{
						DeveloperConsole.AddStaticMessageToConsole("That is correct");
						DeveloperConsole.AddStaticMessageToConsole("This is real because you applied to Miskatonic University and have been awaiting a response email");
						set.Add(5);
						email_count++;
						if (email_count == 5)
						{
							DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
						}
					}
				}
				else if (phishing_state == "fake") //University incorrect
				{
					DeveloperConsole.AddStaticMessageToConsole("That is incorrect");
					DeveloperConsole.AddStaticMessageToConsole("This is real because you applied to Miskatonic University and have been awaiting a response email");
				}
			}
			else
			{
				return 1; //triggers error message in DeveloperConsole.cs in function ExecuteCommand
			}
            return -1;

        }
		
    }
}