
using System;
using UnityEngine;

public class SwipeBall : MonoBehaviour
{
    [SerializeField] private int collideCount;
    private Vector2 startPos; // Vector2 start touch screen
    private Vector2 endPos; // Vector2 stop touch screen
    private Rigidbody2D _rgbd2d;
    private Camera cam;
    private bool isSwiped;

    
    

    public int powerForce;
    public static event Action<int> OnBallHitWall; 
    private void Start()
    {
        isSwiped = false;
        cam = Camera.main;
        _rgbd2d = GetComponent<Rigidbody2D>();
        OnBallHitWall?.Invoke(collideCount);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        //CollideCount minus one
        collideCount--;
        OnBallHitWall?.Invoke(collideCount);
        if (collideCount < 0)
        {
            //Game Lose
            Debug.Log("Game Lose");
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collideCount==0)
        {
            //Game Won
            Debug.Log("Game Won");
            Time.timeScale = 0;
        }
        else
        {
            //Game Lose
            Debug.Log("Game Lose");
            Time.timeScale = 0;
        }
    }
}
