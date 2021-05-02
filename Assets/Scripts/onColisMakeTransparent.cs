using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onColisMakeTransparent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject makeTransparent;
    public float degree; //.5 is 50% transparency, 1 is 100% transparent, 0 is 0% transparent
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
	{
		Color newColor = makeTransparent.GetComponent<Renderer>().material.color;
		newColor.a = degree;
		makeTransparent.GetComponent<Renderer>().material.color = newColor;
	}
	
}
