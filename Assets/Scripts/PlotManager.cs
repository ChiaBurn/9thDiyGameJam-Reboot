using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{
    [Header("Dialogue settings")]
    public Text dialogueText;
    float secondsBetweenChar = 0.05f;

    [Header("Image object settings")]
    public Image robot;
    public Image emoji;

    [Header("Image settings")]
    public Sprite sweatEmoji;
    public Sprite blingEmoji;

    [Header("Chap 01 Robot")]
    public Sprite robot_01_01_good;
    public Sprite robot_01_01_bad;
    public Sprite robot_01_02_good;
    public Sprite robot_01_02_bad;
    public Sprite robot_01_03_good;
    public Sprite robot_01_03_bad;

    [Header("Chap 02 Robot")]
    public Sprite robot_02_01_good;
    public Sprite robot_02_01_bad;
    public Sprite robot_02_02_good;
    public Sprite robot_02_02_bad;
    public Sprite robot_02_03_good;
    public Sprite robot_02_03_bad;




    private Queue<string> sentencesToShow;

    void Start()
    {
        sentencesToShow = new Queue<string>();
        var chap = PersistentManager.Instance.currentChapter;
        var level = PersistentManager.Instance.currentLevel;
        var status = PersistentManager.Instance.currentLevelStatus;


        SetImageByGameStatus(chap, level, status);
        StartDialogue(chap, level, status);
    }

    private void SetImageByGameStatus(int chap, int level, LevelStatusEnum status)
    {

        #region Robots Setting
        var RobotSpriteDictionary = new Dictionary<string, Sprite>()
        {
            #region Chap1_1
            { $"1_1_{nameof(LevelStatusEnum.Begin)}", robot_01_01_bad },
            { $"1_1_{nameof(LevelStatusEnum.Failed)}", robot_01_01_bad },
            { $"1_1_{nameof(LevelStatusEnum.Successed)}", robot_01_01_good },
            #endregion Chap1_1
            #region Chap1_2
            { $"1_2_{nameof(LevelStatusEnum.Begin)}", robot_01_02_bad },
            { $"1_2_{nameof(LevelStatusEnum.Failed)}", robot_01_02_bad },
            { $"1_2_{nameof(LevelStatusEnum.Successed)}", robot_01_02_good },
            #endregion Chap1_2
            #region Chap1_3
            { $"1_3_{nameof(LevelStatusEnum.Begin)}", robot_01_03_bad },
            { $"1_3_{nameof(LevelStatusEnum.Failed)}", robot_01_03_bad },
            { $"1_3_{nameof(LevelStatusEnum.Successed)}", robot_01_03_good },
            #endregion Chap1_3

            #region Chap2_1
            { $"2_1_{nameof(LevelStatusEnum.Begin)}", robot_02_01_bad },
            { $"2_1_{nameof(LevelStatusEnum.Failed)}", robot_02_01_bad },
            { $"2_1_{nameof(LevelStatusEnum.Successed)}", robot_02_01_good },
            #endregion Chap2_1
            #region Chap2_2
            { $"2_2_{nameof(LevelStatusEnum.Begin)}", robot_02_02_bad },
            { $"2_2_{nameof(LevelStatusEnum.Failed)}", robot_02_02_bad },
            { $"2_2_{nameof(LevelStatusEnum.Successed)}", robot_02_02_good },
            #endregion Chap2_2
            #region Chap2_3
            { $"2_3_{nameof(LevelStatusEnum.Begin)}", robot_02_03_bad },
            { $"2_3_{nameof(LevelStatusEnum.Failed)}", robot_02_03_bad },
            { $"2_3_{nameof(LevelStatusEnum.Successed)}", robot_02_03_good },
            #endregion Chap2_3

        };
        #endregion

        switch (status)
        {
            case LevelStatusEnum.Successed:
                emoji.sprite = blingEmoji;
                break;

            case LevelStatusEnum.Begin:
            case LevelStatusEnum.Failed:
            default:
                emoji.sprite = sweatEmoji;
                break;
        }

        robot.sprite = RobotSpriteDictionary[$"{chap}_{level}_{status}"];
    }

    private void StartDialogue(int chap, int level, LevelStatusEnum status)
    {        
        
        #region Dialogues Setting
        var dialogueDictionary_TW = new Dictionary<string, string[]>
        {
            #region Chap1_1
            {
                $"1_1_{nameof(LevelStatusEnum.Begin)}",
                new string[]
                {
                    "第1章節，第1關，關卡開始。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"1_1_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "第1章節，第1關，關卡失敗。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"1_1_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "第1章節，第1關，關卡成功。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            #endregion Chap1_1
            #region Chap1_2
            {
                $"1_2_{nameof(LevelStatusEnum.Begin)}",
                new string[]
                {
                    "第1章節，第2關，關卡開始。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"1_2_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "第1章節，第2關，關卡失敗。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"1_2_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "第1章節，第2關，關卡成功。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            #endregion Chap1_2
            #region Chap1_3
            {
                $"1_3_{nameof(LevelStatusEnum.Begin)}",
                new string[]
                {
                    "第1章節，第3關，關卡開始。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"1_3_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "第1章節，第3關，關卡失敗。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"1_3_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "第1章節，第3關，關卡成功。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            #endregion Chap1_3
           
            #region Chap2_1
            {
                $"2_1_{nameof(LevelStatusEnum.Begin)}",
                new string[]
                {
                    "第2章節，第1關，關卡開始。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"2_1_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "第2章節，第1關，關卡失敗。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"2_1_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "第2章節，第1關，關卡成功。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            #endregion Chap2_1
            #region Chap2_2
            {
                $"2_2_{nameof(LevelStatusEnum.Begin)}",
                new string[]
                {
                    "第1章節，第2關，關卡開始。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"2_2_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "第2章節，第2關，關卡失敗。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"2_2_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "第2章節，第2關，關卡成功。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            #endregion Chap2_2
            #region Chap2_3
            {
                $"2_3_{nameof(LevelStatusEnum.Begin)}",
                new string[]
                {
                    "第1章節，第3關，關卡開始。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"2_3_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "第2章節，第3關，關卡失敗。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            {
                $"2_3_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "第2章節，第3關，關卡成功。",
                    "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
                    "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
                    "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
                }
            },
            #endregion Chap2_3
        };

        #endregion

        var sentences = dialogueDictionary_TW[$"{chap}_{level}_{status}"];
      
        sentencesToShow.Clear();
        foreach (var sentence in sentences)
        {
            sentencesToShow.Enqueue(sentence);
        }

        ShowNextSentence();
    }

    public void ShowNextSentence()
    {
        if (!sentencesToShow.Any())
        {
            EndDialogue();
            return;
        }

        var sentenceIsShowing = sentencesToShow.Dequeue();
        StopCoroutine(nameof(TypeSentence));
        StartCoroutine(nameof(TypeSentence), sentenceIsShowing);
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (var c in sentence.ToCharArray())
        {
            yield return new WaitForSeconds(secondsBetweenChar);
            dialogueText.text += c;
        }
    }

    private void EndDialogue()
    {
        Debug.Log("End Dialogue");
    }

    public void GoMainMenu()
    {
        PersistentManager.Instance.TransitScene(SceneEnum.MainMenu_Scene);
    }

}
