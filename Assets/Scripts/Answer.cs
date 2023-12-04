using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public Text answer;
    public Text msg_check;
    public int number;
    private bool isNewMessage;
    private void OnEnable()
    {
        ReadInput.OnKeyDown += HandleKeyDown;
    }
    private void OnDisable()
    {
        ReadInput.OnKeyDown -= HandleKeyDown;
    }
    private void HandleKeyDown(KeyCode key)
    {
        if (Time.timeScale != 0)
        {
            if (key == KeyCode.Backspace && answer.text.Length > 0)
            {
                answer.text = answer.text.Substring(0, answer.text.Length - 1);
            }
            if (key >= KeyCode.Alpha0 && key <= KeyCode.Alpha9)
            {
                string keyValue = key.ToString().Replace("Alpha", "");
                if (answer.text == null || answer.text == "")
                {
                    answer.text = keyValue;
                }
                else
                {
                    if (int.Parse(answer.text + keyValue) <= 100)
                    {
                        answer.text += keyValue;
                    }
                }
            }
            if (key >= KeyCode.Keypad0 && key <= KeyCode.Keypad9)
            {
                string keyValue = key.ToString().Replace("Keypad", "");
                if (answer.text == null || answer.text == "")
                {
                    answer.text = keyValue;
                }
                else
                {
                    if (int.Parse(answer.text + keyValue) <= 100)
                    {
                        answer.text += keyValue;
                    }
                }
            }
            if (key == KeyCode.Return)
            {
                if (answer.text != "")
                {
                    number = int.Parse(answer.text);
                    GameManager gameManager = GetComponent<GameManager>();
                    Debug.Log(number);
                    answer.text = "";
                    string orc_talk = gameManager.CheckAnswer(number);
                    StartCoroutine(change_msg(orc_talk, 1f));
                }
            }
        }
    }    
    IEnumerator change_msg(string msg, float displaytime)
    {

        if (msg != null)
        {
            OnNewMsg(msg);
        }
        if (msg == "Nooooooo!")
            yield break;
        yield return new WaitForSeconds(displaytime);
        isNewMessage = false;
        if (!isNewMessage)
        {
            msg_check.text = "Choose a number from 1 to 100!";
        }
    }

    public void SetText(string msg)
    {
        msg_check.text = msg;
    }

    public void OnNewMsg(string newmsg)
    {
        SetText(newmsg);
        isNewMessage = true;
    }
}
