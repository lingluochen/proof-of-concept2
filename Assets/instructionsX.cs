using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionsX : MonoBehaviour
{

    public GameObject instructionsXButtonSprite;
    public SpriteRenderer buttonSprite, bookSprite;
    bool hover;
    public Color hoverColor, noHoverColor, ogColor;
    public GameObject bookObject, instructionsObject, page1Object, page2Object, page3Object, page4Object, xObject;


    // Start is called before the first frame update
    void Start()
    {
        hover = false;
        buttonSprite.color = noHoverColor;
        //bookObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {  

    }


    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("on X button.");
        buttonSprite.color = hoverColor;
        hover = true;

          if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("pressed X button.");
            instructionsObject.SetActive(false);
            xObject.SetActive(false);
            bookSprite.color = ogColor; //makethebook brown
            buttonSprite.color = noHoverColor;
            page1Object.SetActive(false);//hide the page
            page2Object.SetActive(false);
            page3Object.SetActive(false);
            page4Object.SetActive(false);
            //bookObject.SetActive(true);//put the book back
        }
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("not on X button.");
        buttonSprite.color = noHoverColor;
        hover = false;
    }
}
