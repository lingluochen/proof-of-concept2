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
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        putd = GetComponent<putDown>();
    }

    // Update is called once per frame
    void Update()
    {
        pickedObj = manager.pickObj;
        if (transform.childCount == 1 && manager.pickObj == null)
        {
            veggiePut = true;
        }
        else
        {
            veggiePut = false;
        }
        if (transform.childCount != 1)
        {
            putd.canPut = true;
        }
        else
        {
            putd.canPut = false;
            transform.GetChild(0).eulerAngles = new Vector3(0, 0, -45);
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
        if (inBoard && Input.GetMouseButtonDown(0) && putd.canPut)
        {
            pickedObj.transform.parent = transform;
        }
    }
}
