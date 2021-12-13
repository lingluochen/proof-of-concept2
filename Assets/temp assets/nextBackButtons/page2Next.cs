using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class page2Next : MonoBehaviour
{

    public GameObject buttonObject;
    public SpriteRenderer buttonSprite;
    bool hover;
    public Color hoverColor, noHoverColor;
    public GameObject currentPage, nextPage;


    // Start is called before the first frame update
    void Start()
    {
        buttonSprite.color = noHoverColor;
        currentPage.SetActive(true);
        nextPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("on page one's next button.");
        buttonSprite.color = hoverColor;
        hover = true;
        if (Input.GetMouseButtonDown(0) && hover == true)
          {
              currentPage.SetActive(false);
              nextPage.SetActive(true);
              Debug.Log("pressed page one's next button.");
              buttonSprite.color = noHoverColor;
          }      
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("not on page one's next button.");
        buttonSprite.color = noHoverColor;
        hover = false;
    }
}
