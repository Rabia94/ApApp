using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "General/SceneManager")]
public class ScriptableSceneManager : ScriptableObject
{
    public void OpenQuestionScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OpenQuestionScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

