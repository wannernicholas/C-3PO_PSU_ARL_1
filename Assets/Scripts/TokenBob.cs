using UnityEngine;
using System;
using System.Collections;

public class TokenBob : MonoBehaviour
{
    float originalY;
    float origionalYRot;
    public float floatStrength = 1; // You can change this in the Unity Editor to 
    public float rotStrength = 1;   // change the range of y positions that are possible.

    void Start()
    {
        this.originalY = this.transform.position.y;
        this.origionalYRot = this.transform.rotation.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            originalY + ((float)Math.Sin(Time.time) * floatStrength),
            transform.position.z);
        transform.Rotate(Vector3.up * (float)Math.Sin(Time.time) * rotStrength);
    }
}