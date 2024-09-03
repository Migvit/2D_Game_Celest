using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    private PlayerController playerController;
    private int direction = 1;
    public float speed = 1f;



    private void OnDrawGizmos()
    {
        if (platform != null && startPoint !=null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 target = currentMovementTarget();

        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime); 

        float distance =(target - (Vector2)platform.position).magnitude;

        if (distance < 0.1f)
        {
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else 
        {
            return endPoint.position;

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
        }
        
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
