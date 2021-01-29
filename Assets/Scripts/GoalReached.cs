using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalReached : MonoBehaviour
{
    [SerializeField] private Text customText;
    [SerializeField] private GameObject buttonNextLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customText.enabled = true;
            buttonNextLevel.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customText.enabled = false;
            buttonNextLevel.SetActive(false);
        }
    }
}
