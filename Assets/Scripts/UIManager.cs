using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button shareButton;
    [SerializeField] private Button watchAdButton;

    private void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        shareButton.onClick.AddListener(ShareScore);
        watchAdButton.onClick.AddListener(WatchRewardedAd);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Your Score: " + GameManager.Instance.GetScore();
        
        // Show interstitial ad when game is over
        GameManager.Instance.RequestInterstitialAd();
    }

    private void PlayAgain()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ShareScore()
    {
        string message = "I scored " + GameManager.Instance.GetScore() + " points in this awesome game! Can you beat my score?";
        
        #if UNITY_ANDROID
            AndroidNative.SendShareIntent(message, "Share Score");
        #endif
    }

    private void WatchRewardedAd()
    {
        GameManager.Instance.RequestRewardedAd(() =>
        {
            GameManager.Instance.AddScore(50); // Bonus points for watching ad
            finalScoreText.text = "Your Score: " + GameManager.Instance.GetScore();
        });
    }
}
