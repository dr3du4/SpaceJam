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
    public CircleeMovement rod;
    
    public float launchForce = 500f;
    
    private bool isFollowing = true;
    public GameObject mainCamera;
    public GameObject followingCamera;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Space) && isFollowing)
        {
            LaunchObject();
            isFollowing = false;
            
        }

     
        if (isFollowing)
        {
            FollowTarget();
        }

        if (Vector3.Distance(transform.position,rod.center ) <= 0.1f)
        {
            isFollowing = true; 
            
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
       Debug.Log("DSDSDDSD");
        Vector2 launchDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * 45), Mathf.Sin(Mathf.Deg2Rad * 45));

        rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
     mainCamera.SetActive(false);
     followingCamera.SetActive(true);
    }
}
