using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour
{
    public gameManager manager;
    public List<GameObject> orders;
    public GameObject theOrder;
    public bool sendOrder;
    public float sendCounter;
    public int idx;
    public bool doOnce;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        orders = GameObject.Find("phone icon").GetComponent<phoneOrder>().orders;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sendOrder)
        {
            sendCounter += 1;
            
            if (!doOnce)
            {
                orders[idx] = null;
                manager.thePlate = null;
                theOrder.GetComponent<orderReceipt>().moving = true;
                GameObject.Find("phone icon").GetComponent<phoneOrder>().redoList();
                doOnce = true;
            }
            
            transform.Translate(new Vector2(0, 0.5f));
            
            if (sendCounter > 50)
            {
                
                Destroy(this.gameObject);
            }
        }
        else
        {
            int tempIdx = 0;
            foreach (GameObject order in orders)
            {
                if (order.GetComponent<orderReceipt>().match)
                {
                    idx = tempIdx;
                    theOrder = order;
                    break;
                }
                tempIdx += 1;
            }
        }
    }

    private void OnMouseOver()
    {
        if (manager.pickObj != null && manager.pickObj.tag == "sushi" && Input.GetMouseButtonDown(0))
        {
            if (theOrder != null)
            {
                GameObject thisSushi = manager.pickObj;
                manager.pickObj = null;
                manager.picked = false;
                thisSushi.GetComponent<pick>().beingPicked = false;
                thisSushi.transform.parent = transform;
                thisSushi.transform.localPosition = new Vector2(0, 0);
                sendOrder = true;
            }

        }
    }
}
