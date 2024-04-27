using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class FollowAndLaunch : MonoBehaviour
{
  
    public Transform target;
   

    private Rigidbody2D rb;
    private bait_Script bs;
    public CircleeMovement rod;
    
    public float launchForce = 500f;
    
    public bool isFollowing = true;
    public bool readyToCast = true;
    public GameObject mainCamera;
    public GameObject followingCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bs = GetComponentInChildren<bait_Script>();
    }

    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Space) && isFollowing && readyToCast)
        {
            LaunchObject();
            isFollowing = false;
            readyToCast = false;
            
        }
     
        if (isFollowing)
        {
            rb.gravityScale = 1f;
            FollowTarget();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isFollowing == false)
        {
            isFollowing = true;
            mainCamera.SetActive(true);
            followingCamera.SetActive(false);
            bs.rb.gravityScale = 1f;
            bs.isBelowZeroY = false;
        }
    }

    void FollowTarget()
    {
        if (target != null)
        {
            transform.position = target.position;
        }
    }

 
    void LaunchObject()
    {
       
        
        Vector2 launchDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * 45), Mathf.Sin(Mathf.Deg2Rad * 45));

        rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);

        mainCamera.SetActive(false);
        followingCamera.SetActive(true);
    }
}
