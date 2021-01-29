using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Environment : MonoBehaviour {

    [Header ("Code")]
    //bool inTestMode;
    //public TextAsset testCode;
    //string testCodeText;

    public EnvironmentVariables EV;
    string code;

    protected VirtualCompiler compiler;
    protected Queue<Function> outputQueue;
    protected bool running;
    protected bool ReadyForNextCommand;

    protected virtual void Start () {
        VirtualOS.RegisterTask (this);
      
    }



    public void StartTask (string code) {
        this.code = code;
        StartCoroutine (StartTaskRoutine ());
    }

    IEnumerator StartTaskRoutine () {
        yield return new WaitForSeconds (.2f);
        Console.DeveloperConsole.AddStaticMessageToConsole("Compiling code...");
        yield return new WaitForSeconds (.5f);
        Run (code);
    }

    protected virtual void Run (string code) {
        this.code = code;
        outputQueue = new Queue<Function> ();
        running = true;
        StartCoroutine(StartNextTestIteration());
    }


    protected void GenerateOutputs (float[] variableValues) {

        //VirtualConsole.Log ("Executing code...");
        //string codeToRun = (inTestMode) ? testCodeText : code;
        string codeToRun = code;

        compiler = new VirtualCompiler (codeToRun);
        for (int i = 0; i < EV.outputs.Count; i++) {
            compiler.AddOutputFunction (EV.outputs[i].name);
        }
        for (int i = 0; i < EV.constants.Count; i++) {
            compiler.AddInput (EV.constants[i].name, EV.constants[i].value);
        }
        for (int i = 0; i < variableValues.Length; i++) {
            compiler.AddInput (EV.variables[i], variableValues[i]);
        }

        //VirtualConsole.LogInputs (inputNames, inputValues);

        List<VirtualFunction> outputs = compiler.Run ();
        foreach(VirtualFunction function in outputs) {
            if (outputs.Count > 0)
            {
                string val = "";
                if (function.values.Count > 0)
                {
                    val = function.values[0];
                }
                var func = new Function() { name = function.name, value = val };
                outputQueue.Enqueue(func);
            }

        //VirtualConsole.LogOutput (func.name, func.value);
        }
    }

    protected IEnumerator StartNextTestIteration ()
    {

        float[] inputs = { };
        GenerateOutputs(inputs);
        //Debug.Log(outputQueue.Count);
        while(outputQueue.Count > 0)
        {

            var func = outputQueue.Dequeue();
  
            if (func.value.Length > 0)
                Console.DeveloperConsole.ExecuteCommand(new string[2] { func.name, func.value });
            else
                Console.DeveloperConsole.ExecuteCommand(new string[1] { func.name});
       


            yield return new WaitForSeconds(3);
        }

        

    }



    public struct Function {
        public string name;
        public string value;
    }
}