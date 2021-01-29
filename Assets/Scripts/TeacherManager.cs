using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

namespace Photon.Pun.Demo.PunBasics
{
    public class TeacherManager : MonoBehaviourPunCallbacks
    {
        public static int was_teacher = 0;
        
        [SerializeField]
        private GameObject controlPanel;
        [SerializeField]
        private Text feedbackText;

        bool isConnecting;

        [Space(10)]
        [Header("Custom Variables")]
        public InputField roomNameField;
        public GameObject buttonViewStudent;
        public GameObject buttonViewStudentStat;
        public GameObject buttonSendAttack;
        public GameObject buttonSendAttackAll;

        string roomName = "";

        void Start()
        {
            Debug.Log("In Teacher Scene");
            if (!PhotonNetwork.IsConnected)
            {
                SceneManager.LoadScene("Launcher");
                return;
            }
            roomNameField.enabled = true;
            buttonViewStudent.SetActive(true);

            if (PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer))
                Debug.Log(PhotonNetwork.LocalPlayer + "is now master client");
            else
                Debug.Log(PhotonNetwork.LocalPlayer + "is not master client");
        }

        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;    
        }


        public int TeacherSeen()
        {
            return was_teacher;
        }

        public void OnClickLeaveRoom()
        {
            DontDestroyOnLoad(gameObject);
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel(0);
        }


        public override void OnDisconnected(DisconnectCause cause)
        {
            isConnecting = false;
            Debug.LogError("Disconnected. Please check your Internet connection.");
        }
    }
}


