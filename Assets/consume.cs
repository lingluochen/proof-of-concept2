using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consume : MonoBehaviour
{
    public gameManager manager;
    public bool eating;
    public float eatCounter;
    public Vector2 eatPos;
    public Vector2 oriPos;
    public heartManager heart;
    public wrapController theWrapper;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        oriPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (eating)
        {
            eatCounter += 1;
            if (eatCounter < 30)
            {
                transform.position = Vector2.MoveTowards(transform.position, eatPos, 0.4f);
            }
            else
            {
                if (transform.childCount > 0)
                {
                    Destroy(transform.GetChild(0).gameObject);
                    heart.health += 3;
                }
                transform.position = Vector2.MoveTowards(transform.position, oriPos, 0.4f);
            }
            if (eatCounter > 70)
            {
                eatCounter = 0;
                eating = false;
            }
        }
    }


    private void OnMouseOver()
    {
        if (manager.pickObj != null && manager.pickObj.tag == "sushi" && Input.GetMouseButtonDown(0))
        {
            GameObject theSushi = manager.pickObj;
            theSushi.GetComponent<pick>().beingPicked = false;
            manager.pickObj = null;
            manager.picked = false;
            theSushi.transform.position = transform.position;
            theSushi.transform.parent = transform;
            eating = true;
            manager.generateSeaweed();
            theWrapper.startScroll = false;
            theWrapper.scrollCounter = 0;
        }
    }
}
