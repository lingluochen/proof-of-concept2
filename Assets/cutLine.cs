using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutLine : MonoBehaviour
{
    public bool over;
    public bool beingCut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (over)
        {
            if (!beingCut)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (beingCut)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("3");
    }
}
