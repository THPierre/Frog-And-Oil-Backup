 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputMenuManager : MonoBehaviour
{
    Transform inputButtonCanvas;
    Event keyEvent;
    TextMeshProUGUI buttonText;
    KeyCode newKey;
    bool waitingForKey;
    string pressKeyPrompt = "Press a Key";

    // Start is called before the first frame update
    void Start()
    {
        inputButtonCanvas = transform.Find("inputButtons");
        waitingForKey = false;

        for (int i = 0; i < 6; i++)
        {
            if (inputButtonCanvas.GetChild(i).name == "moveForwardKey")
            {
                inputButtonCanvas.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.gameManager.MoveForward.ToString();
            }
            else if (inputButtonCanvas.GetChild(i).name == "moveBackwardKey")
            {
                inputButtonCanvas.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.gameManager.MoveBackward.ToString();
            }
            else if (inputButtonCanvas.GetChild(i).name == "moveLeftKey")
            {
                inputButtonCanvas.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.gameManager.MoveLeft.ToString();
            }
            else if (inputButtonCanvas.GetChild(i).name == "moveRightKey")
            {
                inputButtonCanvas.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.gameManager.MoveRight.ToString();
            }
            else if (inputButtonCanvas.GetChild(i).name == "fireKey")
            {
                inputButtonCanvas.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.gameManager.Fire.ToString();
            }
            else if (inputButtonCanvas.GetChild(i).name == "jumpKey")
            {
                inputButtonCanvas.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.gameManager.Jump.ToString();
            }

        }
    }

    private void OnGUI()
    {
        keyEvent = Event.current;
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void SendText(TextMeshProUGUI text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
        {
            buttonText.text = pressKeyPrompt;
            yield return null;
        }
        yield return null;
    }
    

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;
        yield return WaitForKey();
        

        switch (keyName)
        {
            case "moveForward":
                GameManager.gameManager.MoveForward = newKey;
                buttonText.text = GameManager.gameManager.MoveForward.ToString();
                PlayerPrefs.SetString("MoveForwardKey", GameManager.gameManager.MoveForward.ToString());
                break;
            case "moveBackward":
                GameManager.gameManager.MoveBackward = newKey;
                buttonText.text = GameManager.gameManager.MoveBackward.ToString();
                PlayerPrefs.SetString("MoveBackwardKey", GameManager.gameManager.MoveBackward.ToString());
                break;
            case "moveLeft":
                GameManager.gameManager.MoveLeft = newKey;
                buttonText.text = GameManager.gameManager.MoveLeft.ToString();
                PlayerPrefs.SetString("MoveLeftKey", GameManager.gameManager.MoveLeft.ToString());
                break;
            case "moveRight":
                GameManager.gameManager.MoveRight = newKey;
                buttonText.text = GameManager.gameManager.MoveRight.ToString();
                PlayerPrefs.SetString("MoveRightKey", GameManager.gameManager.MoveRight.ToString());
                break;
            case "fire":
                GameManager.gameManager.Fire = newKey;
                buttonText.text = GameManager.gameManager.Fire.ToString();
                PlayerPrefs.SetString("FireKey", GameManager.gameManager.Fire.ToString());
                break;
            case "jump":
                GameManager.gameManager.Jump = newKey;
                buttonText.text = GameManager.gameManager.Jump.ToString();
                PlayerPrefs.SetString("JumpKey", GameManager.gameManager.Jump.ToString());
                break;
        }
        yield return null;
    }

    public void StartBinding(string keyName)
    {
        if (!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.Save();
        Debug.Log("Settings are Saved");
    }

    void Update()
    {
        
    }
}
