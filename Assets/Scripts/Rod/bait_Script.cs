using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bait_Script : MonoBehaviour
{


    private Rigidbody2D rb;
    public float initialDistanceFromOrigin;
    public CircleeMovement rod;
    private bool isBelowZeroY = false;

    private FollowAndLaunch fl;
    public float drowing;
    public float movementSpeed = 1f;
    public float lineOffset;
    public float offsetCoast;
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        fl = GetComponent<FollowAndLaunch>();

    }

    void Update()
    {
       
        if (transform.position.y < rod.center.y - offsetCoast)
        {
           
            if (!isBelowZeroY && !fl.isFollowing)
            {
                initialDistanceFromOrigin = Vector2.Distance(transform.position, rod.center);
                rb.gravityScale = 0;
                isBelowZeroY = true;
            }
            if (Vector3.Distance(transform.position, rod.center) <= 0.1f)
            {
                rb.gravityScale = 1f;
                isBelowZeroY = false;
            }
            
            
            if (Vector2.Distance(transform.position, rod.center) < initialDistanceFromOrigin+lineOffset && isBelowZeroY)
            {
                transform.position += Vector3.down * drowing * Time.deltaTime;
            }
            if (Vector2.Distance(transform.position, rod.center) >= initialDistanceFromOrigin+lineOffset && isBelowZeroY && transform.position.x > rod.center.x+1)
            {
                transform.position += Vector3.left * drowing * Time.deltaTime;
            }
           
            
        }
      
       
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 directionToOrigin = (rod.center- (Vector2)transform.position).normalized;
            transform.position += (Vector3)directionToOrigin * movementSpeed * Time.deltaTime;
        }
    }

   
}

