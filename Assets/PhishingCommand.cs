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
		
		public int email_count = 0;

        public PhishingCommand()
        {
            Name = "Phishing";
            Command = "phishing";
            Description = "Collects the answer if an email is phishing or not";
            Help = "Usage: phishing {email number}_{real/fake}"; //fake if email is phishing, real if email is not phishing
            ArgLength = 1;
            playerMovement = DeveloperConsole.Instance.player.GetComponent<PlayerMovement>();
            AddCommandToConsole();
        }

        public override int RunCommand(string[] input)
        {

            string email_num = input[1]; //which email is being selected
			
			if(email_num == "1_real") //Phishing_text_popup incorrect
			{
				DeveloperConsole.AddStaticMessageToConsole("That is incorrect");
				DeveloperConsole.AddStaticMessageToConsole("This text message may be phishing because it was sent to multiple numbers, none of which you recognize");
			}
			else if(email_num == "1_fake") //Phishing_text_popup correct
			{
				DeveloperConsole.AddStaticMessageToConsole("That is correct");
				DeveloperConsole.AddStaticMessageToConsole("This text message may be phishing because it was sent to multiple numbers, none of which you recognize");
			}
			else if(email_num == "2_real") //Phishing_goggle_signup_popup incorrect
			{
				DeveloperConsole.AddStaticMessageToConsole("That is incorrect");
				DeveloperConsole.AddStaticMessageToConsole("This may be phishing because the URL at the top of the page does not match what the Goggle signin page should be");
			}
			else if(email_num == "2_fake") //Phishing_goggle_signup_popup correct
			{
				DeveloperConsole.AddStaticMessageToConsole("That is correct");
				DeveloperConsole.AddStaticMessageToConsole("This may be phishing because the URL at the top of the page does not match what the Goggle signin page should be");
			}
			else if(email_num == "3_real") //New Video Game incorrect
			{
				DeveloperConsole.AddStaticMessageToConsole("That is incorrect");
				DeveloperConsole.AddStaticMessageToConsole("This may be phishing because the email address at the top does not match the email address in the sign off");
			}
			else if(email_num == "3_fake") //New Video Game correct
			{
				DeveloperConsole.AddStaticMessageToConsole("That is correct");
				DeveloperConsole.AddStaticMessageToConsole("This may be phishing because the email address at the top does not match the email address in the sign off");
			}
			else if(email_num == "4_real") //Highschool password reset correct
			{
				DeveloperConsole.AddStaticMessageToConsole("That is correct");
				DeveloperConsole.AddStaticMessageToConsole("This is real because you requested that your password be reset");
			}
			else if (email_num == "4_fake") //Highschool password reset incorrect
			{
				DeveloperConsole.AddStaticMessageToConsole("That is incorrect");
				DeveloperConsole.AddStaticMessageToConsole("This is real because you requested that your password be reset");
			}
			else if(email_num == "5_real") //University correct
			{
				DeveloperConsole.AddStaticMessageToConsole("That is correct");
				DeveloperConsole.AddStaticMessageToConsole("This is real because you applied to Miskatonic University and have been awaiting a response email");
			}
			else if (email_num == "5_fake") //University incorrect
			{
				DeveloperConsole.AddStaticMessageToConsole("That is incorrect");
				DeveloperConsole.AddStaticMessageToConsole("This is real because you applied to Miskatonic University and have been awaiting a response email");
			}
			else
			{
				return 1; //triggers error message in DeveloperConsole.cs in function ExecuteCommand
			}

            

            return -1;

        }
		
		/*void Update()
		{
			if(email_count == 5)
			{
				Scene sceneToLoad = SceneManager.GetSceneByName("Player Scene");
                SceneManager.LoadScene(sceneToLoad.name);
			}
		} */
    }
}