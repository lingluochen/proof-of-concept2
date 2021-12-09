using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodList : MonoBehaviour
{
    public List<GameObject> foods;
    public List<Vector2> foodPos;
    public Transform bound;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        List<Vector2> tempFoodPos = new List<Vector2>();
        Vector2 initialPos = new Vector2(transform.position.x, bound.position.y);
        int tempIdx = 0;
        foreach (GameObject f in foods)
        {
            if (f == null)
            {
                redoList();
                break;
            }
            f.GetComponent<cookedFood>().index = tempIdx;
            tempIdx += 1;
            tempFoodPos.Add(initialPos);
            if (!f.GetComponent<cookedFood>().picked)
            {
                f.transform.position = initialPos;
            }
            initialPos = new Vector2(transform.position.x, initialPos.y + 1);
        }
        
    }


    public void redoList()
    {
        List<GameObject> tempList = new List<GameObject>();
        foreach(GameObject obj in foods)
        {
            if (obj != null)
            {
                tempList.Add(obj);
            }
        }
        foods.Clear();
        foreach(GameObject obj in tempList)
        {
            foods.Add(obj);
        }
    }
}
