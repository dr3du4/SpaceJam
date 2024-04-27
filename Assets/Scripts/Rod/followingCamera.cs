using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingCamera : MonoBehaviour
{
  
    public Transform target;
    public float distanceZ = -10f;
    public float heightY = 5f;

    public float followSpeed = 5f;

    void LateUpdate()
    {
     
        if (target != null)
        {
            Vector3 targetPosition = target.position + new Vector3(0, heightY, distanceZ);
            transform.position = targetPosition;
        }
    }
}