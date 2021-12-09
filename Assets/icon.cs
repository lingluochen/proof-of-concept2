using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icon : MonoBehaviour
{
    public float counter;
    public bool picked;
    public gameManager gm;
    public GameObject self;
    public GameObject health;
    public bool meat;
    public float scale;
    public float scaleCounter;
    public bool startScaleCount;
    // Start is called before the first frame update
    void Start()
    {
        scale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (picked && !gm.picked)
        {
            if (counter == 0)
            {
                GameObject s = Instantiate(self, transform.position, Quaternion.Euler(0, 0, 0));
                pick p = s.AddComponent(typeof(pick)) as pick;
                p.beingPicked = true;
                gm.pickObj = s;
            }
            if (counter < 10)
            {

                counter += 1;
                transform.localScale = new Vector2(scale, scale);
                if (meat && counter == 1)
                {
                    GameObject.Find("Heart Manager").GetComponent<heartManager>().health -= 1;
                }

            }
            else
            {
                gm.picked = true;
                
                picked = false;
                counter = 0;
                startScaleCount = true;
            }
        }
        if (startScaleCount)
        {
            scaleCounter += 1;
            if (scaleCounter > 5)
            {
                scale += 0.15f;
                transform.localScale = new Vector2(scale, scale);
            }
            if (scale >= 1)
            {
                scale = 0;
                scaleCounter = 0;
                startScaleCount = false;
            }
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !gm.picked)
        {
            picked = true;
        }
    }
} 

