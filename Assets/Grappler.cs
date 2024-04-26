using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public Camera mainCamera;

    public LineRenderer _LineRenderer;

    public DistanceJoint2D _DistanceJoint;
    public GameObject rodEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        _DistanceJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Dodac jako anchor koniec wędki
            Vector2 mousePos = (Vector2)rodEnd.transform.position;
            _LineRenderer.SetPosition(0,mousePos);
            _LineRenderer.SetPosition(1, transform.position);

            _DistanceJoint.connectedAnchor = mousePos;
            _DistanceJoint.enabled = true;
            _LineRenderer.enabled = true;

        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            _DistanceJoint.enabled = false;
            _LineRenderer.enabled = false;
        }

        if (_DistanceJoint.enabled)
        {
            _LineRenderer.SetPosition(1, transform.position);
        }
        
    }
}
