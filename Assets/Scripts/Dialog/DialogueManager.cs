using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;

    public GameObject yesButton;
    public GameObject noButton;
    public GameObject nextButton;

    public Animator boxAnim;
    public Animator startAnim;

    public int m = 2;

    //public Player player;

    public GameObject takeQuestText;
    public GameObject noQuestText;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if(sentences.Count == 1)
        {
            nextButton.SetActive(false);
            noButton.SetActive(true);
            yesButton.SetActive(true);

        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void TakeQuest()
    {
        PlayerPrefs.SetInt("missionid", m);
        //player.SetMission(missionId);
        takeQuestText.SetActive(true);
        EndDialogue();
    }

    public void NoQuest()
    {
        noQuestText.SetActive(true);
        EndDialogue();
    }



    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    public void EndDialogue()
    {
        boxAnim.SetBool("boxOpen", false);
        nextButton.SetActive(true);
        noButton.SetActive(false);
        yesButton.SetActive(false);

    }
}
