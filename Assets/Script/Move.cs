using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed = 5f;
    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        if (transform.position.x < screenLeft - 2f)
        {
            Destroy(gameObject);
        }
    }
    public void StopMoving()
    {
        isMoving = false;
    }
} 
