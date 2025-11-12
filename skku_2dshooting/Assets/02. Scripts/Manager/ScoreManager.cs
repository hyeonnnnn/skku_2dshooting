using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    [Header("UI 설정")]
    [SerializeField] private Text _currentScoreTextUI;
    [SerializeField] private Text _bestScoreTextUI;

    private int _currentScore = 0;
    private int _bestScore = 0;

    private float _textEffectScale = 1.5f;
    private float _textEffectDuration = 0.2f;
    private float _textEffectReturnDuration = 0.5f;

    private SaveManager _saveManager;

    public int CurrentScore => _currentScore;

    private void Start()
    {
        _saveManager = new SaveManager();

        InitScore();
    }

    public void AddScore(int score)
    {
        if (score <= 0) return;

        _currentScore += score;

        UpdateCurrentScoreUI();
        UpdateBestScore();
    }

    private void InitScore()
    {
        LoadBestScore();
        _currentScoreTextUI.text = $"현재 점수: {_currentScore:N0}";
        _bestScoreTextUI.text = $"최고 점수: {_bestScore:N0}";
    }

    private void LoadBestScore()
    {
        SaveData loaded = _saveManager.Load();

        if (loaded != null)
        {
            _bestScore = loaded.score;;
        }
        else
        {
            _bestScore = 0;
        }
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
            SaveBestScore();
            UpdateBestScoreUI();
        }
    }

    private void UpdateBestScoreUI()
    {
        _bestScoreTextUI.text = $"최고 점수: {_bestScore:N0}";
        TextEffect(_bestScoreTextUI);
    }

    public void SaveBestScore()
    {
        _saveManager.Save(_bestScore);
    }

    private void TextEffect(Text text)
    {
        if (text == null) return;

        text.transform.DOKill();

        text.transform.DOScale(_textEffectScale, _textEffectDuration).OnComplete(() =>
        {
            text.transform.DOScale(1f, _textEffectReturnDuration);
        });
    }
}
