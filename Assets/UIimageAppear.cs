using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIimageAppear : MonoBehaviour
{
    [SerializeField] private Image image_name;
	public Button yesButton;
	public Button noButton;
	
	void Start()
	{
		image_name.enabled = false;
		yesButton.gameObject.SetActive(false);
		noButton.gameObject.SetActive(false);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			image_name.enabled = true;
			yesButton.gameObject.SetActive(true);
			noButton.gameObject.SetActive(true);
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
