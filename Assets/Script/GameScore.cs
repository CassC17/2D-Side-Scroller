using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    public static GameScore Instance;

    public int score = 0;
    public TMP_Text scoreText; private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // C'est ici que tu rends l'objet persistant
        }
        else
        {
            Destroy(gameObject); // Si une autre instance existe déjà, on détruit celle-ci
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score.ToString();
        }
    }

    public int GetScore()
    {
        return score;
    }
}
