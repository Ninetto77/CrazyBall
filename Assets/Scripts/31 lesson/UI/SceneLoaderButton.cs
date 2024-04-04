using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoaderButton : LevelManager
{
    public SceneTypes SceneType;
    public string SceneName;
    
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick?.AddListener(OnClick);
    }

    private void OnClick()
    {
        switch (SceneType)
        {
            case SceneTypes.LoadNewScene:
                if (SceneName != null && SceneName != "")
                    LoadChosedScence(SceneName);
                else
                    Debug.LogError("No scene selected in the button : " + gameObject.name);
                break;
            case SceneTypes.ReloadThisScene:
                ReloadScene();
                break;
        }
    }

}

public enum SceneTypes
{
    LoadNewScene,
    ReloadThisScene
}
