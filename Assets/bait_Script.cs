using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bait_Script : MonoBehaviour
{

    // `Rigidbody2D` obiektu
    private Rigidbody2D rb;

    // Odległość obiektu od punktu (0,0) w momencie przekroczenia linii Y = 0
    private float initialDistanceFromOrigin;
    public CircleeMovement rod;
    // Flaga określająca, czy obiekt przeszedł poniżej linii Y = 0
    private bool isBelowZeroY = false;
    public float movementSpeed = 1f;
    void Start()
    {
        // Pobierz `Rigidbody2D` obiektu
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Sprawdź, czy obiekt znajduje się poniżej linii Y = 0
        if (transform.position.y < rod.center.y - 1.0f)
        {
            // Jeśli obiekt nie został wcześniej wykryty jako poniżej linii Y = 0
            if (!isBelowZeroY)
            {
                // Zapisz początkową odległość od punktu (0,0)
                initialDistanceFromOrigin = Vector2.Distance(transform.position, rod.center);

                // Wyłącz `Rigidbody2D`
                rb.gravityScale = 0;

                // Ustaw flagę
                isBelowZeroY = true;
            }
            if (Vector3.Distance(transform.position, rod.center) <= 0.1f)
            {
                  
                      rb.simulated = true;
                      isBelowZeroY = false;
                 
            
            }
            if (Vector2.Distance(transform.position, rod.center) < initialDistanceFromOrigin+5 && isBelowZeroY)
            {
                // Opadaj obiekt z prędkością 0,1 na sekundę
                transform.position += Vector3.down * 0.5f * Time.deltaTime;
            }
            
        }
      
       
        if (Input.GetKey(KeyCode.Space))
        {
       
            Vector2 directionToOrigin = (rod.center- (Vector2)transform.position).normalized;
            
            
            transform.position += (Vector3)directionToOrigin * movementSpeed * Time.deltaTime;
        }
    }

   
}

