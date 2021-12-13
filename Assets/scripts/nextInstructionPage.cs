using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextInstructionPage : MonoBehaviour
{

   
    public bool goNext;
    public instructions instru;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (!goNext)
        {
            if (instru.index <= 0)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            if (instru.index >= instru.SpriteList.Count - 1)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (goNext)
            {
                instru.index += 1;
                instru.gameObject.GetComponent<AudioSource>().Play();
            }
            else
            {
                instru.index -= 1;
                instru.gameObject.GetComponent<AudioSource>().Play();
            }
            if (instru.index > instru.SpriteList.Count - 1)
            {
                instru.index = instru.SpriteList.Count - 1;
            }else if (instru.index < 0)
            {
                instru.index = 0;
            }
        }
        
    }

    void OnMouseExit()
    {
        
    }
}
