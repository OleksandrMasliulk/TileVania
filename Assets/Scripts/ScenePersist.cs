using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    public static ScenePersist Instance {get; private set;}

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

    public void ResetScenePersist()
    {
        Destroy(this.gameObject);
    }
}
