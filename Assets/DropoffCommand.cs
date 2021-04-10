using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Console
{
    public class DropoffCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }
        public override int ArgLength { get; protected set; }
        public PlayerMovement playerMovement;
		ISet<int> set = new HashSet<int>();

		public GameObject dropoffParent;
		public GameObject item1;
		public GameObject item2;
		public GameObject item3;
		public GameObject item4;
		public static bool item1_done, item2_done, item3_done, item4_done;

        public DropoffCommand()
        {
            Name = "Dropoff";
            Command = "dropoff";
            Description = "dropsoff currently held item";
            Help = "Usage: dropoff item"; 
            ArgLength = 1;
            playerMovement = DeveloperConsole.Instance.player.GetComponent<PlayerMovement>();
            AddCommandToConsole();
			
			dropoffParent = GameObject.Find("Password Static");
			item1 = dropoffParent.transform.Find("xX (item 1)").gameObject;
			item2 = dropoffParent.transform.Find("C- (item 2)").gameObject;
			item3 = dropoffParent.transform.Find("3PO (item 3)").gameObject;
			item4 = dropoffParent.transform.Find("Xx (item 4)").gameObject;
			
			item1.gameObject.SetActive(false);
			item2.gameObject.SetActive(false);
			item3.gameObject.SetActive(false);
			item4.gameObject.SetActive(false);
			
			item1_done = item2_done = item3_done = item4_done = false;
			
		}
		
		 public override int RunCommand(string[] input)
        {
			string item_name = input[1];
			
			if(item_name == "item")
			{
				if(PickupCommand.active_item == 1)
				{
					PickupCommand.active_item = 0;
					item1.gameObject.SetActive(true);
					item1_done = true;
					
					DeveloperConsole.AddStaticMessageToConsole("This strengthens your password by adding a lowercase and an uppercase letter");
					
					if(item1_done && item2_done && item3_done && item4_done)
					{
						DeveloperConsole.AddStaticMessageToConsole("Your password is now longer than 8 characters, making it safer");
						DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
					}
				}
				else if(PickupCommand.active_item == 2)
				{
					PickupCommand.active_item = 0;
					item2.gameObject.SetActive(true);
					item2_done = true;
					
					DeveloperConsole.AddStaticMessageToConsole("This strengthens your password by adding an uppercase letter and a special character");
					
					if(item1_done && item2_done && item3_done && item4_done)
					{
						DeveloperConsole.AddStaticMessageToConsole("Your password is now longer than 8 characters, making it safer");
						DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
					}
				}
				else if(PickupCommand.active_item == 3)
				{
					PickupCommand.active_item = 0;
					item3.gameObject.SetActive(true);
					item3_done = true;
					
					DeveloperConsole.AddStaticMessageToConsole("This strengthens your password by adding a number and two uppercase letters");
					
					if(item1_done && item2_done && item3_done && item4_done)
					{
						DeveloperConsole.AddStaticMessageToConsole("Your password is now longer than 8 characters, making it safer");
						DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
					}
				}
				else if(PickupCommand.active_item == 4)
				{
					PickupCommand.active_item = 0;
					item4.gameObject.SetActive(true);
					item4_done = true;
					
					DeveloperConsole.AddStaticMessageToConsole("This strengthens your password by adding a lowercase and an uppercase letter");
					
					if(item1_done && item2_done && item3_done && item4_done)
					{
						DeveloperConsole.AddStaticMessageToConsole("Your password is now longer than 8 characters, making it safer");
						DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
					}
					
				}
				else
				{
					DeveloperConsole.AddStaticMessageToConsole("You are not holding an item");
				}
			}
			else
			{
				return 1;
			}
			
			return -1;
			
		}
		
	}
	
}