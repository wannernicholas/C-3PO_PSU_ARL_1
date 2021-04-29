using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onColisTelepObj : MonoBehaviour
{
    // Start is called before the first frame update\
    public Vector3 dest;
    public GameObject objToTelepot;
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
	{
		objToTelepot.transform.position  = dest;
	}
	
}
