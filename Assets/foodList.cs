using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodList : MonoBehaviour
{
    public List<GameObject> foods;
    public List<Vector2> foodPos;
    public Transform bound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        List<Vector2> tempFoodPos = new List<Vector2>();
        Vector2 initialPos = new Vector2(transform.position.x, bound.position.y);
        foreach (GameObject f in foods)
        {
            tempFoodPos.Add(initialPos);
            if (!f.GetComponent<cookedFood>().picked)
            {
                f.transform.position = initialPos;
            }
            initialPos = new Vector2(transform.position.x, initialPos.y + 1);
        }
        
    }
}
