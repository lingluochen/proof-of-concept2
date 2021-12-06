using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick : MonoBehaviour
{
    public bool beingPicked;
    public bool manualOrder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beingPicked)
        {
            if (GetComponent<SpriteRenderer>() != null && !manualOrder)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 10;
            }
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            transform.position = worldPosition;
        }
    }
}
