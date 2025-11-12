using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _currentScoreTextUI;
    [SerializeField] private Text _bestScoreTextUI;
    private int _currentScore = 0;
    private int _bestScore = 0;
    private const string BestScoreKey = "BestScoreKey";

    private float _textEffectScale = 1.5f;
    private float _textEffectDuration = 0.5f;

    public int CurrentScore => _currentScore;

    private void Start()
    {
        LoadBestScore();
        UpdateCurrentScoreUI();
        UpdateBestScore();
    }

    public void AddScore(int score)
    {
        if (score <= 0) return;

        _currentScore += score;

        UpdateCurrentScoreUI();
        UpdateBestScore();
    }

    private void LoadBestScore()
    {
        _bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    private void UpdateCurrentScoreUI()
    {
        _currentScoreTextUI.text = $"현재 점수: {_currentScore:N0}";
        TextEffect(_currentScoreTextUI);
    }

    private void UpdateBestScore()
    {
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
        }
        UpdateBestScoreUI();
    }

    private void UpdateBestScoreUI()
    {
        _bestScoreTextUI.text = $"최고 점수: {_bestScore:N0}";
        TextEffect(_bestScoreTextUI);
    }

    public void SaveBestScore()
    {
        PlayerPrefs.SetInt(BestScoreKey, _bestScore);
    }

    private void TextEffect(Text text)
    {
        text.transform.DOKill();

        text.transform.DOScale(_textEffectScale, _textEffectDuration).OnComplete(() =>
        {
            if(text == null) return;

            text.transform.DOScale(1f, 1f);
        });
    }
}
