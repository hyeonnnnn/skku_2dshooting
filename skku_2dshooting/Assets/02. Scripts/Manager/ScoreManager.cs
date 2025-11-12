using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _currentScoreTextUI;
    [SerializeField] private Text _bestScoreTextUI;
    private int _currentScore = 0;
    private int _bestScore = 0;
    private const string BestScoreKey = "BestScoreKey";

    public int CurrentScore => _currentScore;

    private void Start()
    {
        LoadBestScore();
        UpdateCurrentScore();
        UpdateBestScore();
    }

    public void AddScore(int score)
    {
        if (score <= 0) return;

        _currentScore += score;

        UpdateCurrentScore();
        UpdateBestScore();
    }

    private void LoadBestScore()
    {
        _bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    private void UpdateCurrentScore()
    {
        _currentScoreTextUI.text = $"현재 점수: {_currentScore:N0}";
    }

    private void UpdateBestScore()
    {
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
        }

        _bestScoreTextUI.text = $"최고 점수: {_bestScore:N0}";
    }

    public void TrySaveBestScore()
    {
        if (_currentScore < _bestScore) return;

        SaveBestScore();
    }

    private void SaveBestScore()
    {
        PlayerPrefs.SetInt(BestScoreKey, _currentScore);
    }
}
