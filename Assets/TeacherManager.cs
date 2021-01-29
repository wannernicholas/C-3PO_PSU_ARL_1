using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Linq;

public class TeacherManager : MonoBehaviourPunCallbacks
{

    public PlayerList playerList;
    public GameObject buttonPrefab;
    public GameObject buttonListContent;
    public Button monitorButton;
    public Button backButton;

    private Dictionary<string, GameObject> buttonDictionary;
    private string selectedPlayerName;
    private GameObject selectedPlayer;
    public CameraMovement cameraMovement;
    public GameObject teacherUI;
    public Button movementButton;

    public Text timespent;
    public Text name;
    public Text scenariosCompleted;
    public Text movementDisabled;

    // Start is called before the first frame update
    void Start()
    {
        buttonDictionary = new Dictionary<string, GameObject>();
        monitorButton.onClick.AddListener(SpectatePlayer);
        monitorButton.gameObject.SetActive(false);
        movementButton.gameObject.SetActive(false);
        movementButton.onClick.AddListener(ToggleMovement);
        backButton.onClick.AddListener(BackToLobby);
        backButton.gameObject.SetActive(false);
        selectedPlayerName = null;
        selectedPlayer = null;
     
    }

    // Update is called once per frame
    void Update()
    {

        updatePlayerList();

        if (selectedPlayerName != null)
        {
            PlayerStatistics activePlayer = playerList.getPlayerList()[selectedPlayerName];
            timespent.text = "Total Time Spent: " + string.Format("{0:.##}",activePlayer.timeSpent) + " s";
            name.text = "Student : " + activePlayer.name;
            scenariosCompleted.text = "Scenarios Completed: " + activePlayer.scenariosCompleted.ToString();
            movementDisabled.text = "Movement Disabled: " + activePlayer.GetComponent<PlayerMovement>().keys_disabled.ToString();
        }
            


    }


    private void updatePlayerList()
    {
        foreach(KeyValuePair<string,PlayerStatistics> entry in playerList.getPlayerList())
        {
            if (!buttonDictionary.ContainsKey(entry.Key))
            {
                AddButton(entry.Value.name);
            }
        }

        foreach (KeyValuePair<string, GameObject> entry in buttonDictionary.Reverse())
        {
            if (!playerList.getPlayerList().ContainsKey(entry.Key))
            {
                if (entry.Key == selectedPlayerName)
                {
                    selectedPlayerName = null;
                    HideMonitorButton();
                    HideToggleMovementButton();
                }
                RemoveButton(entry.Key);
            }
        }


    }

    
    private void HideToggleMovementButton()
    {
        movementButton.gameObject.SetActive(false);
    }
    private void ShowToggleMovementButton()
    {
        movementButton.gameObject.SetActive(true);
    }
    
    private void HideMonitorButton()
    {
        monitorButton.gameObject.SetActive(false);
    }

    private void ShowMonitorButton()
    {
        monitorButton.gameObject.SetActive(true);
    }

    private void AddButton(string name)
    {
        Debug.Log("Creating Button for player: " + name);
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.transform.SetParent(buttonListContent.transform);
        button.GetComponent<Button>().onClick.AddListener(delegate { onClick(name); });
        button.transform.GetChild(0).GetComponent<Text>().text = name;
        buttonDictionary.Add(name, button);
    }

    private void RemoveButton(string name)
    {
        GameObject button = buttonDictionary[name];
        buttonDictionary.Remove(name);
        Destroy(button);

    }


    void onClick(string name)
    {
        Debug.Log("Button Clicked");
        selectedPlayerName = name;
        selectedPlayer = playerList.getPlayerList()[selectedPlayerName].getPlayer();
        ShowMonitorButton();
        ShowToggleMovementButton();
    }

    void BackToLobby()
    {
        this.teacherUI.SetActive(true);
        backButton.gameObject.SetActive(false);

    }
    private void ToggleMovement()
    {
        if(selectedPlayerName != null)
        {
            // get a reference to the selected player's movement manager
            PlayerMovement playerMovement = playerList.getPlayerList()[selectedPlayerName].gameObject.GetComponent<PlayerMovement>();
            playerMovement.keys_disabled = !playerMovement.keys_disabled;
            // TODO: Add some output / feedback to the teacher ui to show what we just did
            Debug.Log("Toggled movement controls for player: " + selectedPlayerName + " to: " + playerMovement.keys_disabled.ToString());
            PlayerManager playerManager = playerList.getPlayerList()[selectedPlayerName].gameObject.GetComponentInParent<PlayerManager>();
            Debug.Log("Got player's playerManager");
            //Debug.Log("Player Manager Time Spent: " + playerManager.timeSpentText);
            playerManager.SetPopUpText("You've had your movement keys disabled. Try to enable them again with a console command!");
        }
    }

    private void SpectatePlayer()
    {
        cameraMovement.setPlayer(playerList.getPlayerList()[selectedPlayerName].gameObject.GetComponent<Transform>());
        this.teacherUI.SetActive(false);
        backButton.gameObject.SetActive(true);
    }

}
