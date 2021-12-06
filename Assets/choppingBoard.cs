using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choppingBoard : MonoBehaviour
{
    public putDown putd;
    public gameManager manager;
    public GameObject pickedObj;
    public bool veggiePut;
    public GameObject putVeggie;
    public bool inBoard;
    public bool generateLine;
    public GameObject line;
    public GameObject theLine;
    public float cutCounter;
    public bool startCount;
    public GameObject cCarrot;
    public GameObject cCucumber;
    public GameObject cAvocado;
    public GameObject cRadish;
    public bool startServing;
    public GameObject choppedVeggie;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        putd = GetComponent<putDown>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pickedObj = manager.pickObj;
        if (transform.childCount != 1)
        {
            putd.canPut = true;
            veggiePut = false;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            putd.canPut = false;
            transform.GetChild(0).eulerAngles = new Vector3(0, 0, -45);
            putVeggie = transform.GetChild(0).gameObject;
            veggiePut = true;
            GetComponent<BoxCollider2D>().enabled = false;
            if (generateLine)
            {
                theLine = Instantiate(line, transform.GetChild(0).position, Quaternion.Euler(0, 0, 0));
                generateLine = false;
            }
            if (theLine != null)
            {
                bool allCut = true;
                foreach (Transform child in theLine.transform)
                {
                    if (!child.gameObject.GetComponent<cutLine>().beingCut)
                    {
                        allCut = false;
                        break;
                    }
                }
                if (allCut)
                {
                    startCount = true;
                }
            }
        }

        if (startCount)
        {
            cutCounter += 1;
            if (cutCounter > 20)
            {
                GameObject thisV = transform.GetChild(0).gameObject;
                if (thisV.name.Contains("carrot"))
                {
                    choppedVeggie = Instantiate(cCarrot, thisV.transform.position, Quaternion.Euler(0, 0, 0));
                }else if (thisV.name.Contains("cucumber"))
                {
                    choppedVeggie = Instantiate(cCucumber, thisV.transform.position, Quaternion.Euler(0, 0, 0));
                }else if (thisV.name.Contains("avocado"))
                {
                    choppedVeggie = Instantiate(cAvocado, thisV.transform.position, Quaternion.Euler(0, 0, 0));
                }else if (thisV.name.Contains("radish"))
                {
                    choppedVeggie = Instantiate(cRadish, thisV.transform.position, Quaternion.Euler(0, 0, 0));
                }
                Destroy(theLine);
                Destroy(transform.GetChild(0).gameObject);
                theLine = null;
                cutCounter = 0;
                startCount = false;
                startServing = true;
            }
        }

        if (startServing)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            if (choppedVeggie.GetComponent<pick>().beingPicked)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                startServing = false;
                putVeggie = null;
            }
        }

    }

    private void OnMouseEnter()
    {
        if (pickedObj != null && pickedObj.tag != "cooked" && transform.childCount == 0)
        {
            inBoard = true;
        }
    }

    private void OnMouseExit()
    {
        if (pickedObj != null && pickedObj.tag != "cooked")
        {
            inBoard = false;
        }
    }

    private void OnMouseOver()
    {
        if (inBoard && Input.GetMouseButtonDown(0) && putd.canPut && pickedObj.tag != "knife")
        {
            pickedObj.transform.parent = transform;
            generateLine = true;
        }
    }
}
