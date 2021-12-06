using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actualKnife : MonoBehaviour
{
    public GameObject thisLine;
    public LayerMask layers;
    public bool hitLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 3f, layers);
        Debug.DrawRay(transform.position, transform.up * 3f, Color.white);
        if (hit)
        {
            hitLine = true;
            thisLine = hit.transform.gameObject;
            thisLine.GetComponent<cutLine>().over = true;
            if (Input.GetMouseButtonDown(0))
            {
                thisLine.GetComponent<cutLine>().beingCut = true;
            }
        }
        else
        {
            hitLine = false;
            if (thisLine != null)
            {
                thisLine.GetComponent<cutLine>().over = false;
            }
            thisLine = null;
            
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("2");
        if (collision.gameObject.tag == "cutline")
        {
            Debug.Log("1");
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
    */
}
