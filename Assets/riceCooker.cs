using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riceCooker : MonoBehaviour
{
    public putDown putd;
    public bool cooking;
    public float cookingTimer;
    public float maxCookTime;
    public Transform bar;
    public float initialScale;
    public GameObject cookedWhite;
    public GameObject cookedBrown;
    public GameObject cookedRice;
    // Start is called before the first frame update
    void Start()
    {
        putd = GetComponent<putDown>();
        cookingTimer = 0;
        initialScale = bar.localScale.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cooking)
        {
            putd.canPut = false;
            if (cookingTimer == 0)
            {
                bar.localScale = new Vector2(initialScale, bar.localScale.y);
            }
            else if (cookingTimer <= maxCookTime && cookedRice == null)
            {
                float reduceAmount = initialScale / maxCookTime;
                float newScaleX = bar.localScale.x - reduceAmount;
                bar.localScale = new Vector2(newScaleX, bar.localScale.y);
            }
            else if (cookedRice != null)
            {
                bar.localScale = new Vector2(0, bar.localScale.y);
            }
            if (cookingTimer < maxCookTime)
            {
                cookingTimer += 1;
                if (cookingTimer == maxCookTime - 1)
                {
                    if (this.gameObject.transform.GetChild(1) != null)
                    {
                        GameObject thisRice = this.gameObject.transform.GetChild(1).gameObject;
                        if (thisRice.name.Contains("white"))
                        {
                            cookedRice = Instantiate(cookedWhite, transform.position, Quaternion.Euler(0, 0, 0));
                        }
                        else
                        {
                            cookedRice = Instantiate(cookedBrown, transform.position, Quaternion.Euler(0, 0, 0));
                        }
                        Destroy(thisRice);
                        
                    }
                }
            }
            else if (cookedRice == null)
            {
                cookingTimer = 0;
                cooking = false;
            }
        }
        else
        {
            putd.canPut = true;
            bar.localScale = new Vector2(0, bar.localScale.y);
        }
        int childCount = transform.childCount;
        if (childCount > 1)
        {
            cooking = true;
        }
        if (cookedRice != null)
        {
            if (cookedRice.GetComponent<pick>().beingPicked)
            {
                cookedRice = null;
            }
        }
    }
}
