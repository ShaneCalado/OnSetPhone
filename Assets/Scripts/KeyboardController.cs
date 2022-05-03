using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    [SerializeField]
    private TextConversationController textConversation;

    [SerializeField]
    private KeyController[] keyboardKeys;

    [SerializeField]
    private bool keyPressed;

    [SerializeField]
    private AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        keyboardKeys = GetComponentsInChildren<KeyController>();

        foreach(KeyController key in keyboardKeys)
        {
            key.SetKeyboardController(this);
        }

        textConversation = FindObjectOfType<TextConversationController>();

        soundEffect = GetComponent<AudioSource>();
    }

    public void SetKeyPressed(bool keyPressed)
    {
        this.keyPressed = keyPressed;
    }

    public bool IsKeyPressed()
    {
        return this.keyPressed;
    }

    public void PressKey(string keyName)
    {
        

        if(keyName == "Enter_Button" || keyName == "Send_Button")
        {
            textConversation.SendTextMessage();
            textConversation.ReceiveTextMessage();

            if (keyName == "Enter_Button")
            {
                soundEffect.Play();
            }
        }
        else
        {
            soundEffect.Play();
            textConversation.AddLetterToTextInput();
        }
    }
}
