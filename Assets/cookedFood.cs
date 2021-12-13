using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookedFood : MonoBehaviour
{
    public bool picked;
    public gameManager manager;
    public int index;
    public GameObject audio;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        audio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (picked)
        {
            GetComponent<pick>().beingPicked = true;
            GetComponent<BoxCollider2D>().enabled = false;
            audio.SetActive(true);
        }
        else
        {
            GetComponent<pick>().beingPicked = false;
            GetComponent<BoxCollider2D>().enabled = true;
            audio.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !manager.picked && !manager.manualOpen)
        {
            picked = true;
            manager.picked = true;
            manager.pickObj = this.gameObject;
        }
    }
}
