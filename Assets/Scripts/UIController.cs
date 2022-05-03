using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text isTouchingText;
    public Text touchPosText;

    private TouchInputController touchInputController;

    private void Awake()
    {
        touchInputController = GetComponent<TouchInputController>();
    }

    private void Update()
    {
        if (touchInputController.isTouching)
        {
            isTouchingText.text = "true";
            touchPosText.text = touchInputController.touchPosition.ToString();
        }
        else
        {
            isTouchingText.text = "false";
            touchPosText.text = "-";
        }
    }
}
