using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text FinishedLevelConutText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }


    public void GoChap02()
    {
        PersistentManager.Instance.TransitScene(SceneEnum.Chap_02_Scene);
    }


    public void GoPlot()
    {
        PersistentManager.Instance.TransitScene(SceneEnum.Plot_Scene);
    }
}
