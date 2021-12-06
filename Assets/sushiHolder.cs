﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sushiHolder : MonoBehaviour
{
    public List<string> ingredients;
    public gameManager manager;
    public List<GameObject> orderList;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        orderList = GameObject.Find("phone icon").GetComponent<phoneOrder>().orders;
        this.gameObject.tag = "sushi";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<pick>().beingPicked)
        {

            foreach(GameObject order in orderList)
            {
                bool match = true;
                List<string> orderIngres = order.GetComponent<orderReceipt>().ingredients;
                for (int i = 0; i < ingredients.Count; i++)
                {
                    if (!string.Equals(ingredients[i],orderIngres[i]))
                    {
                        match = false;
                    }
                }

                if (match)
                {
                    order.GetComponent<SpriteRenderer>().color = Color.red;
                    order.GetComponent<orderReceipt>().match = match;
                }
            }
        }
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && manager.pickObj == null && !manager.picked)
        {
            manager.pickObj = this.gameObject;
            manager.picked = true;
            GetComponent<pick>().beingPicked = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
