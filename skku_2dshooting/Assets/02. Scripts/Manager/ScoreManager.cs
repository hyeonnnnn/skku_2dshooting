using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _currentScoreTextUI;
    private int _currentScore = 0;

    public int CurrentScore => _currentScore;

    private void Start()
    {
        Refresh();
    }

    public void AddScore(int score)
    {
        if (score <= 0) return;

        _currentScore += score;
        Refresh();
    }

    private void Refresh()
    {
        string formattedScore = string.Format("{0:#,0}", _currentScore);
        _currentScoreTextUI.text = $"현재 점수: {formattedScore}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            LoadScore();
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", _currentScore);
    }

    private void LoadScore()
    {
        int score = 0;
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        }

        Debug.Log($"score: {score}");
    }
}
