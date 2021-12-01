using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookedFood : MonoBehaviour
{
    public bool picked;
    public gameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (picked)
        {
            GetComponent<pick>().beingPicked = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<pick>().beingPicked = false;
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !manager.picked)
        {
            picked = true;
            manager.picked = true;
            manager.pickObj = this.gameObject;
        }
    }
}
