using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class EnvironmentVariables : MonoBehaviour
{

    public TMP_Text textUI;

    [TextArea(6, 10)]
    public string description;
    public List<EnvironmentConstant> constants;
    public List<string> variables;
    public List<EnvironmentFunction> outputs;

    public Color descriptionCol;
    public Color headerCol;
    


    void Start()
    {
        constants = new List<EnvironmentConstant>();
        variables = new List<string>();
        outputs = new List<EnvironmentFunction>();
        DeclareConstants();
        DeclareVariables();
        DeclareOutputs();

    }

    void DeclareConstants()
    {
        outputs.Add(new EnvironmentFunction("move", 1, ""));
        outputs.Add(new EnvironmentFunction("stop", 0, ""));
    }

    void DeclareVariables()
    {

    }

   void DeclareOutputs()
    {


    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            if (textUI != null)
            {
                textUI.text = FormattedInfoString();
            }
        }
    }

    public string FormattedInfoString()
    {
        string info = "";

        info += SyntaxHighlighter.CreateColouredText(descriptionCol, description) + "\n";

        if (constants.Count > 0)
        {
            info += "\n" + SyntaxHighlighter.CreateColouredText(headerCol, "Constants:") + "\n";
            for (int i = 0; i < constants.Count; i++)
            {
                info += constants[i].name + " = " + constants[i].value;
                info += "\n";
            }
        }

        if (variables.Count > 0)
        {
            info += "\n" + SyntaxHighlighter.CreateColouredText(headerCol, "Variables:") + "\n";
            for (int i = 0; i < variables.Count; i++)
            {
                info += variables[i];
                info += "\n";
            }
        }

        if (outputs.Count > 0)
        {
            info += "\n" + SyntaxHighlighter.CreateColouredText(headerCol, "Outputs:") + "\n";
            for (int i = 0; i < outputs.Count; i++)
            {
                string paramName = (outputs[i].paramSize > 0) ? outputs[i].paramLabel : "";
                info += outputs[i].name + "(" + paramName + ")";
                info += "\n";
            }
        }

        return info;
    }

}

[System.Serializable]
public struct EnvironmentConstant
{
    public string name;
    public float value;

    public EnvironmentConstant(string name,float value)
    {
        this.name = name;
        this.value = value;

    }
}

[System.Serializable]
public struct EnvironmentFunction
{
    public string name;
    public int paramSize;
    public string paramLabel;

    public EnvironmentFunction(string name, int paramSize,string paramLabel)
    {
        this.name = name;
        this.paramSize = paramSize;
        this.paramLabel = paramLabel;

    }
}