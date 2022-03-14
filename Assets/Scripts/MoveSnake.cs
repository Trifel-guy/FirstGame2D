using UnityEngine;

public class MoveSnake : MonoBehaviour
{
    public float speedMove;
    public Transform[] listWayPoints;
    public SpriteRenderer snakeGraphics;
    private Transform target;
    private int endPoint = 0;
    public int damage = 20;

    void Start()
    {
        target = listWayPoints[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speedMove * Time.deltaTime, Space.World);

        //if snake is near of endPoint
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            endPoint = (endPoint + 1) % listWayPoints.Length;
            target = listWayPoints[endPoint];
            snakeGraphics.flipX = !snakeGraphics.flipX;
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
    }
}
