using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIimageAppear : MonoBehaviour
{
    [SerializeField] private Image image_name;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			image_name.enabled = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			image_name.enabled = false;
		}
	}
}
