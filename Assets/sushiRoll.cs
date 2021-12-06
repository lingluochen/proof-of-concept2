using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sushiRoll : MonoBehaviour
{
    public List<string> ingredientNames;
    public bool setUpIngre;
    public List<GameObject> rices;
    public List<GameObject> veggies;
    public List<GameObject> proteins;
    public GameObject theRice;
    public GameObject theVeggie;
    public GameObject theProtein;
    public float counter;
    public GameObject lines;
    public GameObject theLine;
    public bool showLines;
    public bool allCut;
    public float cutCounter;
    public GameObject theSushi;
    public List<string> riceNames;
    public List<string> veggieNames;
    public List<string> proteinNames;
    public List<string> ingredients;
    public Sprite brownRoll;
    public Sprite carrotSR;
    public Sprite cucumberSR;
    public Sprite radishSR;
    public Sprite hokkikaiSR;
    public Sprite roeSR;
    public SpriteRenderer veggieSR;
    public SpriteRenderer proteinSR;
    // Start is called before the first frame update
    void Start()
    {
        veggieSR = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        proteinSR = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!setUpIngre)
        {
            //get rice
            if (ingredientNames[0].Contains("white")){
                theRice = rices[0];
                ingredients.Add(riceNames[0]);
            }
            else
            {
                theRice = rices[1];
                ingredients.Add(riceNames[1]);
                GetComponent<SpriteRenderer>().sprite = brownRoll;
            }

            if (ingredientNames[1].Contains("avo"))
            {
                theVeggie = veggies[0];
                ingredients.Add(veggieNames[0]);
            }
            else if (ingredientNames[1].Contains("carr"))
            {
                theVeggie = veggies[1];
                ingredients.Add(veggieNames[1]);
                veggieSR.sprite = carrotSR;
            }
            else if (ingredientNames[1].Contains("cucum"))
            {
                theVeggie = veggies[2];
                ingredients.Add(veggieNames[2]);
                veggieSR.sprite = cucumberSR;
            }
            else
            {
                theVeggie = veggies[3];
                ingredients.Add(veggieNames[3]);
                veggieSR.sprite = radishSR;
            }

            if (ingredientNames[2].Contains("ten"))
            {
                theProtein = proteins[0];
                ingredients.Add(proteinNames[0]);
            }
            else if (ingredientNames[2].Contains("hok"))
            {
                theProtein = proteins[1];
                ingredients.Add(proteinNames[1]);
                proteinSR.sprite = hokkikaiSR;
            }
            else
            {
                theProtein = proteins[2];
                ingredients.Add(proteinNames[2]);
                proteinSR.sprite = roeSR;
            }

            setUpIngre = true;
        }

        if (!showLines)
        {

            if (counter < 20)
            {
                counter += 1;
            }
            else
            {
                theLine = Instantiate(lines, transform.position, Quaternion.Euler(0, 0, 0));
                theLine.transform.parent = transform;
                showLines = true;
            }
        }

        if (theLine != null)
        {
            bool tempAllCut = true;
            foreach (Transform child in theLine.transform)
            {
                if (!child.gameObject.GetComponent<cutLine>().beingCut)
                {
                    tempAllCut = false;
                    break;
                }
            }
            allCut = tempAllCut;
        }

        if (allCut)
        {
            
            if (cutCounter > 20)
            {
                Destroy(theLine);
                theLine = null;
                theSushi = new GameObject("sushi holder");
                theSushi.AddComponent<sushiHolder>();
                theSushi.GetComponent<sushiHolder>().ingredients = ingredients;
                BoxCollider2D box = theSushi.AddComponent<BoxCollider2D>();
                box.offset = new Vector2(0.3f, 0);
                box.size = new Vector2(6, 1);
                box.isTrigger = true;
                theSushi.AddComponent<pick>();
                float xPos = -1.9f;
                int order = GetComponent<SpriteRenderer>().sortingOrder + 10;
                for (int i = 0; i < 6; i++)
                {
                    GameObject thisSushi = Instantiate(theRice, new Vector2(xPos, transform.position.y), Quaternion.Euler(0, 0, 0));
                    GameObject thisVeggie = Instantiate(theVeggie, thisSushi.transform.position, Quaternion.Euler(0, 0, 0));
                    GameObject thisProtein = Instantiate(theProtein, thisSushi.transform.position, Quaternion.Euler(0, 0, 0));
                    thisSushi.GetComponent<SpriteRenderer>().sortingOrder = order;
                    thisVeggie.GetComponent<SpriteRenderer>().sortingOrder = order - 1;
                    thisProtein.GetComponent<SpriteRenderer>().sortingOrder = order - 1;
                    order -= 1;
                    xPos += 0.936f;
                    thisVeggie.transform.parent = thisSushi.transform;
                    thisProtein.transform.parent = thisSushi.transform;
                    thisSushi.transform.localScale = new Vector2(0.4f, 0.4f);
                    thisSushi.transform.parent = theSushi.transform;
                }
                allCut = false;
                Destroy(this.gameObject);
            }
            else
            {
                cutCounter += 1;
            }
        }

    }
}
