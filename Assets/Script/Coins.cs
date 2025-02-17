using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameScore.Instance.AddScore(coinValue);
            Destroy(gameObject);
        }
    }
}


