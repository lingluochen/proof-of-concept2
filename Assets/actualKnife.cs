using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actualKnife : MonoBehaviour
{
    public GameObject thisLine;
    public bool overLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cutline")
        {
            thisLine = collision.gameObject;
            collision.gameObject.GetComponent<cutLine>().over = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cutline")
        {
            if (thisLine != null)
            {
                collision.gameObject.GetComponent<cutLine>().over = false;
                thisLine = null;
            }
        }
    }
}
