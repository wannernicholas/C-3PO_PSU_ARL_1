using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerStatistics : MonoBehaviourPunCallbacks
{
    private GameObject Player;
    public string name = "";
    public int scenariosCompleted = 0;
    public float timeSpent = 0;

    void Start()
    {
        if (this.photonView.IsMine)
            InvokeRepeating("SyncData", 0, 10);
    }


    void Update()
    {
   
    }



    public void OverideWithData(GameObject Player, string name, int scenariosCompleted, float timeSpent)
    {
        this.name = name;
        this.scenariosCompleted = scenariosCompleted;
        this.timeSpent = timeSpent;
        this.Player = Player;
    }


    public void SyncData()
    {
        Debug.Log("Syncing " + this.name + "\'s Data");
        photonView.RPC("SetPlayerName", RpcTarget.All, this.name);
        photonView.RPC("SetScenariosCompleted", RpcTarget.All, this.scenariosCompleted);
        photonView.RPC("SetTimeSpent", RpcTarget.All, this.timeSpent);
    }

    public GameObject getPlayer()
    {
        return Player;
    }

    [PunRPC]
    void SetPlayerName(string name) { this.name = name; }
    [PunRPC]
    void SetScenariosCompleted(int scenariosCompleted) { this.scenariosCompleted = scenariosCompleted; }
    [PunRPC]
    void SetTimeSpent(float timeSpent) { this.timeSpent = timeSpent; }








}
