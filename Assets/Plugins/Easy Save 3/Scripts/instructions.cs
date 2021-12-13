using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instructions : MonoBehaviour
{

    public GameObject instructionsButtonSprite;
    public GameObject nextButtonObject, backButtonObject;
    public SpriteRenderer buttonSprite;
    bool hover;
    public Color hoverColor, noHoverColor;
    public GameObject instructionObject, page1Object, xObject;


    // Start is called before the first frame update
    void Start()
    {
        instructionObject.SetActive(false);
        page1Object.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        buttonSprite.color = hoverColor;
        hover = true;

        if (Input.GetMouseButtonDown(0) && hover == true)
          {
              //nextButtonObject.SetActive(true);
              //backButtonObject.SetActive(false);
              instructionObject.SetActive(true);
              page1Object.SetActive(true);
              xObject.SetActive(true);
              Debug.Log("Pressed instruction book.");
          }      
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        buttonSprite.color = noHoverColor;
        hover = false;
    }
}
