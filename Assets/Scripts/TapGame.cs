using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TapGame : MonoBehaviour
{
    [SerializeField] private Button tapButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private Image feedbackImage;
    [SerializeField] private float tapCooldown = 0.5f;
    
    private float lastTapTime = 0f;
    private int consecutiveTaps = 0;
    private Color originalColor;

    private void Start()
    {
        originalColor = feedbackImage.color;
        tapButton.onClick.AddListener(OnTap);
        UpdateUI();
    }

    private void OnTap()
    {
        if (Time.time - lastTapTime < tapCooldown)
            return;

        lastTapTime = Time.time;
        consecutiveTaps++;

        int points = 1;
        if (consecutiveTaps % 5 == 0) points = 5; // Bonus for every 5 consecutive taps

        GameManager.Instance.AddScore(points);
        TapFeedback();
        UpdateUI();
    }

    private void TapFeedback()
    {
        StartCoroutine(FlashFeedback());
    }

    private System.Collections.IEnumerator FlashFeedback()
    {
        feedbackImage.color = Color.yellow;
        yield return new WaitForSeconds(0.1f);
        feedbackImage.color = originalColor;
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetScore();
        highScoreText.text = "High Score: " + GameManager.Instance.GetHighScore();
        livesText.text = "Lives: " + GameManager.Instance.Lives;
    }
}
