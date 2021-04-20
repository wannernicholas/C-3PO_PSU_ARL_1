using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sliding : MonoBehaviour
{
    public Vector3 pointB;
    public float rate;
    IEnumerator Start()
    {
        Vector3 pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        rate = rate / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}