using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backInstructionPage : MonoBehaviour
{

    public GameObject nextButtonObject, backButtonObject;
    public SpriteRenderer nextButtonSprite, backButtonSprite;
    bool hover, pageOne, pageTwo, pageThree, pageFour;
    public Color hoverColor, noHoverColor;

    public GameObject[] SpriteList;

    // Start is called before the first frame update
    void Start()
    {
        nextButtonSprite.color = noHoverColor;
        pageOne = true;

    }

    void Update()
    {
        nextButtonObject.SetActive(true);
        backButtonObject.SetActive(true);
    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("on page one's next button.");
        nextButtonSprite.color = hoverColor;
        hover = true;

         if (Input.GetMouseButtonDown(0) && hover == true && pageOne == true)
          {
              Debug.Log("pressed page two's next button.");
              nextButtonSprite.color = noHoverColor;
              
              backButtonObject.SetActive(false);
              
          } else if (Input.GetMouseButtonDown(0) && hover == true && pageTwo == true)
          {
              Debug.Log("pressed page two's next button.");
              nextButtonSprite.color = noHoverColor;
              SpriteList[0].SetActive(false);
              SpriteList[1].SetActive(false);
              SpriteList[2].SetActive(true);
              SpriteList[3].SetActive(false);

              nextButtonObject.SetActive(true);
              backButtonObject.SetActive(true);

              pageTwo = false;
              pageThree = true;
          }else if (Input.GetMouseButtonDown(0) && hover == true && pageThree == true)
          {
              Debug.Log("pressed page two's next button.");
              nextButtonSprite.color = noHoverColor;
              SpriteList[0].SetActive(false);
              SpriteList[1].SetActive(false);
              SpriteList[2].SetActive(false);
              SpriteList[3].SetActive(true);

              nextButtonObject.SetActive(false);
              backButtonObject.SetActive(true);

              pageThree = false;
              pageFour = true;
              
          }
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("not on page one's next button.");
        nextButtonSprite.color = noHoverColor;
        hover = false;
    }
}
