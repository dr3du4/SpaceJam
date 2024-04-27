using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleeMovement : MonoBehaviour
{


    public float radius = 5.0f;
    public float startAngle = 170f;
    public float endAngle = 10f;


    public float angularSpeed = 45f;
    private float currentAngle;
    public FollowAndLaunch fl;

    public GameObject center;
    public Transform objectToFollow;


    private bool isSpacePressed = false;

    void Start()
    {

        currentAngle = startAngle;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpacePressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpacePressed = false;
        }

        if (fl.isFollowing == true)
        {
            if (isSpacePressed)
            {

                currentAngle -= angularSpeed * Time.deltaTime;

                if (currentAngle < endAngle)
                {
                    currentAngle = startAngle;
                }
                else if (currentAngle > startAngle)
                {
                    currentAngle = endAngle;
                }


                float x = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;
                float y = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;


                Vector2 endPosition = new Vector2(x, y) + (Vector2)center.transform.position;
                Vector2 direction = endPosition - (Vector2)center.transform.position;

                transform.position = endPosition - direction;


                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);

                if (objectToFollow != null)
                {
                    objectToFollow.position = endPosition;

                }
            }
        }
    }
}

