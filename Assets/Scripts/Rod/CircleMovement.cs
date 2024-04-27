using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleeMovement : MonoBehaviour
{


    public float radius = 5.0f;
    public float startAngle = 170f;
    public float endAngle = 10f;


    public float angularSpeed = 45f;
   public  float currentAngle;
    public FollowAndLaunch fl;

    public GameObject center;
    public Transform objectToFollow;


    void Start()
    {
        currentAngle = endAngle;

        updateRotation();
    }

    void updateRotation()
    {

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

    IEnumerator prepareCast()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        fl.readyToCast = true;
    }

    void FixedUpdate()
    {
        if (fl.isFollowing && !Input.GetButton("Jump"))
        {
            StartCoroutine(prepareCast());
        }
        if (fl.isFollowing == true && Input.GetButton("Jump") && fl.readyToCast == true)
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

            updateRotation();
            return;
        }
        currentAngle = 0;
        updateRotation();
    }
}

