using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance {get; private set;}
    private static int FIRST_LEVEL = 0;

    [SerializeField] private int _playerLives;

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

    public void ProcessPlayerDeath() 
    {
        if (_playerLives > 1)
        {
            _playerLives--;
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
}
