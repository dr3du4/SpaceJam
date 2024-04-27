using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField]
    AttractionParams AttractionParams;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected!");
        if(collision.CompareTag("Fish"))
        {
            Debug.Log("Right target found!");
            collision.GetComponent<FishBase>().TryAttract(AttractionParams, transform);
        }
    }
}
