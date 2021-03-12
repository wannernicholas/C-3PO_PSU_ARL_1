using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviourPunCallbacks
{

    public NetworkManager networkManager;
    private GameObject player;
    private PlayerStatistics playerstats;
    public Text timeSpentText;
    public Text scenariosCompleted;
    public Text name;
    public Text popUpText;
    public GameObject computer;
    public GameObject teacherUI;


    // Start is called before the first frame update
    void Start()
    {

        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        if (networkManager.username == "Teacher")
        {
            createTeacherPrefab();
        }

        else
        {
            player = PhotonNetwork.Instantiate("Player", new Vector3(0, 15, 0), Quaternion.identity, 0);
            Debug.Log("Player Tag: " + player.tag);
            int newPlayer = networkManager.loadPlayerData(player);
            playerstats = player.GetComponent<PlayerStatistics>();
            if (newPlayer == -1)
                playerstats.name = networkManager.username;
            Debug.Log("Creating player object with name:" + player.GetComponent<PlayerStatistics>().name);
            SetupPlayerRelations(player);
        }
    }

    private void SetupPlayerRelations(GameObject player)
    {
        createComputerPrefab();
        GameObject.Find("Main Camera").GetComponent<CameraMovement>().setPlayer(player.GetComponent<Transform>());
        GameObject.Find("Console Manager").GetComponent<Console.DeveloperConsole>().InitializePlayer(player);
        Debug.Log("Done setting up.");

    }

    private void createComputerPrefab()
    {
        computer = (GameObject)Instantiate(computer);
        GameObject canvas = GameObject.Find("Canvas");
        name = GetChild(canvas, "Text3").GetComponent<Text>();
        timeSpentText = GetChild(canvas, "Text1").GetComponent<Text>();
        scenariosCompleted = GetChild(canvas, "Text2").GetComponent<Text>();
        popUpText = GetChild(GameObject.Find("Top Panel"), "PopUp").GetComponent<Text>();
        Debug.Log("Computer Object created");
        SetUpScene(SceneManager.GetActiveScene().buildIndex);
    }

    private GameObject GetChild(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans == null)
            return null;
        return childTrans.gameObject;
    }

    private void createTeacherPrefab()
    {
        teacherUI = (GameObject)Instantiate(teacherUI);
        GetChild(teacherUI, "Teacher Manager").GetComponent<TeacherManager>().cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
    }

    void OnApplicationQuit()
    {
        if(player!= null)
            networkManager.savePlayerData(player);
    }

    public override void OnLeftRoom()
    {
        OnApplicationQuit();
        SceneManager.LoadScene(0);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void LoadScene(int scene_number)
    {
        SceneManager.LoadScene(scene_number);
    }

    void SetUpScene(int buildIndex)
    {
        // Do nothing on the Main menu scene
        if (buildIndex == 0)
            return;

        // Otherwise look for a PlayerStart component and move the player there:
        var playerStart = FindObjectOfType<PlayerStart>();
        if (playerStart != null)
        {
            player.transform.position = playerStart.transform.position;
            Debug.Log("Player transported to start location");
        }
        

        // Should we disable movement keys
        if (buildIndex == 1)
            SetKeyControls(false);
        else if (buildIndex == 2)
            SetKeyControls(true);
        
        // What pop up message should we show
        if (buildIndex == 1)
            SetPopUpText("");
        if (buildIndex == 2)
        {
            //SetPopUpText("Your movement keys have been disabled! Get to the end of the maze using console commands");
            // TODO: Ideally we would un-set this after a certain period of time
        }
    }

    public void SetPopUpText(string text) 
    {
       popUpText.text = text;
    }

    public void SetKeyControls(bool keys_disabled)
    {
        //Usage: SetKeyControls(true) will disable the player's arrow key control over the robot,
        // but not the command or editor controls
        var playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.keys_disabled = keys_disabled;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
            return;

        if(Input.GetKey(KeyCode.Q))
             networkManager.savePlayerData(player);
        playerstats.timeSpent += Time.deltaTime;
        
        timeSpentText.text = string.Format("Time Spent: {0:0.00} s", playerstats.timeSpent);
        name.text = "Name: " + playerstats.name;
		
     
    }
}

