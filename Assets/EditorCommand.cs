using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Console
{
    public class EditorCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }
        public override int ArgLength { get; protected set; }
        public VirtualOS virtualOS;

        public EditorCommand(VirtualOS virtualOS)
        {
            Name = "Editor";
            Command = "editor";
            Description = "Opens code editor";
            Help = "Usage: No arguments";
            ArgLength = 0;
            this.virtualOS = virtualOS;
            AddCommandToConsole();
        }

        public override int RunCommand(string[] input)
        {
            virtualOS.OpenProgram(virtualOS.Editor);
            return -1;
        }
    }
}
