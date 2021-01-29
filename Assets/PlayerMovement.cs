using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{
    public float dX = 0f;
    public float dZ = 0f;
    public float dY = 0f;
    public bool command_running = false;
    public bool keys_disabled = false;
    public float speed = 1000f;
    public Rigidbody rb;
    public PhotonView photonView;
    //public Animator anim;

    void Update()
    {

        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            return;

        if (Input.GetKey(KeyCode.UpArrow) && !keys_disabled){
            command_running = false;
            dZ = speed;
        }   
        else if (Input.GetKey(KeyCode.DownArrow) && !keys_disabled){
            command_running = false;
            dZ = -speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !keys_disabled){
            command_running = false;
            dX = -speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !keys_disabled){
            command_running = false;
            dX = speed;
        }
        else if (Input.GetKey(KeyCode.Space) && !keys_disabled){
            command_running = false;
            dY = speed;
        }
        else if (!command_running){
            dZ = 0;
            dY = 0;
            dX = 0;
        }
        //anim.SetFloat("Forward", dZ);
        //anim.SetFloat("Right", dX);
    }

    void FixedUpdate()
    {

        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            return;

        rb.AddForce(dX * Time.deltaTime, dY * Time.deltaTime, dZ * Time.deltaTime);
    }

}

