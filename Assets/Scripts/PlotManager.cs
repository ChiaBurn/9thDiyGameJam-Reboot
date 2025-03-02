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


    private PersistentManager manager;

    private Queue<string> sentencesToShow;
    private string currentSentence = string.Empty;
    private bool isTransiting = false;

    void Start()
    {
        manager = PersistentManager.Instance;
        sentencesToShow = new Queue<string>();
        var chap = manager.currentChapter;
        var level = manager.currentLevel;
        var status = manager.currentLevelStatus;


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

        // switch (status)
        // {
        //     case LevelStatusEnum.Successed:
        //         emoji.sprite = blingEmoji;
        //         break;

        //     case LevelStatusEnum.Begin:
        //     case LevelStatusEnum.Failed:
        //     default:
        //         emoji.sprite = sweatEmoji;
        //         break;
        // }

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
                    "「喔喔來了嗎！看起來狀態不錯嘛～」",
                    "「應該清楚你的職責吧，把眼前的東西修好，就是這麼簡單。」",
                    "「讓我們先從最簡單的開始，這小東西只要更換點零件就能修好了，應該不構成難度吧！」"
                }
            },
            {
                $"1_1_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "【重啟失敗】",
                    "（總覺得...很抱歉？）",
                    "「不...不會吧！大概只是剛開始的關係...沒有錯！多修一點東西再看看吧。」"
                }
            },
            {
                $"1_1_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "【重啟成功】",
                    "（原來你叫手錶啊，很高興認識你。）",
                    "「看來基本的操作沒有甚麼問題。來提升點難度吧！」"
                }
            },
            #endregion Chap1_1
            #region Chap1_2
            {
                $"1_2_{nameof(LevelStatusEnum.Begin)}",
                new string[]
                {
                    "「這次，故障的稍微複雜了點。」",
                    "「不過...對你來說，應該也只是暖機程度而已吧。」",
                    "（總覺得，烤箱看起來很累，他好像已經壞掉很多次了）"
                }
            },
            {
                $"1_2_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "【重啟...失敗】",
                    "（烤箱看起來還是很累）",
                    "「大概只是小瑕疵，這點程度不應該有問題才對...罷了！下一個！」"
                }
            },
            {
                $"1_2_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "【重啟...成功】",
                    "［叮！］烤箱好像在對我說謝謝。",
                    "「你在自言自語甚麼呢，下一個！換個大點的傢伙試試看吧。」"
                }
            },
            #endregion Chap1_2
            #region Chap1_3
            {
                $"1_3_{nameof(LevelStatusEnum.Begin)}",
                new string[]
                {
                    "「這就是最後了，我們會依照綜合結果判斷你能不能進入實作」",
                    "（好...好大。）",
                    "「別愣著了！快點動手吧！」"
                }
            },
            {
                $"1_3_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "【重-重啟-失敗】",
                    "（過份了吧，我剛剛還在修烤箱耶...）",
                    "「看來是我期望過高了嗎...不過，還是看看結果再決定吧。」"
                }
            },
            {
                $"1_3_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "【重啟成功啦！】",
                    "看來，我好像有點厲害呢，哼哼～",
                    "「在說啥呢？別鬆懈了，接下來才是真正的考驗呢。」"
                }
            },
            #endregion Chap1_3
           
            #region Chap2_1
            {
                $"2_1_{nameof(LevelStatusEnum.Begin)}",
                new string[]
                {
                    "「打起精神，接下來就是實作了，這兒可容不得一點失誤！」 ",
                    "「我看看...哦！剛好是最基本的，雖然複雜了一點，但還是很簡單對吧！」",
                    "（總覺得跟前面不是一個等級呀...）"
                }
            },
            {
                $"2_1_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "【重啟失敗】",
                    "（難度提升太多了吧...）",
                    "「喂喂喂！不會連這點程度都負荷不了吧，你認真點啊！」"
                }
            },
            {
                $"2_1_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "【重啟成功】",
                    "（輕輕鬆鬆！雖然接下來它大概不輕鬆了。）",
                    "「很好！看來就算進入實作你應該也沒有什麼問題吧！」"
                }
            },
            #endregion Chap2_1
            #region Chap2_2
            {
                $"2_2_{nameof(LevelStatusEnum.Begin)}",
                new string[]
                {
                    "「接下來是這傢伙...沒什麼不一樣的，修好就對了。」",
                    "［嗶哩嗶哩－吧啦－］",
                    "（有種莫名的熟悉感...它看起來想說什麼...？）"
                }
            },
            {
                $"2_2_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "【重...啟...失敗】",
                    "［嗶－啵－嘰......］（他看起來像睡著了，至少我是這麼感覺的，雖然我還是不知道它說了什麼）",
                    "「是我期望過高嗎...我以為可以做得更好的...算了！下一個是...」"
                }
            },
            {
                $"2_2_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "【重啟...成功？】",
                    "（修好了！但它似乎沒有話要說了...）",
                    "「這就對了！你只管著把送來的東西修好就對了，這就是你的使命。」"
                }
            },
            #endregion Chap2_2
            #region Chap2_3
            {
                $"2_3_{nameof(LevelStatusEnum.Begin)}",
                new string[]
                {
                    "「真要命...沒想到連這個都送來了，看來情況很糟了...」",
                    "（看起來損傷很嚴重...這是什麼呢？）",
                    "「你可要注意點啊！稍有不慎這可不是評分差而已的事情 !」"
                }
            },
            {
                $"2_3_{nameof(LevelStatusEnum.Failed)}",
                new string[]
                {
                    "【重-重-重啟-啟-失敗】",
                    "［滋...滋...滴］（雖然沒有發生嚴重的事故，但看起來它是飛不起來了）",
                    "「在搞什麼啊！不是都提醒要小心點嗎...算了，這次就先這樣！」"
                }
            },
            {
                $"2_3_{nameof(LevelStatusEnum.Successed)}",
                new string[]
                {
                    "【重-啟-成-功】",
                    "（真是危險，為什麼會受損的這麼嚴重呢？又為什麼會送來呢？）",
                    "「太好了...連這都修好了，應該是沒問題了。那麼，來看看綜合表現吧！」"
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
        if (isTransiting)
            return;

        StopCoroutine(nameof(TypeSentence));

        if (currentSentence != "" && dialogueText.text != currentSentence)
        {
            dialogueText.text = currentSentence;
        }
        else
        {

            if (!sentencesToShow.Any())
            {
                EndDialogue();
                return;
            }
            currentSentence = sentencesToShow.Dequeue();
            dialogueText.text = "";
            StartCoroutine(nameof(TypeSentence), currentSentence);
        }
    }

    private IEnumerator TypeSentence(string sentence)
    {
        foreach (var c in sentence.ToCharArray())
        {
            yield return new WaitForSeconds(secondsBetweenChar);
            dialogueText.text += c;
        }
    }

    private void EndDialogue()
    {
        isTransiting = true;
        manager.GoNext();
    }

    public void GoMainMenu()
    {
        manager.Go(SceneEnum.MainMenu_Scene);
    }

}
