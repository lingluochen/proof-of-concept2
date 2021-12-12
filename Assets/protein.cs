using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protein : MonoBehaviour
{
    public gameManager manager;
    public bool tentacle;
    public bool hokkikai;
    public bool roe;
    public Vector2 movePos;
    public Vector2 oriPos;
    public bool moving;
    public float movingCounter;
    public bool reach;
    public Sprite phase1;
    public Sprite phase2;
    public GameObject tentacleProtein;
    public GameObject hokkikaiProtein;
    public GameObject roeProtein;
    public GameObject hurt;
    public GameObject roeAnim;
    public float animCounter;
    public heartManager heart;
    public GameObject other1;
    public GameObject other2;
    public GameObject hurtEffect;
    // Start is called before the first frame update
    void Start()
    {
        hurt.SetActive(false);
        oriPos = transform.position;
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        phase1 = GetComponent<SpriteRenderer>().sprite;
        if (roeAnim != null)
        {
            roeAnim.SetActive(false);
        }
        hurtEffect.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (manager.theSeaweed != null)
        {
            if (tentacle && manager.theSeaweed.GetComponent<seaweed>().hasRice)
            {
                if (!moving && !manager.theSeaweed.GetComponent<seaweed>().hasProtein)
                {
                    if (manager.theSeaweed.GetComponent<seaweed>().theProtein == null && Input.GetKey(KeyCode.Q))
                    {
                        other1.SetActive(false);
                        other2.SetActive(false);
                        moving = true;
                    }
                }
                else
                {
                    if (!reach && !manager.theSeaweed.GetComponent<seaweed>().hasProtein)
                    {
                        if (Input.GetKey(KeyCode.Q))
                        {
                            other1.SetActive(false);
                            other2.SetActive(false);
                            movingCounter += 1;
                            transform.position = Vector2.MoveTowards(transform.position, movePos, 0.2f);
                            if (transform.position.y >= movePos.y)
                            {
                                reach = true;
                            }
                        }
                        else
                        {
                            other1.SetActive(true);
                            other2.SetActive(true);
                            movingCounter -= 1;
                            transform.position = Vector2.MoveTowards(transform.position, oriPos, 0.4f);
                            if (movingCounter == 0)
                            {
                                moving = false;
                            }
                        }
                    }
                }

                if (reach)
                {
                    other1.SetActive(true);
                    other2.SetActive(true);
                    if (animCounter < 20)
                    {
                        animCounter += 1;
                        hurtEffect.SetActive(true);
                    }
                    else
                    {
                        hurtEffect.SetActive(false);
                    }
                    if (manager.theSeaweed.GetComponent<seaweed>().theProtein == null)
                    {
                        hurt.SetActive(true);
                        heart.health -= 1;
                        GameObject theTentacle = Instantiate(tentacleProtein, transform.GetChild(0).position, Quaternion.Euler(0, 0, 0));
                        theTentacle.GetComponent<SpriteRenderer>().sortingOrder = 5;
                        manager.theSeaweed.GetComponent<seaweed>().theProtein = theTentacle;
                    }
                    GetComponent<SpriteRenderer>().sprite = phase2;
                    transform.position = Vector2.MoveTowards(transform.position, oriPos, 0.2f);
                    if (transform.position.y <= oriPos.y)
                    {
                        animCounter = 0;
                        hurt.SetActive(false);
                        reach = false;
                        moving = false;
                        movingCounter = 0;
                        GetComponent<SpriteRenderer>().sprite = phase1;
                    }
                }
            }
            else

            if (hokkikai && manager.theSeaweed.GetComponent<seaweed>().hasRice)
            {
                if (!moving && !manager.theSeaweed.GetComponent<seaweed>().hasProtein)
                {
                    if (manager.theSeaweed.GetComponent<seaweed>().theProtein == null && Input.GetKey(KeyCode.W))
                    {
                        other1.SetActive(false);
                        other2.SetActive(false);
                        moving = true;
                    }
                }
                else
                {
                    if (!reach && !manager.theSeaweed.GetComponent<seaweed>().hasProtein)
                    {
                        if (Input.GetKey(KeyCode.W))
                        {
                            other1.SetActive(false);
                            other2.SetActive(false);
                            movingCounter += 1;
                            transform.position = Vector2.MoveTowards(transform.position, movePos, 0.2f);
                            if (transform.position.y >= movePos.y)
                            {
                                reach = true;
                            }
                        }
                        else
                        {
                            other1.SetActive(true);
                            other2.SetActive(true);
                            movingCounter -= 1;
                            transform.position = Vector2.MoveTowards(transform.position, oriPos, 0.4f);
                            if (movingCounter == 0)
                            {
                                moving = false;
                            }
                        }
                    }
                }

                if (reach)
                {
                    if (animCounter < 20)
                    {
                        animCounter += 1;
                        hurtEffect.SetActive(true);
                    }
                    else
                    {
                        hurtEffect.SetActive(false);
                    }
                    other1.SetActive(true);
                    other2.SetActive(true);
                    if (manager.theSeaweed.GetComponent<seaweed>().theProtein == null)
                    {
                        hurt.SetActive(true);
                        heart.health -= 1;
                        GameObject theHokkikai = Instantiate(hokkikaiProtein, transform.GetChild(0).position, Quaternion.Euler(0, 0, 0));
                        theHokkikai.GetComponent<SpriteRenderer>().sortingOrder = 5;
                        manager.theSeaweed.GetComponent<seaweed>().theProtein = theHokkikai;
                    }
                    GetComponent<SpriteRenderer>().sprite = phase2;
                    transform.position = Vector2.MoveTowards(transform.position, oriPos, 0.2f);
                    if (transform.position.y <= oriPos.y)
                    {
                        hurt.SetActive(false);
                        reach = false;
                        moving = false;
                        movingCounter = 0;
                        GetComponent<SpriteRenderer>().sprite = phase1;
                    }
                }
            }
            else

            if (roe && manager.theSeaweed.GetComponent<seaweed>().hasRice)
            {
                if (!moving && !manager.theSeaweed.GetComponent<seaweed>().hasProtein)
                {
                    if (manager.theSeaweed.GetComponent<seaweed>().theProtein == null && Input.GetKey(KeyCode.E))
                    {
                        other1.SetActive(false);
                        other2.SetActive(false);
                        moving = true;
                    }
                }
                else
                {
                    if (!reach && !manager.theSeaweed.GetComponent<seaweed>().hasProtein)
                    {
                        if (Input.GetKey(KeyCode.E))
                        {
                            other1.SetActive(false);
                            other2.SetActive(false);
                            movingCounter += 1;
                            transform.position = Vector2.MoveTowards(transform.position, movePos, 0.2f);
                            if (transform.position.y >= movePos.y)
                            {
                                reach = true;
                            }
                        }
                        else
                        {
                            other1.SetActive(true);
                            other2.SetActive(true);
                            movingCounter -= 1;
                            transform.position = Vector2.MoveTowards(transform.position, oriPos, 0.4f);
                            if (movingCounter == 0)
                            {
                                moving = false;
                            }
                        }
                    }
                }

                if (reach)
                {
                    other1.SetActive(true);
                    other2.SetActive(true);
                    if (manager.theSeaweed.GetComponent<seaweed>().theProtein == null)
                    {
                        hurt.SetActive(true);
                        if (animCounter >= 20)
                        {
                            heart.health -= 1;
                            GameObject theRoe = Instantiate(roeProtein, transform.GetChild(0).position, Quaternion.Euler(0, 0, 0));
                            theRoe.GetComponent<SpriteRenderer>().sortingOrder = 5;
                            manager.theSeaweed.GetComponent<seaweed>().theProtein = theRoe;
                        }
                    }
                    if (animCounter < 20)
                    {
                        hurtEffect.SetActive(true);
                        roeAnim.SetActive(true);
                        animCounter += 1;
                        roeAnim.GetComponent<Animator>().Play("shoot");
                    }
                    else
                    {
                        hurtEffect.SetActive(false);
                        if (roeAnim.activeSelf)
                        {
                            roeAnim.GetComponent<Animator>().Play("empty");
                        }
                        roeAnim.SetActive(false);
                    }
                    //GetComponent<SpriteRenderer>().sprite = phase2;
                    if (animCounter >= 20)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, oriPos, 0.2f);
                    }
                    if (transform.position.y <= oriPos.y)
                    {
                        animCounter = 0;
                        hurt.SetActive(false);
                        reach = false;
                        moving = false;
                        movingCounter = 0;
                        GetComponent<SpriteRenderer>().sprite = phase1;
                    }
                }
            }

        }
        else if (manager.theSeaweed == null)
        {
            transform.position = Vector2.MoveTowards(transform.position, oriPos, 0.2f);
            reach = false;
            moving = false;
            movingCounter = 0;
            GetComponent<SpriteRenderer>().sprite = phase1;
            hurt.SetActive(false);
            other1.SetActive(true);
            other2.SetActive(true);
        }
    }
}
