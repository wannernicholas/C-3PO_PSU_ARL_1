using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIimageAppear : MonoBehaviour
{
    public GameObject image_name;
	
	
	void Start()
	{
		image_name.gameObject.SetActive(false);
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		
		image_name.gameObject.SetActive(true);
		
		if(other.CompareTag("Player"))
		{
			image_name.gameObject.SetActive(true);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		image_name.gameObject.SetActive(false);
		
		if(other.CompareTag("Player"))
		{
			//image_name.gameObject.SetActive(false);
		}
	}
}
