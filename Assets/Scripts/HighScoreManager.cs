using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;
      [SerializeField] private TextMeshProUGUI highScoreText;

    private int highScore = 0;

    void Start()
    {
        // Lấy điểm cao nhất đã lưu
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    void Update()
    {
       
        UpdateUI();
    }

    void UpdateUI()
    {
        int currentDistance = MasterInfor.distanceRun;

        // Cập nhật điểm cao nếu người chơi đạt cao hơn
        if (currentDistance > highScore)
        {
            highScore = currentDistance;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        // Hiển thị text
        distanceText.text = $"DISTANCE: {currentDistance} M";
        highScoreText.text = $"HIGH SCORE: {highScore} M";
    }

    // Nếu cần reset khi chơi lại
    public void ResetDistance()
    {
        MasterInfor.distanceRun = 0;
        UpdateUI();
    }
    public void OnPlayAgain()
    {
        // Reset điểm hiện tại về 0
        MasterInfor.distanceRun = 0;

        // Nạp lại scene hiện tại (chơi lại)
        SceneManager.LoadScene(0);
    }
}
