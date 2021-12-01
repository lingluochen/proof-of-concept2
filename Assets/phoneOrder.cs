using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneOrder : MonoBehaviour
{
    public float nextTime;
    public float timeCounter;
    public List<GameObject> proteins;
    public List<GameObject> rice;
    public List<GameObject> veggies;
    public Transform startPos;
    public List<GameObject> orders;
    public GameObject phoneObj;
    public bool opened;
    // Start is called before the first frame update
    void Start()
    {
        nextTime = Random.Range(1000, 1500);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (opened)
        {
            phoneObj.SetActive(true);
        }
        else
        {
            phoneObj.SetActive(false);
        }
        timeCounter += 1;
        if (timeCounter > nextTime)
        {
            timeCounter = 0;
            nextTime = Random.Range(1000, 1500);
            int num = Random.Range(3, 5);
            List<GameObject> ingres = new List<GameObject>();
            if (num == 3)
            {
                GameObject ingre1 = rice[Random.Range(0, rice.Count)];
                GameObject ingre2 = proteins[Random.Range(0, proteins.Count)];
                GameObject ingre3 = veggies[Random.Range(0, veggies.Count)];
                ingres.Add(ingre1);
                ingres.Add(ingre2);
                ingres.Add(ingre3);
            }
            else
            {
                GameObject ingre1 = rice[Random.Range(0, rice.Count)];
                GameObject ingre2 = proteins[Random.Range(0, proteins.Count)];
                int veggieIdx1 = Random.Range(0, veggies.Count);
                int veggieIdx2 = Random.Range(0, veggies.Count);
                while (veggieIdx1 == veggieIdx2)
                {
                    veggieIdx2 = Random.Range(0, veggies.Count);
                }
                GameObject ingre3 = veggies[veggieIdx1];
                GameObject ingre4 = veggies[veggieIdx2];
                ingres.Add(ingre1);
                ingres.Add(ingre2);
                ingres.Add(ingre3);
                ingres.Add(ingre4);
            }

            foreach (GameObject order in orders)
            {
                order.transform.position = new Vector2(order.transform.position.x, order.transform.position.y + 2.5f);
            }
            GameObject newSet = Instantiate(ingres[0], startPos.position, Quaternion.Euler(0, 0, 0));
            newSet.transform.parent = phoneObj.transform;
            newSet.GetComponent<SpriteRenderer>().sortingOrder = 2;
            for (int i = 1; i < ingres.Count; i++)
            {
                GameObject thisIngre = Instantiate(ingres[i], new Vector2(startPos.position.x + i * 2.5f, startPos.position.y), Quaternion.Euler(0, 0, 0));
                thisIngre.transform.parent = newSet.transform;
                thisIngre.GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
           
            orders.Add(newSet);

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
}
