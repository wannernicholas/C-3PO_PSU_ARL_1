using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Console
{
    public abstract class ConsoleCommand : MonoBehaviour
    {

        public abstract string Name { get; protected set; }
        public abstract string Command { get; protected set; }
        public abstract string Description { get; protected set; }
        public abstract string Help { get; protected set; }
        public abstract int ArgLength { get; protected set; }

        public void AddCommandToConsole()
        {
            DeveloperConsole.AddCommandToConsole(Command, this);

        }

        public abstract int RunCommand(string[] input);

        public void DisplayCommand()
        {
            string display = $"\n         Overview of Command {Name}            \n" + 
                             $"************************************************\n" +
                             $"Name        : {Name}\n" +
                             $"Command:    : {Command}\n" +
                             $"Description : {Description}\n" +
                             $"Help        : {Help}\n" +
                             $"**************************************************";

            DeveloperConsole.AddStaticMessageToConsole(display);
        }

    }

    public class DeveloperConsole : Program
    {

        public static DeveloperConsole Instance {get; private set;}
        public static Dictionary<string, ConsoleCommand> Commands { get; private set; }
        public static string directory { get; private set; }

        [Header("UI Components")]
        public Canvas consoleCanvas;
        public ScrollRect scrollRect;
        public Text consoleText;
        public Text inputText;
        public InputField consoleInput;


        //Interaction with Robot
        [Header("Robot Components")]
        public GameObject player;
        public VirtualOS virtualOS;

        private void Awake()
        {
            Instance = this;
            Commands = new Dictionary<string, ConsoleCommand>();
            directory = "/Users/James: "; // TODO: Remove this or set it to something useful
            player = null;

        }

        private void Start()
        {
            
        }

        public void InitializePlayer(GameObject player)
        {
            this.player = player;
            CreateCommands();

        }

        private void Update()
        {
            if (!active)
                return;

            if (consoleCanvas.gameObject.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Return) && consoleInput.text.Length > 0)
                {
                    AddMessageToConsole(inputText.text);
                    ParseInput(inputText.text);
                    consoleInput.text = "";
                }
            }

        }

        private void CreateCommands()
        {
      
            MoveCommand moveCommand = new MoveCommand();
            HelpCommand helpCommand = new HelpCommand(Commands);
            ListCommand listCommand = new ListCommand(Commands);
            EditorCommand editorCommand = new EditorCommand(virtualOS);
            StopCommand stopCommand = new StopCommand();
            EndLevelCommand endLevelCommand = new EndLevelCommand();
            DisableKeyCommand disableKeyCommand= new DisableKeyCommand();
			PhishingCommand phishingCommand = new PhishingCommand();
  
        }

        public static void AddCommandToConsole(string  name, ConsoleCommand command)
        {
            Debug.Log(name);
            if (!Commands.ContainsKey(name))
                Commands.Add(name, command);
  
        }

        private void AddMessageToConsole(string msg)
        {
            consoleText.text += directory + msg + "\n";
            scrollRect.verticalNormalizedPosition = 0f;
   
        }

        public static void AddStaticMessageToConsole(string msg)
        {
            DeveloperConsole.Instance.AddMessageToConsole(msg);
            DeveloperConsole.Instance.scrollRect.verticalNormalizedPosition = 0f;

        }

        public static void ExecuteCommand(string[] _input)
        {
            if (_input.Length == 0 || _input == null)
                AddStaticMessageToConsole("Command not recognized");
            else if (!Commands.ContainsKey(_input[0]))
                AddStaticMessageToConsole("Command not recognized");
            else if (Commands[_input[0]].ArgLength != _input.Length - 1)
                AddStaticMessageToConsole("Wrong argument usage. Type help " + _input[0] + "to see correct usage");
            else
            {
                int index = Commands[_input[0]].RunCommand(_input);
                if (index != -1)
                    AddStaticMessageToConsole("One or more of your specified arguments does not exist");
            }


        }

        private void ParseInput(string input)
        {
            string[] _input = input.Split(null);
            ExecuteCommand(_input);
        }


      
    }
}