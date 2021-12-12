using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneOrder : MonoBehaviour
{
    public float nextTime;
    public float timeCounter;
    public List<string> proteins;
    public List<string> rice;
    public List<string> veggies;
    public Transform startPos;
    public Vector2 thePos;
    public List<GameObject> orders;
    public bool opened;
    public GameObject order;
    public int numOfOrders = 0;
    public List<Vector2> orderPos;
    
    // Start is called before the first frame update
    void Start()
    {
        nextTime = Random.Range(1000, 1500);
        

    }

    // Update is called once per frame
    void Update()
    {
        thePos = startPos.position;
    }

    private void FixedUpdate()
    {
        
        if (orders.Count < 3)
        {
            timeCounter += 1;
            if (timeCounter > nextTime)
            {
                timeCounter = 0;
                nextTime = Random.Range(1000, 1500);

                int riceIdx = Random.Range(0, rice.Count);
                string ingre1 = rice[riceIdx];
                int veggieIdx = Random.Range(0, veggies.Count);
                string ingre2 = veggies[veggieIdx];
                int proteinIdx = Random.Range(0, proteins.Count);
                string ingre3 = proteins[proteinIdx];

                GameObject newOrder = new GameObject();

                if (orderPos.Count > 0)
                {
                    newOrder = Instantiate(order, new Vector2(orderPos[orderPos.Count - 1].x + 5.1f, transform.position.y + 5), Quaternion.Euler(0, 0, 0));
                }
                else
                {
                    newOrder = Instantiate(order, new Vector2(transform.position.x, transform.position.y + 5), Quaternion.Euler(0, 0, 0));
                }
                newOrder.GetComponent<orderReceipt>().riceIdx = riceIdx;
                newOrder.GetComponent<orderReceipt>().veggieIdx = veggieIdx;
                newOrder.GetComponent<orderReceipt>().proteinIdx = proteinIdx;

                newOrder.GetComponent<orderReceipt>().riceName = ingre1;
                newOrder.GetComponent<orderReceipt>().veggieName = ingre2;
                newOrder.GetComponent<orderReceipt>().proteinName = ingre3;

                newOrder.transform.parent = transform;
                newOrder.GetComponent<SpriteRenderer>().sortingOrder = 2;

                orders.Add(newOrder);



            }

            

        }
        else
        {
            timeCounter = 0;
        }


        Vector2 newPos = thePos;
        List<Vector2> tempOrderPos = new List<Vector2>();
        foreach (GameObject order in orders)
        {
            tempOrderPos.Add(newPos);
            newPos = new Vector2(newPos.x + 5.1f, thePos.y);
        }
        orderPos = tempOrderPos;
        for (int i = 0; i < orders.Count; i++)
        {
            orders[i].GetComponent<orderReceipt>().index = i;
            orders[i].transform.position = Vector2.MoveTowards(orders[i].transform.position, orderPos[i], 0.4f);
        }

    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!opened)
            {
                opened = true;
            }
            else
            {
                opened = false;
            }
        }
    }


    public void redoList()
    {
        List<GameObject> tempOrders = new List<GameObject>();
        foreach(GameObject order in orders)
        {
            if (order != null)
            {
                tempOrders.Add(order);
            }
        }
        orders.Clear();
        foreach(GameObject order in tempOrders)
        {
            orders.Add(order);
        }
    }
}
