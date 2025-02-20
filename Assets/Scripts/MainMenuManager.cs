using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text FinishedLevelConutText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FinishedLevelConutText.text = $"Finished Level: {PersistentManager.Instance.finishedLevelCount}";
    }


    public void GoChap02()
    {
        SceneManager.LoadScene("Chap_02_Scene");
    }
}
