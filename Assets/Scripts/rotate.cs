using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public string axisToRotate;
    public float speed;
 
    // Update is called once per frame
    void Update()
    {
        if (axisToRotate.Equals("X")){
        	transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        else if(axisToRotate.Equals("Y")){
        	transform.Rotate(Vector3.right * speed * Time.deltaTime);
        }
        else{
        	transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
