using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instructions : MonoBehaviour
{

    public GameObject instructionsButtonSprite;
    public SpriteRenderer buttonSprite;
    bool hover;
    public Color hoverColor, noHoverColor;
    public GameObject bookObject, instructionObject, page1Object, page2Object, page3Object, page4Object, xObject;


    // Start is called before the first frame update
    void Start()
    {
        buttonSprite.color = noHoverColor;
        instructionObject.SetActive(false);
        xObject.SetActive(false);
        page1Object.SetActive(false);
        page2Object.SetActive(false);
        page3Object.SetActive(false);
        page4Object.SetActive(false);
        //bookObject.SetActive(true);
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
              instructionObject.SetActive(true);
              xObject.SetActive(true);
              //bookObject.SetActive(false);
              page1Object.SetActive(true);
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
