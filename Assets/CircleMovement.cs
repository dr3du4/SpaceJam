using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleeMovement : MonoBehaviour
{

   // Promień okręgu, po którym ma poruszać się obiekt
    public float radius = 5.0f;
    
    // Początkowy kąt (w stopniach) i końcowy kąt (w stopniach)
    public float startAngle = 170f;
    public float endAngle = 10f;
    
    // Prędkość kątowa w stopniach na sekundę (odwrócona, aby poruszać się w drugą stronę)
    public float angularSpeed = 45f;
    
    // Aktualny kąt obiektu
    private float currentAngle;
    
    // Środek okręgu
    public Vector2 center = Vector2.zero;
  
    // Obiekt 2D, który ma śledzić obiekt
    public Transform objectToFollow;
    
    // Flaga śledząca, czy spacja jest wciśnięta
    private bool isSpacePressed = false;

    void Start()
    {
        // Ustaw początkowy kąt obiektu
        currentAngle = startAngle;
    }
    
    void Update()
    {
        // Sprawdź, czy spacja jest wciśnięta
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpacePressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpacePressed = false;
        }

        // Jeśli spacja jest przytrzymywana, poruszaj obiektem
        if (isSpacePressed)
        {
            // Oblicz nową wartość kąta w oparciu o prędkość kątową
            currentAngle -= angularSpeed * Time.deltaTime;
            
            // Upewnij się, że kąt jest w zakresie od `startAngle` do `endAngle`
            if (currentAngle < endAngle)
            {
                currentAngle = startAngle;
            }
            else if (currentAngle > startAngle)
            {
                currentAngle = endAngle;
            }

            // Oblicz nowe współrzędne dla końca prostokąta
            float x = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;
            float y = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;
            
            // Ustaw położenie obiektu
            Vector2 endPosition = new Vector2(x, y) + center;
            Vector2 direction = endPosition - center;
            
            transform.position = endPosition - direction;
            
            // Ustaw obrót prostokąta tak, aby był skierowany w kierunku środka
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            
            // Ustaw położenie `objectToFollow`
            if (objectToFollow != null)
            {
                objectToFollow.position = endPosition;
            }
        }
    }
}
