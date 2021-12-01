using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public gameManager manager;
    public GameObject actualKnife;
    public bool inArea;
    // Start is called before the first frame update
    void Start()
    {
        actualKnife = transform.GetChild(0).gameObject;
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseOver()
    {
        if (inArea && Input.GetMouseButtonDown(0))
        {
            actualKnife.AddComponent<pick>();
            actualKnife.GetComponent<pick>().beingPicked = true;
            manager.picked = true;
            manager.pickObj = actualKnife;
            actualKnife.transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }

    private void OnMouseEnter()
    {
        if (!manager.picked && !manager.pickObj) { 
            inArea = true; 
        }
    }

    private void OnMouseExit()
    {
        if (!manager.picked && !manager.pickObj)
        {
            inArea = false;
        }
    }
}
