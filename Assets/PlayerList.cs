using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class PlayerList : MonoBehaviour
{
    private Dictionary<string, PlayerStatistics> playerList;
    // Start is called before the first frame update
    void Awake()
    {
        playerList = new Dictionary<string, PlayerStatistics>();   
    }

 

    void Update()
    {


        DebugPlayerList();

        //Create a list of players in the Unity Game
        GameObject[] players = GameObject.FindGameObjectsWithTag("student");
        Debug.Log("Amoung of players " + players.Count().ToString());
        //Add any player thats in the Unity Game but not in the playerList (The player joined the game)
        foreach(GameObject player in players)
        {
            PlayerStatistics playerStats = player.GetComponent<PlayerStatistics>();
            if (playerStats.name != "" && !playerList.ContainsKey(playerStats.name))
            {
                Debug.Log("Adding " + playerStats.name + " to player list.");
                playerList.Add(playerStats.name, playerStats);
            }
            
        }

        //Create a set of playernames from the Players List
        var playerNames = from i in Enumerable.Range(0, players.Count()) select players[i].GetComponent<PlayerStatistics>().name;
        playerNames = new HashSet<string>(playerNames);

        //Remove any playername thats in the playerList but not in the Unity Game (The player left the game)
        foreach(KeyValuePair<string,PlayerStatistics> entry in playerList.Reverse())
        {
            if(!playerNames.Contains(entry.Key))
            {
                playerList.Remove(entry.Key);
            }
        }


    }


    public void addPlayer(PlayerStatistics playerStats)
    {
        Debug.Log(playerList);
        playerList.Add(playerStats.name, playerStats);
    }

    public Dictionary<string,PlayerStatistics> getPlayerList()
    {
        return playerList;
    }


    private void DebugPlayerList()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Hit Q");
            GameObject player = PhotonNetwork.Instantiate("Player", new Vector3(0, 15, 0), Quaternion.identity, 0);
            PlayerStatistics playerstats = player.GetComponent<PlayerStatistics>();
            playerstats.name = new System.Random().Next(1,100).ToString();
        }
    }
}
