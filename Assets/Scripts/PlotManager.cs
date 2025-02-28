using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{
    public Text dialogueText;
    [SerializeField]
    float secondsBetweenChar = 0.05f;

    private Queue<string> sentencesToShow;

    void Start()
    {
        sentencesToShow = new Queue<string>();

        var testSentences = new string[]
        {
            "第一句話第一句話第一句話第一句話第一句話第一句話第一句話",
            "第二句話第二句話第二句話第二句話第二句話第二句話第二句話第二句話",
            "最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話最後一句話"
        };

        StartDialogue(testSentences);
    }

    public void StartDialogue(IEnumerable<string> sentences)
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
}
