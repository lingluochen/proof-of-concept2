using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beltController : MonoBehaviour
{
    public bool detectedFood;
    public bool receivedFood;
    public GameObject belt;
    public gameManager manager;
    public float counter;
    public float maxCounter;
    public bool moveLeft;
    public float spd;
    public GameObject theFood;
    public Transform bound;
    public bool foodOut;
    public foodList connectedList;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        belt = transform.GetChild(0).gameObject;
        bound = transform.GetChild(1);
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        if (moveLeft)
        {
            spd = -spd;
        }
        anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        changeState("still");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (detectedFood)
        {
            if (counter < maxCounter)
            {
                counter += 1;
                belt.transform.Translate(new Vector2(spd, 0));
            }
            if (receivedFood)
            {
                if (manager.pickObj != null)
                {
                    theFood = manager.pickObj;

                }
                theFood.transform.parent = belt.transform;
                manager.pickObj = null;
                manager.picked = false;
                theFood.GetComponent<cookedFood>().picked = false;
                detectedFood = false;
            }
        }
        else
        {
            if (counter > 0)
            {
                counter -= 1;
                belt.transform.Translate(new Vector2(-spd, 0));
            }
            if (receivedFood)
            {
                if (!moveLeft)
                {
                    if (theFood.transform.position.x > bound.transform.position.x)
                    {
                        theFood.transform.Translate(new Vector2(-spd / 2, 0));
                        changeState("moving");
                    }
                    else
                    {
                        foodOut = true;
                        changeState("still");
                    }
                }
                else
                {
                    if (theFood.transform.position.x < bound.transform.position.x)
                    {
                        theFood.transform.Translate(new Vector2(spd / 2, 0));
                        changeState("moving");
                    }
                    else
                    {
                        foodOut = true;
                        changeState("still");
                    }
                }
            }
        }

        if (foodOut)
        {
            receivedFood = false;
            connectedList.foods.Add(theFood);
            theFood = null;
            foodOut = false;

        }

    }


    private void OnMouseOver()
    {
        if (detectedFood)
        {
            if (Input.GetMouseButtonDown(0))
            {
                receivedFood = true;
            }
        }
    }

    private void OnMouseEnter()
    {
        if (manager.picked && manager.pickObj.tag == "cooked")
        {
            detectedFood = true;

        }
    }

    private void OnMouseExit()
    {
        if (manager.picked && manager.pickObj.tag == "cooked")
        {
            detectedFood = false;
        }
    }


    public void changeState(string target)
    {
        anim.Play(target);
    }
}
