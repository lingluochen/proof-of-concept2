using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrapController : MonoBehaviour
{
    public GameObject scroller;
    public GameObject currentSeaweed;
    public seaweed swScript;
    public bool scrolling;
    public bool startScroll;
    public float scrollCounter;
    public GameObject theScroll;
    public GameObject audio;
 
    // Start is called before the first frame update
    void Start()
    {
        scroller = transform.GetChild(0).gameObject;
        audio.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentSeaweed != null)
        {
            swScript = currentSeaweed.GetComponent<seaweed>();
            if (swScript.hasProtein && swScript.hasRice && swScript.hasVeggie)
            {
                startScroll = true;
            }
        }

        if (startScroll)
        {
            if (scrollCounter < 60 && scrollCounter > 10)
            {
                scroller.GetComponent<SpriteRenderer>().enabled = true;
                audio.SetActive(true);
            }
            else
            {
                changeState("still");
                scroller.GetComponent<SpriteRenderer>().enabled = false;
                audio.SetActive(false);
            }
            scrollCounter += 1;
            if (scrollCounter > 10 && scrollCounter <= 45)
            {
                changeState("wrap in");

                if (scrollCounter == 45)
                {
                    List<string> names = new List<string>();
                    names.Add(swScript.theFlat.name);
                    Destroy(swScript.theFlat);
                    names.Add(swScript.theVeggie.name);
                    Destroy(swScript.theVeggie);
                    names.Add(swScript.theProtein.name);
                    Destroy(swScript.theProtein);
                    GameObject thisScroll = Instantiate(theScroll, currentSeaweed.transform.position, Quaternion.Euler(0, 0, 0));
                    thisScroll.GetComponent<sushiRoll>().ingredientNames = names;
                    theScroll.GetComponent<SpriteRenderer>().sortingOrder = currentSeaweed.GetComponent<SpriteRenderer>().sortingOrder;
                    Destroy(currentSeaweed);
                    currentSeaweed = null;
                    swScript = null;
                }

            }
            else if (scrollCounter > 45 && scrollCounter < 70)
            {
                scroller.GetComponent<Animator>().SetBool("out", true);
            }
        }
        else if (scrollCounter > 70)
        {

            startScroll = false;
            scrollCounter = 0;
        }

        else
        {
            changeState("still");
            scroller.GetComponent<SpriteRenderer>().enabled = false;
            scroller.GetComponent<Animator>().SetBool("out", false);
        }
    }


    public void changeState(string target)
    {
        scroller.GetComponent<Animator>().Play(target);
    }
}
