using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResutManager : MonoBehaviour
{
    [Header("Image object settings")]
    public Text conclusion;
    public Image stars;


    [Header("Image stars option")]
    public Sprite stars_0;
    public Sprite stars_1;
    public Sprite stars_2;
    public Sprite stars_3;

private PersistentManager manager;

    void Start()
    {
        manager = PersistentManager.Instance;
        var chap = manager.currentChapter;
        var score = manager.currentChapterScore;

        SetStarsByChapScore(score);
        SetConclusionByScore(chap, score);
    }


    private void SetStarsByChapScore(int score)
    {
        switch (score)
        {
            case 3:
                stars.sprite = stars_3;
                break;
            case 2:
                stars.sprite = stars_2;
                break;
            case 1:
                stars.sprite = stars_1;
                break;
            case 0:
            default:
                stars.sprite = stars_0;
                break;
        }
    }
    private void SetConclusionByScore(int chap, int score)
    {
        var conclusionDictionary_tw = new Dictionary<string, string>
        {
            {
                "1_0",
                "竟然......太令我感到失望了，這樣的話，直接重設並重新啟動吧。"
            },
            {
                "1_1",
                "勉勉強強吧！就看實作是否能合格了，也許奇蹟會發生也說不定。"
            },
            {
                "1_2",
                "雖然有點小瑕...我是指進步空間，進入實作還是有順利達成的可能性的。"
            },
            {
                "1_3",
                "基本測試只是小Case。看來這次，直接投入實作也沒有問題了吧！"
            },
            {
                "2_0",
                "這次也失敗了嗎......唉...看來要重設並重新啟動了。"
            },
            {
                "2_1",
                "成功率跟效率都還有待加強......重設並重新啟動吧。"
            },
            {
                "2_2",
                "這個版本稍微有些瑕疵呢......下次一定沒問題的，重設並重新啟動吧。"
            },
            {
                "2_3",
                "大成功！太好了，看來新版本的維修機器人已經校正完成，可以做出廠準備並送往前線了。"
            },
        };

        conclusion.text = conclusionDictionary_tw[$"{chap}_{score}"];
    }
    
    public void GoNext()
    {
        manager.GoNext();
    }

    public void GoMainMenu()
    {
        manager.Go(SceneEnum.MainMenu_Scene);
    }
}
