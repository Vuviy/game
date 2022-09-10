using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    public GameObject pinPanel;
    public GameObject moneyPanel;
    public GameObject input;
    public GameObject enterPinBtn;
    public Text inputText, title;
    public InputField inputField;
    public Player player;
    bool checkPin;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pinPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pinPanel.SetActive(false);
        title.text = "pin";
        inputField.Select();
        inputField.text = "";
        input.SetActive(true);
        enterPinBtn.SetActive(true);
        moneyPanel.SetActive(false);
    }

    private void CheckPin()
    {
        if(inputText.text == "4444")
        {
            checkPin = true;
        } else
        {
            checkPin = false;
        }
    }

    public void Check()
    {
        CheckPin();
        if (checkPin)
        {
            title.text = "Зняття готівки";
            moneyPanel.SetActive(true);
            input.SetActive(false);
            enterPinBtn.SetActive(false);
        } else
        {
            title.text = "worng pin";
            inputField.Select();
            inputField.text = "";
        }

    }

    public void TakeMoney()
    {
        int summ = int.Parse(gameObject.name);
        if(summ == 200)
        {
            PlayerPrefs.SetInt("missionDone", 1);
        }
        if (!PlayerPrefs.HasKey("playerMonye"))
        {
            PlayerPrefs.SetInt("playerMonye", summ);
            //player.money = summ;
        }
        else
        {
            int monye = PlayerPrefs.GetInt("playerMonye") + summ;
            PlayerPrefs.SetInt("playerMonye", monye);
            //player.money = monye;
        }

        pinPanel.SetActive(false);
        moneyPanel.SetActive(false);
        title.text = "pin";
        inputField.Select();
        inputField.text = "";
        input.SetActive(true);
        enterPinBtn.SetActive(true);

    }




}
