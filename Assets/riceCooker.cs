using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riceCooker : MonoBehaviour
{
    public putDown putd;
    public bool cooking;
    public float cookingTimer;
    public float maxCookTime;
    public Transform bar;
    public float initialScale;
    public GameObject cookedWhite;
    public GameObject cookedBrown;
    public GameObject cookedRice;
    public Animator myAni;
    public bool playOpenAni;
    public bool playCloseAni;
    public float openCounter;
    public float closeCounter;
    // Start is called before the first frame update
    void Start()
    {
        putd = GetComponent<putDown>();
        cookingTimer = 0;
        initialScale = bar.localScale.x;
        myAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cooking)
        {
            putd.canPut = false;
            if (cookingTimer == 0)
            {
                bar.localScale = new Vector2(initialScale, bar.localScale.y);
            }
            else if (cookingTimer <= maxCookTime && cookedRice == null)
            {
                float reduceAmount = initialScale / maxCookTime;
                float newScaleX = bar.localScale.x - reduceAmount;
                bar.localScale = new Vector2(newScaleX, bar.localScale.y);
            }
            else if (cookedRice != null)
            {
                bar.localScale = new Vector2(0, bar.localScale.y);
            }
            if (cookingTimer < maxCookTime)
            {
                cookingTimer += 1;
                if (cookingTimer == maxCookTime - 1)
                {
                    if (this.gameObject.transform.GetChild(2) != null)
                    {
                        playCloseAni = false;
                        playOpenAni = true;
                        GameObject thisRice = this.gameObject.transform.GetChild(2).gameObject;
                        if (thisRice.name.Contains("white"))
                        {
                            cookedRice = Instantiate(cookedWhite, transform.position, Quaternion.Euler(0, 0, 0));
                            cookedRice.GetComponent<SpriteRenderer>().sortingOrder = -10;
                            cookedRice.transform.position = new Vector2(transform.position.x, transform.position.y + 2.7f);
                        }
                        else
                        {
                            cookedRice = Instantiate(cookedBrown, transform.position, Quaternion.Euler(0, 0, 0));
                            cookedRice.GetComponent<SpriteRenderer>().sortingOrder = -10;
                            cookedRice.transform.position = new Vector2(transform.position.x, transform.position.y + 2.7f);
                        }
                        Destroy(thisRice);
                    }

                }
                else if (cookingTimer < maxCookTime -1)
                {
                    playCloseAni = true;
                    playOpenAni = false;
                }


            }
            else if (cookedRice == null)
            {
                cookingTimer = 0;
                cooking = false;

            }
        }
        else
        {
            putd.canPut = true;
            bar.localScale = new Vector2(0, bar.localScale.y);
            if (GameObject.Find("Game Manager").GetComponent<gameManager>().pickObj != null && GameObject.Find("Game Manager").GetComponent<gameManager>().pickObj.tag == "cooked")
            {
                playCloseAni = true;
                playOpenAni = false;

            }

        }
        int childCount = transform.childCount;
        if (childCount > 2)
        {
            cooking = true;
            transform.GetChild(2).position = new Vector2(transform.position.x, transform.position.y + 2.7f);
            transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
        }
        if (cookedRice != null)
        {
            if (cookedRice.GetComponent<pick>().beingPicked)
            {
                cookedRice = null;
                GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    
        
        if (playOpenAni)
        {

            if (openCounter < 25)
            {
                changeState("opening");
                openCounter += 1;
            }
            else
            {
                changeState("open");
            }
            
        }
        else
        {
            playOpenAni = false;
            openCounter = 0;
        }

        if (playCloseAni)
        {
            if (closeCounter < 25)
            {
                changeState("closing");
                closeCounter += 1;
            }
            else
            {
                changeState("close");
            }
        }
        else
        {
            playCloseAni = false;
            closeCounter = 0;
        }
        
    }


    private void OnMouseEnter()
    {
        if (!cooking && GameObject.Find("Game Manager").GetComponent<gameManager>().picked && GameObject.Find("Game Manager").GetComponent<gameManager>().pickObj.tag != "cooked")
        {
            playOpenAni = true;
            playCloseAni = false;
        }
    }

    private void OnMouseExit()
    {
        if (!cooking && GameObject.Find("Game Manager").GetComponent<gameManager>().picked && GameObject.Find("Game Manager").GetComponent<gameManager>().pickObj.tag != "cooked")
        {
            playCloseAni = true;
            playOpenAni = false;
        }
    }

    public void changeState(string target)
    {
        myAni.Play(target);
    }


}
