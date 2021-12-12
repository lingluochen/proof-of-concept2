using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seaweed : MonoBehaviour
{
    public bool hasRice;
    public gameManager manager;
    public bool hasVeggie;
    public bool hasProtein;
    public foodList riceList;
    public foodList veggieList;
    public GameObject flatWhite;
    public GameObject flatBrown;
    public GameObject theFlat;
    public List<GameObject> veggies;
    public GameObject theVeggie;
    public GameObject theProtein;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        riceList = GameObject.Find("rice list").GetComponent<foodList>();
        veggieList = GameObject.Find("veggie list").GetComponent<foodList>();
    }

    // Update is called once per frame
    void Update()
    {
        if (theProtein != null)
        {
            theProtein.transform.parent = transform;
            //manager.pickObj.GetComponent<cookedFood>().picked = false;
            hasProtein = true;
        }
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (manager.pickObj != null && manager.pickObj.name.Contains("rice") && !hasRice)
            {
                manager.pickObj.transform.parent = transform;
                manager.pickObj.GetComponent<cookedFood>().picked = false;
                manager.pickObj.GetComponent<pick>().beingPicked = false;
                GameObject tempRice = manager.pickObj;
                //riceList.foods.RemoveAt(manager.pickObj.GetComponent<cookedFood>().index);
                if (manager.pickObj.name.Contains("white"))
                {
                    theFlat = Instantiate(flatWhite, transform.position, Quaternion.Euler(0, 0, 0));
                }
                else
                {
                    theFlat = Instantiate(flatBrown, transform.position, Quaternion.Euler(0, 0, 0));
                }
                theFlat.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
                manager.pickObj = null;
                manager.picked = false;
                hasRice = true;
                Destroy(tempRice);
            }

            if (manager.pickObj != null && manager.pickObj.name.Contains("chopped") && hasRice && !hasVeggie)
            {
                manager.pickObj.transform.parent = transform;
                manager.pickObj.GetComponent<cookedFood>().picked = false;
                manager.pickObj.GetComponent<pick>().beingPicked = false;
                //veggieList.foods.RemoveAt(manager.pickObj.GetComponent<cookedFood>().index);
                GameObject tempVeggie = manager.pickObj;
                if (manager.pickObj.name.Contains("avocado"))
                {
                    theVeggie = Instantiate(veggies[0], transform.GetChild(0).position, Quaternion.Euler(0, 0, 0));
                }
                else if (manager.pickObj.name.Contains("carrot"))
                {
                    theVeggie = Instantiate(veggies[1], transform.GetChild(0).position, Quaternion.Euler(0, 0, 0));
                }
                else if (manager.pickObj.name.Contains("cucumber"))
                {
                    theVeggie = Instantiate(veggies[2], transform.GetChild(0).position, Quaternion.Euler(0, 0, 0));
                }
                else if (manager.pickObj.name.Contains("radish"))
                {
                    theVeggie = Instantiate(veggies[3], transform.GetChild(0).position, Quaternion.Euler(0, 0, 0));
                }
                manager.pickObj = null;
                manager.picked = false;
                hasVeggie = true;
                Destroy(tempVeggie);
            }
            /*
            if (manager.pickObj != null && manager.pickObj.name.Contains("protein") && hasRice && !hasProtein)
            {
                theProtein = manager.pickObj;
                
            }
            */
        }
    }


}
