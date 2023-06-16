
using System;
using UnityEngine;

public class SwipeBall : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private int collideCount;
    private Vector2 startPos; // Vector2 start touch screen
    private Vector2 endPos; // Vector2 stop touch screen
    private Rigidbody2D _rgbd2d;
    private Camera cam;
    private bool isSwiped;

    
    

    public int powerForce;
    public static event Action<int> OnBallHitWall; 
    public static event Action<int> OnLoadLevel; 
    private void Start()
    {
        isSwiped = false;
        cam = Camera.main;
        _rgbd2d = GetComponent<Rigidbody2D>();
        OnLoadLevel?.Invoke(collideCount);
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
        if (collideCount == 0)
        {
            //Game Lose
            Debug.Log("Game Lose");
            //Play particle system
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect,1f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collideCount==0)
        {
            //Game Won
            Debug.Log("Game Won");
            cam.backgroundColor = Color.black;
            LeanTween.cancel(cam.gameObject);
            LeanTween.moveX(cam.gameObject, -1.0f, 0.5f).setEasePunch();
            LeanTween.moveX(cam.gameObject, 1.0f, 0.5f).setEasePunch();
        }
        else
        {
            //Game Lose
            Debug.Log("Game Lose");
            //Play particle system
            GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(effect,1f);
            Destroy(gameObject);
        }
    }
}
