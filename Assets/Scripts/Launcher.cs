using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

using Photon.Realtime;

namespace Photon.Pun.Demo.PunBasics
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private GameObject controlPanel;

        [SerializeField]
        private Text feedbackText;

        [SerializeField]
        private byte maxPlayersPerRoom = 1;

        [SerializeField]
        private Text teacherPassword;

        bool isConnecting;

      

        string gameVersion = "1";
        string decryptedPassword="Abc";

        [Space(10)]
        [Header("Custom Variables")]
        public InputField playerNameField;
        public InputField roomNameField;
        public InputField playerPasswordField;

        [Space(5)]
        public Text playerStatus;
        public Text connectionStatus;
        public Text roomLabel;
        public Text nameLabel;
        public Text passwordLabel;

        [Space(5)]
        public GameObject roomJoinUI;
        public GameObject buttonLoadArena;
        public GameObject buttonJoinRoom;

        string playerName = "";
        string roomName = "";
        string password="";

        public NetworkManager networkManager;
 



        void Start()
        {
            PlayerPrefs.DeleteAll();

            Debug.Log("Connecting to Photon Network");

            roomJoinUI.SetActive(false);
            buttonLoadArena.SetActive(false);
            ConnectToPhoton();
        }

        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;

        }


        public void SetPlayerName(string name)
        {
            playerName = name;
            Debug.Log("Player name is set to " + playerName);
        }

        public void SetRoomName(string name)
        {
            roomName = name;
            Debug.Log("Room name is set to " + roomName);
        }


        void ConnectToPhoton()
        {
            connectionStatus.text = "Connecting...";
            PhotonNetwork.GameVersion = gameVersion; //1
            PhotonNetwork.ConnectUsingSettings(); //2
        }

        public void JoinRoom()
        {

            if (PhotonNetwork.IsConnected)
            {


                name = playerNameField.text;
                password = playerPasswordField.text;
                roomName = roomNameField.text;

                if (networkManager.validateLogin(name, password) == "good")
                {
                    playerStatus.text = "Correct password!";
                    PhotonNetwork.LocalPlayer.NickName = playerName; //1
                    Debug.Log("PhotonNetwork.IsConnected! | Trying to Create/Join Room " +
                        roomNameField.text);
                    RoomOptions roomOptions = new RoomOptions(); //2
                    TypedLobby typedLobby = new TypedLobby(roomName, LobbyType.Default); //3

                    PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, typedLobby); //4  

                }
                else if (networkManager.validateLogin(name, password) == "alreadyLoggedIn")
                {
                    playerStatus.text = "User is already logged in.";
                }
                else if (networkManager.validateLogin(name, password) == "wrongPassword")
                {
                    playerStatus.text = "Incorrect Username/Password.";
                }
                else
                {
                    playerStatus.text = "User does not exist.";
                }

            }
        }


        public void CreateNewUser()
        {
            if (PhotonNetwork.IsConnected)
            {
                string pname = playerNameField.text;
                string pword = playerPasswordField.text;

                playerName = playerNameField.text;
                password = playerPasswordField.text;

                networkManager.addNewUser(pname, pword);
                playerStatus.text = "New User Created!";
                return;
            }
        }

        public void LoadArena()
        {
            Debug.Log("Load Arena was called.");
            playerName = playerNameField.text;
            if (playerName == "Teacher")
            {
                PhotonNetwork.LoadLevel(1);
                Debug.Log("Loading...");
            }
            else
            {
                networkManager.setUserLoginStatus(playerName, true);
                PhotonNetwork.LoadLevel(1);
            }
        }


        public override void OnConnected()
        {
            base.OnConnected();
            connectionStatus.text = "Connected to Photon!";
            connectionStatus.color = Color.green;
            roomJoinUI.SetActive(true);
            buttonLoadArena.SetActive(false);

        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            isConnecting = false;
            controlPanel.SetActive(true);
            Debug.LogError("Disconnected. Please check your Internet connection.");
        }

        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.IsMasterClient)
                Debug.Log(playerNameField.text +" is master client");
            else
                Debug.Log(playerNameField.text + " is game client");

            buttonLoadArena.SetActive(true);
            roomNameField.enabled=false;
            playerNameField.enabled=false;
            playerPasswordField.enabled=false;
            buttonJoinRoom.SetActive(false);
            playerStatus.text = "Connected to Lobby";

        }



    }
}