using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bait_Script : MonoBehaviour
{


    public Rigidbody2D rb;
    public float initialDistanceFromOrigin;
    public CircleeMovement rod;
    public bool isBelowZeroY = false;

    [SerializeField] private FollowAndLaunch fl;
    public float drowing = 1f;
    public float movementSpeed = 1f;
    public float lineOffset;
    public float offsetCoast;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fl = GetComponent<FollowAndLaunch>();

        StartCoroutine(KurwaPorazkaZyciowa());
    }

    IEnumerator KurwaPorazkaZyciowa()
    {
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        rb.gravityScale = 1f;
    }

    void Update()
    {
           
            if (!isBelowZeroY)
            {
                initialDistanceFromOrigin = Vector2.Distance(transform.position, rod.center.transform.position );
            }
            if(isBelowZeroY&& !fl.isFollowing)
            {
              
                //rb.gravityScale = 0;
                //isBelowZeroY = true; 
                if (Input.GetKey(KeyCode.Space))
                {
                    Vector2 directionToOrigin = (rod.center.transform.position  - transform.position).normalized;
                    transform.position += (Vector3)directionToOrigin * movementSpeed * Time.deltaTime;
                }
            }
            
            
            if (Vector2.Distance(transform.position, rod.center.transform.position ) < initialDistanceFromOrigin+lineOffset && isBelowZeroY)
            {
                transform.position += Vector3.down * drowing * Time.deltaTime;
            }
            if (Vector2.Distance(transform.position, rod.center.transform.position ) >= initialDistanceFromOrigin+lineOffset && isBelowZeroY && transform.position.x > rod.center.transform.position.x+1)
            {
                transform.position += Vector3.left * drowing * Time.deltaTime;
            }
           
            
        
      
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            isBelowZeroY = true;
            rb.gravityScale = 0;
        }
    }
}

