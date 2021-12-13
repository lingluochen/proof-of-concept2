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
    public GameObject instructionObject, page1Object;


    // Start is called before the first frame update
    void Start()
    {
        instructionObject.SetActive(false);
        page1Object.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetMouseButtonDown(0) && hover == true)
          {
              instructionObject.SetActive(true);
              page1Object.SetActive(true);
              Debug.Log("Pressed instruction book.");
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
