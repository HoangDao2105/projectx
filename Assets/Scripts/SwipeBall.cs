
using System;
using UnityEngine;

public class SwipeBall : MonoBehaviour
{
    private Vector2 startPos; // Vector2 start touch screen
    private Vector2 endPos; // Vector2 stop touch screen
    private Rigidbody2D _rgbd2d;
    private Camera cam;
    private bool isSwiped;


    public int powerForce;

    private void Start()
    {
        isSwiped = false;
        cam = Camera.main;
        _rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isSwiped) return;
        if (Input.GetMouseButtonDown(0))
        {
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 swipe = (endPos - startPos).normalized;
            Debug.LogFormat("Swipe: ({0}, {1})", swipe.x, swipe.y);
            isSwiped = true;
            // Add force to ball to make it move
            _rgbd2d.AddForce(swipe*powerForce);
        }
    }
}
