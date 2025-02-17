using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public TMP_Text finalScoreText;

    private void Start()
    {
        if (GameScore.Instance != null)
        {
            finalScoreText.text = GameScore.Instance.GetScore().ToString();
        }
    }
}
