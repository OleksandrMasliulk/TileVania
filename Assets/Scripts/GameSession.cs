using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance {get; private set;}
    private static int FIRST_LEVEL = 0;

    [SerializeField] private int _playerLives;
    private int _score;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _livesText;

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    private void Start() 
    {
        UpdateLivesText();
        UpdateScoreText();
    }

    public void ProcessPlayerDeath() 
    {
        if (_playerLives > 1)
        {
            _playerLives--;
            UpdateLivesText();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
            ResetGameSession();
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(FIRST_LEVEL);
        Destroy(this.gameObject);
    }

    public void AddScore(int score)
    {
        _score += score;
        UpdateScoreText();
    }

    private void UpdateLivesText()
    {
        _livesText.text = _playerLives.ToString();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = _score.ToString();
    }
}
