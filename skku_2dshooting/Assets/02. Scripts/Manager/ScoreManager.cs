using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _currentScoreTextUI;
    private int _currentScore = 0;
    private const string ScoreKey = "ScoreKey";

    public int CurrentScore => _currentScore;

    private void Start()
    {
        LoadScore();
        Refresh();
    }

    public void AddScore(int score)
    {
        if (score <= 0) return;

        _currentScore += score;

        Refresh();
        SaveScore();
    }

    private void Refresh()
    {
        _currentScoreTextUI.text = $"현재 점수: {_currentScore:N0}";
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
        PlayerPrefs.SetInt(ScoreKey, _currentScore);
    }

    private void LoadScore()
    {
        _currentScore = PlayerPrefs.GetInt(ScoreKey, 0);

        Debug.Log($"score: {_currentScore}");
    }
}
