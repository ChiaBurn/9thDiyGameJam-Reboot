using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneEnum
{
    MainMenu_Scene = 0,
    Chap_01_Scene = 1,
    Chap_02_Scene = 2,
    Chap_03_Scene = 3,
    Chap_04_Scene = 4,
    Plot_Scene = 5
}

public enum LevelStatusEnum
{
    Begin,
    Successed,
    Failed
}

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager Instance { get; private set; }
    public int finishedLevelCount = 0;
    public int currentChapter = 0;
    public int currentLevel = 0;

    [SerializeField]
    public LevelStatusEnum currentLevelStatus = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TransitScene(SceneEnum sceneEnum)
    {
        SceneManager.LoadScene(sceneEnum.ToString());
    }

}
