using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;
    //public Player player;
    public GameObject goOut;
    public GameObject win;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PlayerPrefs.HasKey("missionDone2"))
        {
            //!PlayerPrefs.HasKey("missionId")
            if (!PlayerPrefs.HasKey("missionid"))
            {
                startAnim.SetBool("startOpen", true);
            }
            else
            {
                if (PlayerPrefs.HasKey("missionDone"))
                {
                    win.SetActive(true);
                    PlayerPrefs.DeleteKey("missionid");
                    PlayerPrefs.DeleteKey("missionDone");
                    int monye = PlayerPrefs.GetInt("playerMonye") - 200;
                    PlayerPrefs.SetInt("playerMonye", monye);
                    PlayerPrefs.SetInt("missionDone2", 1);
                }
                else
                {
                    goOut.SetActive(true);
                }    
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        startAnim.SetBool("startOpen", false);
        dm.takeQuestText.SetActive(false);
        dm.noQuestText.SetActive(false);
        goOut.SetActive(false);
        dm.EndDialogue();
        win.SetActive(false);
    }

    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}
