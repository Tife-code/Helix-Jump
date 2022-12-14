using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundsText;

    private void Start()
    {
        if (GameManager.mute)
            soundsText.text = "/";

        else
            soundsText.text = "";

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }

    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            soundsText.text = "";
        }
        else
        {
            GameManager.mute = true;
            soundsText.text = "/";
        }
    }
}
