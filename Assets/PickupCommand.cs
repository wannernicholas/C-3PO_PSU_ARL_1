using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Console
{
    public class PickupCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }
        public override int ArgLength { get; protected set; }
        public PlayerMovement playerMovement;
		ISet<int> set = new HashSet<int>();

		public GameObject pickupParent;
		public static int active_item;

        public PickupCommand()
        {
            Name = "Pickup";
            Command = "pickup";
            Description = "picksup a given item";
            Help = "Usage: pickup {item}"; 
            ArgLength = 1;
            playerMovement = DeveloperConsole.Instance.player.GetComponent<PlayerMovement>();
            AddCommandToConsole();
			
			pickupParent = GameObject.Find("Password Pickup");
			active_item = 0;
        }

        public override int RunCommand(string[] input)
        {
			string item_name = input[1];
						
			if(active_item != 0)
			{
				DeveloperConsole.AddStaticMessageToConsole("You are already holding an item");
			}
			else if(item_name == "xX") //item1
			{
				if(DropoffCommand.item1_done)
				{
					DeveloperConsole.AddStaticMessageToConsole("You have already completed this task");
				}
				else
				{
					active_item = 1;
					GameObject item1 = pickupParent.transform.Find("xX (item 1)").gameObject;
					item1.gameObject.SetActive(false);
				}
			}			
			else if(item_name == "C-")//item2
			{
				if(DropoffCommand.item2_done)
				{
					DeveloperConsole.AddStaticMessageToConsole("You have already completed this task");
				}
				else
				{
					active_item = 2;
					GameObject item2 = pickupParent.transform.Find("C- (item 2)").gameObject;
					item2.gameObject.SetActive(false);
				}
			}
			else if(item_name == "3PO" || item_name == "3P0")//item3
			{
				if(DropoffCommand.item3_done)
				{
					DeveloperConsole.AddStaticMessageToConsole("You have already completed this task");
				}
				else
				{
					active_item = 3;
					GameObject item3 = pickupParent.transform.Find("3P0 (item 3)").gameObject;
					item3.gameObject.SetActive(false);
				}
			}
			else if(item_name == "Xx")//item4
			{
				if(DropoffCommand.item4_done)
				{
					DeveloperConsole.AddStaticMessageToConsole("You have already completed this task");
				}
				else
				{
					active_item = 4;
					GameObject item4 = pickupParent.transform.Find("Xx (item 4)").gameObject;
					item4.gameObject.SetActive(false);
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

