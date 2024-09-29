using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    private Vector3 pointB = Vector3.left;
    public Transform targetTransform;
    public float reverseSpeed = 30f;
    IEnumerator Start()
    {
        pointB = targetTransform.position;
        Vector3 pointA = transform.position;
        while(true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, reverseSpeed));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, reverseSpeed));
        }
    }
    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0;
        float rate = 1f / time;
        while(i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
    // Start is called before the first frame update
  
}
