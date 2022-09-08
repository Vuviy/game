using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;
    //public Player player;
    public GameObject goOut;


    public void OnTriggerEnter2D(Collider2D collision)
    {

        //!PlayerPrefs.HasKey("missionId")
        if (!PlayerPrefs.HasKey("missionid"))
        {
            startAnim.SetBool("startOpen", true);
        }
        else
        {
            goOut.SetActive(true);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        startAnim.SetBool("startOpen", false);
        dm.takeQuestText.SetActive(false);
        dm.noQuestText.SetActive(false);
        goOut.SetActive(false);
        dm.EndDialogue();
    }
}
