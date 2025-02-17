using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
            SceneLoader.Instance.LoadSceneAfterDelay("DeathScene", 1f);
        }
    }
}
