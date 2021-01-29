using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.IO;

public class NetworkManager : MonoBehaviour
{

    public string username;
    public Dictionary<string, UserInfo> userInfo;

    RSACryptoServiceProvider provider;
    RSAParameters rsaKeyInfo;

    public class UserInfo 
    {
        public byte[] password {get; set;}
        public bool isLoggedIn {get; set;}

        public UserInfo(byte[] pass, bool loggedIn)
        {
            password = pass;
            isLoggedIn = loggedIn;

        }
    }

    void Awake()
    {
        // userInfo = new List<User>();
        // userInfo = new Dictionary<string, byte[]>();
        userInfo = new Dictionary<string, UserInfo>();

        provider = new RSACryptoServiceProvider();
        rsaKeyInfo = provider.ExportParameters(false);

        provider.ToXmlString(true);
        addUser("James", Encrypt("Abc"));
        addUser("Rebecca", Encrypt("Hello"));
        addUser("Chris", Encrypt("Hi"));
        addUser("Teacher", Encrypt("1"));
        addUser("Test", Encrypt("Test"));

        DontDestroyOnLoad(this);

    }


    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void addUser(string Username, byte[] Password)
    {
        UserInfo newUserInfo = new UserInfo(Password, false);
        userInfo.Add(Username, newUserInfo);
    }

    public void setUserLoginStatus(string Username, bool status)
    {
        userInfo[Username].isLoggedIn = status;
    }

    public void addNewUser(string Username, string Password)
    {
        addUser(Username, Encrypt(Password));
    }

    private byte[] Encrypt(string password)
    {
        return provider.Encrypt(System.Text.Encoding.UTF8.GetBytes(password), true);
    }

    private string Decrypt(byte[] encryptedPassword)
    {
        return System.Text.Encoding.UTF8.GetString(provider.Decrypt(encryptedPassword, true));
    }

    public string validateLogin(string name, string password)
    {
        if (userInfo.ContainsKey(name) && Decrypt(userInfo[name].password) == password && userInfo[name].isLoggedIn == false)
        {
            Debug.Log("correct password");
            username = name;
            return "good";
            // return true;
        }
        else if (userInfo.ContainsKey(name) && userInfo[name].isLoggedIn == true){
            Debug.Log("User is already logged in!");
            return "alreadyLoggedIn";
            // return false;
        }
        else if (userInfo.ContainsKey(name) && Decrypt(userInfo[name].password) != password)
        {
            Debug.Log("Incorrect Username/Password!");
            return "wrongPassword";
            // return false;
        }
        else
        {
            return "userDoesNotExist";
        }

    }


    public int loadPlayerData(GameObject player)
    {

        string jsonFilePath = Application.dataPath + "/" + username + ".txt";
        string json = "";
        try
        {
            json = File.ReadAllText(Application.dataPath + "/" + username + ".txt");
 
          
        }
        catch
        {
            Debug.Log("New player detected. Need to create new instance of player data.");
            return -1;
        }

        SaveData loadedPlayer = JsonUtility.FromJson<SaveData>(json);
        Transform playerTransform = player.GetComponent<Transform>();
        PlayerStatistics playerStats = player.GetComponent<PlayerStatistics>();
        playerTransform.position = loadedPlayer.Position;
        playerTransform.rotation = loadedPlayer.Rotation;
        playerStats.OverideWithData(player,loadedPlayer.name, loadedPlayer.scenariosCompleted, loadedPlayer.timeSpent);
        Debug.Log("Loaded player successfully. Name is " + playerStats.name);
        return 1;

    }


    public void savePlayerData(GameObject player)
    {
        Transform playerTransform = player.GetComponent<Transform>();
        PlayerStatistics playerStats = player.GetComponent <PlayerStatistics>();

        SaveData save = new SaveData();
        save.Position = player.GetComponent<Transform>().position;
        save.Rotation = player.GetComponent<Transform>().rotation;
        save.timeSpent = player.GetComponent<PlayerStatistics>().timeSpent;
        save.scenariosCompleted = player.GetComponent<PlayerStatistics>().scenariosCompleted;
        save.name = player.GetComponent<PlayerStatistics>().name;

        string json = JsonUtility.ToJson(save);
        string jsonFilePath = Application.dataPath + "/" + username + ".txt";
        File.WriteAllText(jsonFilePath, json);
        Debug.LogFormat("Saved Object Successfully in the file path {0}.", Application.dataPath);

    }


}

[System.Serializable]
public class SaveData
{
    public Vector3 Position;
    public Quaternion Rotation;
    public float timeSpent;
    public string name;
    public int scenariosCompleted;
}