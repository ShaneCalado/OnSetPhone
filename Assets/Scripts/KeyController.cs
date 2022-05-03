using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyController : Button
{
    private KeyboardController keyboard;
    private bool thisKeyPressed;
    // Key pressed
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!keyboard.IsKeyPressed())
        {
            gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            thisKeyPressed = true;
            keyboard.SetKeyPressed(true);
            keyboard.PressKey(this.gameObject.name);
        }
        
    }

    // Key released
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (thisKeyPressed)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            thisKeyPressed = false;
            keyboard.SetKeyPressed(false);
        }
        
        
    }

    public void SetKeyboardController(KeyboardController keyboard)
    {
        this.keyboard = keyboard;
    }



}
