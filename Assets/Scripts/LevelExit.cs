using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private int _nextLevelIndex;
    [SerializeField] private float _loadDelay;

    private void LoadNextLevel()
    {
        if (_nextLevelIndex > SceneManager.sceneCountInBuildSettings || _nextLevelIndex < 0)
            throw new System.Exception($"Tried to load scene with {_nextLevelIndex} build index, which does not exist in this project!");

        StartCoroutine(LoadLevelCoroutine());
    }

    IEnumerator LoadLevelCoroutine()
    {
        yield return new WaitForSeconds(_loadDelay);

        SceneManager.LoadScene(_nextLevelIndex);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
            LoadNextLevel();
    }
}
