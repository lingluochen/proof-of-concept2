using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veggiePlate : MonoBehaviour
{
    public GameObject myVeggie;
    public int index;
    public gameManager manager;
    public bool veggieList;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myVeggie != null && !myVeggie.GetComponent<pick>().beingPicked)
        {
            transform.parent.GetComponent<foodList>().foods[index] = myVeggie;
            myVeggie.transform.position = this.gameObject.transform.position;
            GetComponent<BoxCollider2D>().enabled = false;
            
        }else if (myVeggie != null && myVeggie.GetComponent<pick>().beingPicked)
        {
            myVeggie = null;
            transform.parent.GetComponent<foodList>().foods[index] = null;
            GetComponent<BoxCollider2D>().enabled = true;
        }else if (myVeggie == null)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnMouseOver()
    {
        if (manager.pickObj != null && manager.pickObj.tag == "cooked" && Input.GetMouseButtonDown(0) && myVeggie == null)
        {
            string type = "rice";
            if (veggieList)
            {
                type = "chopped";
            }
            if (manager.pickObj.name.Contains(type))
            {
                manager.pickObj.GetComponent<cookedFood>().picked = false;
                myVeggie = manager.pickObj;
                manager.pickObj = null;
                manager.picked = false;
                myVeggie.GetComponent<pick>().beingPicked = false;
            }
        }
    }

}
