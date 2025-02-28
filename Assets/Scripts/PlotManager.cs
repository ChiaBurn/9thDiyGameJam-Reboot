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
    [SerializeField]
    float secondsBetweenChar = 0.05f;

    [Header("Image object settings")]
    public Image robot;
    public Image emoji;

    [Header("Image settings")]
    public Sprite sweatEmoji;
    public Sprite blingEmoji;




    private Queue<string> sentencesToShow;

    void Start()
    {
        SetImageByGameStatus();
        sentencesToShow = new Queue<string>();

        var testSentences = new string[]
        {
            "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
            "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
            "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
        };

        StartDialogue(testSentences);
    }

    private void SetImageByGameStatus()
    {
        switch (PersistentManager.Instance.currentLevelStatus)
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
    }

    private void StartDialogue(IEnumerable<string> sentences)
    {
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

    public class Robot
    {
        string key;
        Texture robotImg;
        Texture emojiImg;
        string[] sentences;
    }
}
