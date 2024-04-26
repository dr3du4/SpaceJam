using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingCamera : MonoBehaviour
{
    // Obiekt, który ma być śledzony przez kamerę
    public Transform target;

    // Odległość kamery od celu w osi Z
    public float distanceZ = -10f;

    // Wysokość kamery nad obiektem w osi Y
    public float heightY = 5f;

    // Wskaźnik czasu reagowania kamery
    public float followSpeed = 5f;

    void Update()
    {
        // Jeśli cel jest przypisany, śledź jego położenie
        if (target != null)
        {
            // Oblicz docelową pozycję kamery względem celu
            Vector3 targetPosition = target.position + new Vector3(0, heightY, distanceZ);
            
            // Płynnie zaktualizuj pozycję kamery do docelowej pozycji
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}