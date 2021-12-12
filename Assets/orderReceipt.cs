using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderReceipt : MonoBehaviour
{
    public List<GameObject> rices;
    public List<GameObject> veggies;
    public List<GameObject> proteins;
    public List<GameObject> riceRoll;
    public List<GameObject> veggieRoll;
    public List<GameObject> proteinRoll;
    public int riceIdx;
    public int veggieIdx;
    public int proteinIdx;
    public string riceName;
    public string veggieName;
    public string proteinName;
    public List<string> ingredients;
    public bool match;
    public bool moving;
    public float movingCounter;
    public GameObject r;
    public GameObject v;
    public GameObject p;
    public GameObject roll;
    public GameObject bar;
    public float maxCounter;
    public float counter;
    public float scale;
    public List<GameObject> orders;
    public int index;
    public GameObject theSushi;
    // Start is called before the first frame update
    void Start()
    {
        orders = GameObject.Find("phone icon").GetComponent<phoneOrder>().orders;
        GameObject theRice = Instantiate(rices[riceIdx], transform.GetChild(0).position, Quaternion.Euler(0, 0, 0));
        GameObject theVeggie = Instantiate(veggies[veggieIdx], transform.GetChild(1).position, Quaternion.Euler(0, 0, 0));
        GameObject theProtein = Instantiate(proteins[proteinIdx], transform.GetChild(2).position, Quaternion.Euler(0, 0, 0));
        GameObject theRoll = Instantiate(riceRoll[riceIdx], transform.GetChild(3).position, Quaternion.Euler(0, 0, 0));
        r = theRice;
        v = theVeggie;
        p = theProtein;
        roll = theRoll;
        theRice.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
        theVeggie.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
        theProtein.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
        theRoll.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 2;
        theRice.transform.localScale = new Vector2(0.4f, 0.4f);
        theVeggie.transform.localScale = new Vector2(0.4f, 0.4f);
        theProtein.transform.localScale = new Vector2(0.4f, 0.4f);
        theRice.transform.parent = transform;
        theVeggie.transform.parent = transform;
        theProtein.transform.parent = transform;
        theRoll.transform.parent = transform;
        GameObject veggieFill = Instantiate(veggieRoll[veggieIdx], theRice.transform.position, Quaternion.Euler(0, 0, 0));
        GameObject proteinFill = Instantiate(proteinRoll[proteinIdx], theRice.transform.position, Quaternion.Euler(0, 0, 0));
        veggieFill.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
        proteinFill.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
        veggieFill.transform.parent = theRoll.transform;
        proteinFill.transform.parent = theRoll.transform;
        veggieFill.transform.localPosition = new Vector2(0, 0);
        proteinFill.transform.localPosition = new Vector2(0, 0);
        theRoll.transform.localScale = new Vector2(0.5f, 0.5f);
        ingredients.Add(riceName);
        ingredients.Add(veggieName);
        ingredients.Add(proteinName);
        counter = maxCounter;
        scale = bar.transform.localScale.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            transform.Translate(new Vector2(0, 0.5f));
            movingCounter += 1;
            GetComponent<SpriteRenderer>().sortingOrder = 90;
            r.GetComponent<SpriteRenderer>().sortingOrder = 91;
            v.GetComponent<SpriteRenderer>().sortingOrder = 91;
            p.GetComponent<SpriteRenderer>().sortingOrder = 91;

            if (movingCounter > 50){
                Destroy(this.gameObject);
            }
        }

        if (counter > 0)
        {
            counter -= 1;
            bar.transform.localScale = new Vector2((counter / maxCounter) * scale, bar.transform.localScale.y);
        }
        else
        {
            counter -= 1;
            fade(this.gameObject);
            foreach (Transform child in transform)
            {
                if (child.gameObject.GetComponent<SpriteRenderer>() != null)
                {
                    fade(child.gameObject);
                }
            }
            foreach(Transform child in roll.transform)
            {
                if (child.gameObject.GetComponent<SpriteRenderer>() != null)
                {
                    fade(child.gameObject);
                }
            }
            if (counter < -30)
            {
                orders[index] = null;
                GameObject.Find("phone icon").GetComponent<phoneOrder>().redoList();
                Destroy(this.gameObject);
            }
        }
        
        if (counter < maxCounter / 5)
        {
            bar.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (theSushi == null)
        {
            match = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        
    }

    void fade(GameObject obj)
    {
        var c = obj.GetComponent<SpriteRenderer>().color;
        c.a -= 0.05f;
        obj.GetComponent<SpriteRenderer>().color = c;
    }
}
