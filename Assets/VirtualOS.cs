using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualOS : MonoBehaviour
{

    public Console.DeveloperConsole Console;
    public CodeEditor Editor;
    public Program ActiveProgram;
    public Environment Env;
    static VirtualOS _instance;
    // Start is called before the first frame update
    void Start()
    {
        if (ActiveProgram != null)
            ActiveProgram.SetActive(true);
        if (Console != null)
            Console.SetActive(true);
    }


    static VirtualOS Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<VirtualOS>();
            }
            return _instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        
    }

    void HandleInput()
    {

        // Run code
        if (Input.GetKeyDown(KeyCode.R) && ControlOperatorDown())
        {
            if (ActiveProgram == Editor)
            {
                RunTask();
            }
        }


        // Close open program
        if (Input.GetKeyDown(KeyCode.Q) && ControlOperatorDown())
        {
            if (ActiveProgram != null)
            {
                CloseProgram(ActiveProgram);
            }
        }


    }

    bool ControlOperatorDown()
    {
        bool ctrl = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        bool cmd = Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand);
        return ctrl || cmd;
    }

    public void OpenProgram(Program program)
    {
        if (ActiveProgram != null)
            ActiveProgram.SetActive(false);

        ActiveProgram = program;
        ActiveProgram.SetActive(true);
    }


    public void CloseProgram(Program program)
    {
        if(ActiveProgram != null)
        {
            ActiveProgram.SetActive(false);
            ActiveProgram = null;
        }

    }


    void RunTask()
    {
        string code = Editor.code;
        Env.StartTask(code);
    }

    public static void RegisterTask(Environment Env)
    {
       // Instance.RunTask();
    }
}
