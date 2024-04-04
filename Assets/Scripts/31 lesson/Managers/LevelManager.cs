using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour
{
    public void ReloadScene()
    {
        LoadScence(GetActiveSceneName());
    }
    public void LoadChosedScence(string nameScane)
    {
        LoadScence(nameScane);
    }


    public string GetActiveSceneName() => SceneManager.GetActiveScene().name;

    public void LoadScence(string level) => SceneManager.LoadScene(level);

}
