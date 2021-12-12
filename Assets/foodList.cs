using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodList : MonoBehaviour
{
    public List<GameObject> foods;
    public Transform bound;
    public int index;
    public int validVeggieNum;
    public List<veggiePlate> plates;
    // Start is called before the first frame update
    void Start()
    {
        int t = 0;
        foreach (veggiePlate plate in plates)
        {
            plate.index = t;
            t += 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        List<Vector2> tempFoodPos = new List<Vector2>();
        Vector2 initialPos = new Vector2(transform.position.x, bound.position.y);
        int tempIdx = 0;
        int validNum = 0;
        foreach (GameObject f in foods)
        {
            /*
            if (f == null)
            {
                redoList();
                break;
            }
            */
            plates[tempIdx].myVeggie = f;
            tempIdx += 1;
            
            if (f != null)
            {
                validNum += 1;
            }
            
        }
        validVeggieNum = validNum;

    }

    /*
    public void redoList()
    {
        List<GameObject> tempList = new List<GameObject>();
        foreach (GameObject obj in foods)
        {
            if (obj != null)
            {
                tempList.Add(obj);
            }
        }
        foods.Clear();
        foreach (GameObject obj in tempList)
        {
            foods.Add(obj);
        }
    }
    */
}
