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
    public AudioSource audio;
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
        if (connectedList.validVeggieNum < 3)
        {

        }
        else
        {

        }
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
                        if (!audio.isPlaying)
                        {
                            audio.Play();
                        }
                    }
                    else
                    {
                        foodOut = true;
                        changeState("still");
                        audio.Stop();
                    }
                }
                else
                {
                    if (theFood.transform.position.x < bound.transform.position.x)
                    {
                        theFood.transform.Translate(new Vector2(spd / 2, 0));
                        changeState("moving");
                        if (!audio.isPlaying)
                        {
                            audio.Play();
                        }
                    }
                    else
                    {
                        foodOut = true;
                        changeState("still");
                        audio.Stop();
                    }
                }
            }
        }

        if (foodOut)
        {
            receivedFood = false;
            for (int i = 0; i < connectedList.foods.Count; i++)
            {
                if (connectedList.foods[i] == null)
                {
                    connectedList.foods[i] = theFood;
                    break;
                }
            }
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
        if (manager.picked && manager.pickObj.tag == "cooked" && connectedList.validVeggieNum < 3)
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
