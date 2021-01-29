using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraMovement : MonoBehaviour
{
    private Transform player;
    public Vector3 offset;
    void Awake()
    {
        player = null;
    }
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
   
        }


        
    }

   public void setPlayer(Transform player) { this.player = player; }
}
