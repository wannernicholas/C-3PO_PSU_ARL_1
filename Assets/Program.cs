using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    public GameObject holder;
    protected bool active;

   public void SetActive(bool active)
    {
        this.active = active;
        holder.SetActive(active);
    }

    public bool GetActive()
    {
        return active;
    }
}
