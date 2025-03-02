using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneEnum
{
    MainMenu_Scene = 0,
    Chap_01_Scene = 1,
    Chap_02_Scene = 2,
    Chap_03_Scene = 3,
    Chap_04_Scene = 4,
    Plot_Scene = 5,
    Result_Scene = 6
}

public enum LevelStatusEnum
{
    Begin,
    Successed,
    Failed
}

public class PersistentManager : MonoBehaviour
{
    [SerializeField] public Animator transitionAnim;
    public bool isDebugMode = false;
    public static PersistentManager Instance { get; private set; }
    public int currentChapter = 1;
    public int currentLevel = 1;
    public LevelStatusEnum currentLevelStatus = LevelStatusEnum.Begin;
    public int currentChapterScore = 0;

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

    public void GoNext()
    {
        Enum.TryParse(SceneManager.GetActiveScene().name, out SceneEnum currentScene);
        Debug.Log("GoNext");

        switch (currentScene)
        {
            case SceneEnum.MainMenu_Scene:
                Debug.Log("case SceneEnum.MainMenu_Scene");
                SetChapInitialStatus(1);
                Go(SceneEnum.Plot_Scene);
                break;

            case SceneEnum.Chap_01_Scene:
            case SceneEnum.Chap_02_Scene:
                Debug.Log("case Chap_01_Scene or Chap_02_Scene");
                Go(SceneEnum.Plot_Scene);
                break;

            case SceneEnum.Plot_Scene:
                Debug.Log("case SceneEnum.Plot_Scene");
                if (currentLevelStatus.Equals(LevelStatusEnum.Begin))
                {
                    Go(currentChapter switch
                    {
                        1 => SceneEnum.Chap_01_Scene,
                        2 => SceneEnum.Chap_02_Scene,
                        _ => SceneEnum.MainMenu_Scene
                    });
                }
                else
                {
                    if (currentLevel == 3)
                    {
                        Go(SceneEnum.Result_Scene);
                    }
                    else
                    {
                        UpgradeChapAndLevel();
                        // Test
                        Go(SceneEnum.Plot_Scene);
                    }

                }

                break;

            case SceneEnum.Result_Scene:
                Debug.Log("case SceneEnum.Result_Scene");
                var isGameOver = currentChapter == 2 || currentChapterScore == 0;
                currentChapterScore = 0;

                if (isGameOver)
                {
                    Go(SceneEnum.MainMenu_Scene);
                }
                else
                {
                    var nextChap = currentChapter + 1;
                    SetChapInitialStatus(nextChap);
                    Go(SceneEnum.Plot_Scene);
                }
                break;
        }
    }

    private void SetChapInitialStatus(int chap)
    {

        Debug.Log($"SetChapInitialStatus({chap})");
        currentChapter = chap;
        currentLevel = 1;
        currentLevelStatus = LevelStatusEnum.Begin;
        currentChapterScore = 0;
    }

    private void UpgradeChapAndLevel()
    {
        Debug.Log($"UpgradeChapAndLevel()");
        currentLevelStatus = LevelStatusEnum.Begin;
        if (currentLevel == 3)
        {
            currentChapter = currentChapter switch
            {
                1 => 2,
                2 => 1,
                _ => 1
            };
        }
        currentLevel = currentLevel switch
        {
            1 => 2,
            2 => 3,
            3 => 1,
            _ => 1
        };
    }


    public void Go(SceneEnum sceneEnum)
    {
        StartCoroutine(TransitScene(sceneEnum.ToString()));
    }

    public IEnumerator TransitScene(string sceneName)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
        transitionAnim.SetTrigger("Start");
    }

}
