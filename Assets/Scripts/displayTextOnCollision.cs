using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayTextOnCollision : MonoBehaviour
{
    // Start is called before the first frame update\
    public string textToDisplay;
    public GameObject objectToAccess;
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
	{
		//image_name.gameObject.SetActive(true);
		//ScriptName scriptToAccess = objectToAccess.GetComponent<PlayerManager>().SetPopUpText(textToDisplay);
		objectToAccess.GetComponent<PlayerManager>().SetPopUpText(textToDisplay);
// get the script on the object (make sure the script is a public class)      
 
		//scriptToAccess.SetPopUpText(textToDisplay);
	}
	void OnTriggerExit(Collider other)
	{
		//image_name.gameObject.SetActive(false);
		//ScriptName scriptToAccess = objectToAccess.GetComponent<PlayerManager>().SetPopUpText(textToDisplay);
		objectToAccess.GetComponent<PlayerManager>().SetPopUpText("");
// get the script on the object (make sure the script is a public class)      
 
		//scriptToAccess.SetPopUpText("");
	}
}
