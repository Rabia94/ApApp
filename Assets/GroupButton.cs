using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GroupButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private int _index;
    private int _nextSceneIndex;
    
    public void SetButton(int index, int result, int nextSceneIndex)
    {
        _text.SetText($"Bölüm {index}   %{result}");
        _index = index;
        _nextSceneIndex = nextSceneIndex;
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        QuestionSettings.GroupIndex = _index;
        SceneManager.LoadScene(_nextSceneIndex);
    }

}