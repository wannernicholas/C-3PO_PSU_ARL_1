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
		
		private GameObject player;

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
			
			player = DeveloperConsole.Instance.player;
			
		}
		
		 public override int RunCommand(string[] input)
        {
			string item_name = input[1];
			
			if(item_name == "item")
			{
				if(PickupCommand.active_item == 1)
				{
					if((player.transform.position.x < 15) && (player.transform.position.x > -14) && (player.transform.position.z < 10) && (player.transform.position.z > -8))
					{
						PickupCommand.active_item = 0;
						item1.gameObject.SetActive(true);
						item1_done = true;
					
						if(item1_done && item2_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 9 characters. A computer would crack this password in 12 years! This is considered a safe password");
							DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
						}
						else if(item1_done && item2_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 7 characters. A computer would crack this password in 17 hours");
						}
						else if(item1_done && item2_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 6 characters. A computer would crack this password in 13 minutes");
						}
						else if(item1_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, and numbers comprised of 7 characters. A computer would crack this password in 3 hours");
						}
						else if(item2_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 7 characters. A computer would crack this password in 17 hours");
						}
						else if(item1_done && item2_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters and a special character comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item1_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, and numbers comprised of 5 characters. A computer would crack this password in 3 seconds");
						}
						else if(item1_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item2_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase letters, numbers, and a special character comprised of 5 characters. A computer would crack this password in 10 seconds");
						}
						else if(item2_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, numbers, and a special character comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, and numbers comprised of 5 characters. A computer would crack this password in 3 seconds");
						}
						else if(item1_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 2 characters. A computer would crack this password instantly");
						}
						else if(item2_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains an uppercase letter and a special character comprised of 2 characters. A computer would crack this password instantly");
						}
						else if(item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase letters and numbers comprised of 3 characters. A computer would crack this password instantly");
						}
						else if(item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 2 characters. A computer would crack this password instantly");
						}
						
					}
					else
					{
						DeveloperConsole.AddStaticMessageToConsole("You are not close enough to the dropoff zone");
					}
				}
				else if(PickupCommand.active_item == 2)
				{
					if((player.transform.position.x < 15) && (player.transform.position.x > -14) && (player.transform.position.z < 10) && (player.transform.position.z > -8))
					{
						PickupCommand.active_item = 0;
						item2.gameObject.SetActive(true);
						item2_done = true;
					
						if(item1_done && item2_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 9 characters. A computer would crack this password in 12 years! This is considered a safe password");
							DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
						}
						else if(item1_done && item2_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 7 characters. A computer would crack this password in 17 hours");
						}
						else if(item1_done && item2_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 6 characters. A computer would crack this password in 13 minutes");
						}
						else if(item1_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, and numbers comprised of 7 characters. A computer would crack this password in 3 hours");
						}
						else if(item2_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 7 characters. A computer would crack this password in 17 hours");
						}
						else if(item1_done && item2_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters and a special character comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item1_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, and numbers comprised of 5 characters. A computer would crack this password in 3 seconds");
						}
						else if(item1_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item2_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase letters, numbers, and a special character comprised of 5 characters. A computer would crack this password in 10 seconds");
						}
						else if(item2_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, numbers, and a special character comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, and numbers comprised of 5 characters. A computer would crack this password in 3 seconds");
						}
						else if(item1_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 2 characters. A computer would crack this password instantly");
						}
						else if(item2_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains an uppercase letter and a special character comprised of 2 characters. A computer would crack this password instantly");
						}
						else if(item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase letters and numbers comprised of 3 characters. A computer would crack this password instantly");
						}
						else if(item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 2 characters. A computer would crack this password instantly");
						}
					
					}
					else
					{
						DeveloperConsole.AddStaticMessageToConsole("You are not close enough to the dropoff zone");
					}
				}
				else if(PickupCommand.active_item == 3)
				{
					if((player.transform.position.x < 15) && (player.transform.position.x > -14) && (player.transform.position.z < 10) && (player.transform.position.z > -8))
					{
						PickupCommand.active_item = 0;
						item3.gameObject.SetActive(true);
						item3_done = true;
					
						if(item1_done && item2_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 9 characters. A computer would crack this password in 12 years! This is considered a safe password");
							DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
						}
						else if(item1_done && item2_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 7 characters. A computer would crack this password in 17 hours");
						}
						else if(item1_done && item2_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 6 characters. A computer would crack this password in 13 minutes");
						}
						else if(item1_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, and numbers comprised of 7 characters. A computer would crack this password in 3 hours");
						}
						else if(item2_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 7 characters. A computer would crack this password in 17 hours");
						}
						else if(item1_done && item2_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters and a special character comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item1_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, and numbers comprised of 5 characters. A computer would crack this password in 3 seconds");
						}
						else if(item1_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item2_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase letters, numbers, and a special character comprised of 5 characters. A computer would crack this password in 10 seconds");
						}
						else if(item2_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, numbers, and a special character comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, and numbers comprised of 5 characters. A computer would crack this password in 3 seconds");
						}
						else if(item1_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 2 characters. A computer would crack this password instantly");
						}
						else if(item2_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains an uppercase letter and a special character comprised of 2 characters. A computer would crack this password instantly");
						}
						else if(item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase letters and numbers comprised of 3 characters. A computer would crack this password instantly");
						}
						else if(item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 2 characters. A computer would crack this password instantly");
						}
						
					}
					else
					{
						DeveloperConsole.AddStaticMessageToConsole("You are not close enough to the dropoff zone");
					}
				}
				else if(PickupCommand.active_item == 4)
				{
					if((player.transform.position.x < 15) && (player.transform.position.x > -14) && (player.transform.position.z < 10) && (player.transform.position.z > -8))
					{
						PickupCommand.active_item = 0;
						item4.gameObject.SetActive(true);
						item4_done = true;
					
						if(item1_done && item2_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 9 characters. A computer would crack this password in 12 years! This is considered a safe password");
							DeveloperConsole.AddStaticMessageToConsole("You have completed this scenario, type \"endlevel\" in the console to return to the town");
						}
						else if(item1_done && item2_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 7 characters. A computer would crack this password in 17 hours");
						}
						else if(item1_done && item2_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 6 characters. A computer would crack this password in 13 minutes");
						}
						else if(item1_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, and numbers comprised of 7 characters. A computer would crack this password in 3 hours");
						}
						else if(item2_done && item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase, lowercase letters, numbers, and a special character comprised of 7 characters. A computer would crack this password in 17 hours");
						}
						else if(item1_done && item2_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters and a special character comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item1_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, and numbers comprised of 5 characters. A computer would crack this password in 3 seconds");
						}
						else if(item1_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item2_done && item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase letters, numbers, and a special character comprised of 5 characters. A computer would crack this password in 10 seconds");
						}
						else if(item2_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, numbers, and a special character comprised of 4 characters. A computer would crack this password instantly");
						}
						else if(item3_done && item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase, lowercase letters, and numbers comprised of 5 characters. A computer would crack this password in 3 seconds");
						}
						else if(item1_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 2 characters. A computer would crack this password instantly");
						}
						else if(item2_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains an uppercase letter and a special character comprised of 2 characters. A computer would crack this password instantly");
						}
						else if(item3_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains a mix of uppercase letters and numbers comprised of 3 characters. A computer would crack this password instantly");
						}
						else if(item4_done)
						{
							DeveloperConsole.AddStaticMessageToConsole("Your password now contains uppercase and lowercase letters comprised of 2 characters. A computer would crack this password instantly");
						}
						
					}
					else
					{
						DeveloperConsole.AddStaticMessageToConsole("You are not close enough to the dropoff zone");
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