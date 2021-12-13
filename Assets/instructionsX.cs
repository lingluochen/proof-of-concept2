using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionsX : MonoBehaviour
{

    public GameObject instructionsXButtonSprite;
    public SpriteRenderer buttonSprite;
    bool hover;
    public Color hoverColor, noHoverColor;
    public GameObject xButtonObject;


    // Start is called before the first frame update
    void Start()
    {
        buttonSprite.color = noHoverColor;
        xButtonObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetMouseButtonDown(0) && hover == true)
          {
              xButtonObject.SetActive(false);
              Debug.Log("Pressed X button.");
              buttonSprite.color = noHoverColor;
          }       
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        buttonSprite.color = hoverColor;
        hover = true;
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        buttonSprite.color = noHoverColor;
        hover = false;
    }
}
