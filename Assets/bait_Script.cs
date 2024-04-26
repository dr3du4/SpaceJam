using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bait_Script : MonoBehaviour
{

    // `Rigidbody2D` obiektu
    private Rigidbody2D rb;

    // Odległość obiektu od punktu (0,0) w momencie przekroczenia linii Y = 0
    private float initialDistanceFromOrigin;

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
        if (transform.position.y < 0)
        {
            // Jeśli obiekt nie został wcześniej wykryty jako poniżej linii Y = 0
            if (!isBelowZeroY)
            {
                // Zapisz początkową odległość od punktu (0,0)
                initialDistanceFromOrigin = Vector2.Distance(transform.position, Vector2.zero);

                // Wyłącz `Rigidbody2D`
                rb.simulated = false;

                // Ustaw flagę
                isBelowZeroY = true;
            }

            if (Vector2.Distance(transform.position, Vector2.zero) < initialDistanceFromOrigin+5)
            {
                // Opadaj obiekt z prędkością 0,1 na sekundę
                transform.position += Vector3.down * 0.5f * Time.deltaTime;
            }
            // Ogranicz odległość od punktu (0,0)
           //LimitDistanceFromOrigin();
        }
      
       
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // Oblicz kierunek ruchu obiektu w kierunku punktu (0,0)
            Vector2 directionToOrigin = (Vector2.zero - (Vector2)transform.position).normalized;
            
            // Porusz obiekt w kierunku punktu (0,0) z ustawioną prędkością
            transform.position += (Vector3)directionToOrigin * movementSpeed * Time.deltaTime;
        }
    }

    // Funkcja do ograniczenia odległości obiektu od punktu (0,0)
    void LimitDistanceFromOrigin()
    {
        // Oblicz odległość od punktu (0,0)
        float currentDistanceFromOrigin = Vector2.Distance(transform.position, Vector2.zero);

        // Jeśli aktualna odległość jest większa niż początkowa
        if (currentDistanceFromOrigin > initialDistanceFromOrigin)
        {
            // Znajdź kierunek od punktu (0,0) do obiektu
            Vector2 directionToOrigin = (Vector2.zero - (Vector2)transform.position).normalized;

            // Przesuń obiekt, aby znajdował się na maksymalnej odległości
            transform.position = (Vector2.zero + directionToOrigin * initialDistanceFromOrigin);
        }
    }
}

