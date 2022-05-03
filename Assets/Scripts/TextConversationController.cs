using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextConversationController : MonoBehaviour
{
    [SerializeField]
    private Text textInputBox;

    [SerializeField]
    private string[] messagesToSend;

    [SerializeField]
    private string[] messagesToReceive;

    [SerializeField]
    private int textInputPosition, sendMessageCount, receiveMessageCount;

    [SerializeField]
    private Transform sendMessagePosition, receiveMessagePosition;

    [SerializeField]
    private GameObject sendTextMessagePrefab, receiveTextMessagePrefab;

    private List<GameObject> textConversation;

    private void OnEnable()
    {
        textConversation = new List<GameObject>();
    }

    private void Start()
    {
        textInputBox.text = "";
    }

    public void AddLetterToTextInput()
    {
        textInputBox.text = textInputBox.text + GetNextLetterInText();
    }

    public void SendTextMessage()
    {
        if(sendMessageCount < messagesToSend.Length)
        {
            foreach (GameObject text in textConversation)
            {
                Vector3 nextPos = new Vector3(text.transform.position.x, text.transform.position.y + 100, text.transform.position.z);
                text.transform.position = nextPos;
            }

            GameObject newText = Instantiate(sendTextMessagePrefab);
            newText.transform.SetParent(this.transform);
            newText.transform.position = sendMessagePosition.position;
            newText.GetComponentInChildren<Text>().text = messagesToSend[sendMessageCount];
            textConversation.Add(newText);

            textInputBox.text = "";
            sendMessageCount++;
            textInputPosition = 0;
        }

        
    }

    public void ReceiveTextMessage()
    {
        if(receiveMessageCount < messagesToReceive.Length)
        {
            foreach (GameObject text in textConversation)
            {
                Vector3 nextPos = new Vector3(text.transform.position.x, text.transform.position.y + 100, text.transform.position.z);
                text.transform.position = nextPos;
            }

            GameObject newText = Instantiate(receiveTextMessagePrefab);
            newText.transform.SetParent(this.transform);
            newText.transform.position = receiveMessagePosition.position;
            newText.GetComponentInChildren<Text>().text = messagesToReceive[receiveMessageCount];
            textConversation.Add(newText);

            receiveMessageCount++;
        }

        
    }

    private string GetNextLetterInText()
    {
        string nextLetter = "";

        if(messagesToReceive != null)
        {
            if(sendMessageCount <= messagesToSend.Length)
            {
                if(textInputPosition <= messagesToSend[sendMessageCount].Length)
                {
                    string currentMessage = messagesToSend[sendMessageCount];
                    nextLetter = currentMessage[textInputPosition].ToString();
                    textInputPosition++;
                }
            }
        }


        return nextLetter;
    }
}
