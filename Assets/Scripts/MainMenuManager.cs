using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject debugModeCanvas;
    public Text modeText;
    public Text chapText;
    public Text levelText;
    public Text statusText;
    public Text scoreText;
    private PersistentManager manager;


    void Start()
    {
        manager = PersistentManager.Instance;
        modeText.text = $"isDebugMode: {manager.isDebugMode}";
        chapText.text = $"Chap: {manager.currentChapter}";
        levelText.text = $"Level: {manager.currentLevel}";
        statusText.text = $"Status: {manager.currentLevelStatus}";
        scoreText.text = $"Score: {manager.currentChapterScore}";
        debugModeCanvas.SetActive(manager.isDebugMode);
    }

    public void ChangeMode()
    {
        manager.isDebugMode = !manager.isDebugMode;
        debugModeCanvas.SetActive(manager.isDebugMode);
    }

    public void ChangeChap()
    {
        manager.currentChapter = manager.currentChapter switch
        {
            1 => 2,
            2 => 1,
            _ => 1
        };
        chapText.text = $"Chap: {manager.currentChapter}";
    }
    public void ChangeLevel()
    {
        manager.currentLevel = manager.currentLevel switch
        {
            1 => 2,
            2 => 3,
            3 => 1,
            _ => 1
        };
        levelText.text = $"Level: {manager.currentLevel}";
    }
    public void ChangeStatus()
    {
        manager.currentLevelStatus = manager.currentLevelStatus switch
        {
            LevelStatusEnum.Begin => LevelStatusEnum.Failed,
            LevelStatusEnum.Failed => LevelStatusEnum.Successed,
            LevelStatusEnum.Successed => LevelStatusEnum.Begin,
            _ => LevelStatusEnum.Begin
        };
        statusText.text = $"Status: {manager.currentLevelStatus}";
    }
    public void ChangeScore()
    {
        manager.currentChapterScore = manager.currentChapterScore switch
        {
            0 => 1,
            1 => 2,
            2 => 3,
            3 => 0,
            _ => 0
        };
        scoreText.text = $"Score: {manager.currentChapterScore}";
    }



    public void GoChap02()
    {
        PersistentManager.Instance.TransitScene(SceneEnum.Chap_02_Scene);
    }


    public void GoPlot()
    {
        PersistentManager.Instance.TransitScene(SceneEnum.Plot_Scene);
    }


    public void GoResult()
    {
        PersistentManager.Instance.TransitScene(SceneEnum.Result_Scene);
    }
}
