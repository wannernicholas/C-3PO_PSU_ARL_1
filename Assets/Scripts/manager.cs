using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;

public class manager : MonoBehaviour
{
    public Text eventText;
    public int maxEventTexts = 5;
    public Transform playerTransform;
    public float movementSpeed = 10f;
    public float movementDistance = 10f;

    public GameObject buttonNextLevel;

    private MovementCommand movementCommand;
    private List<string> eventTextList = new List<string>();


    void Start()
    {
        buttonNextLevel.SetActive(false);
        movementCommand = ScriptableObject.CreateInstance<MovementCommand>();
        movementCommand.init("Movement", playerTransform, movementDistance, movementSpeed);
    }

   
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    

    public void doMovement(string direction)
    {
        movementCommand.doCommand(direction);
        buildEventText("Movement", direction);
    }

    private void buildEventText(string command, string argument) 
    {
        string commandText = command + ": " + argument;
        if (eventTextList.Count >= maxEventTexts)
        {
            eventTextList.RemoveAt(eventTextList.Count - 1);
        }
        eventTextList.Insert(0, commandText);

        string result = "";
        for (int i = 0; i < eventTextList.Count; i++)
        {
            result += eventTextList[i] + "\n";
        }

        eventText.text = result;
    }

}