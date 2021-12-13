using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public gameManager manager;
    public GameObject actualKnife;
    public bool inArea;
    public bool knifePicked;
    public bool dontRotate;
    public AudioSource pick;
    public AudioSource put;
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

    private void FixedUpdate()
    {

    }

    private void OnMouseOver()
    {
        if (inArea && Input.GetMouseButtonDown(0))
        {
            if (!knifePicked)
            {
                pick.Play();
                actualKnife.AddComponent<pick>();
                actualKnife.GetComponent<pick>().beingPicked = true;
                actualKnife.GetComponent<pick>().manualOrder = true;
                actualKnife.GetComponent<SpriteRenderer>().sortingOrder = 30;
                manager.picked = true;
                manager.pickObj = actualKnife;
                if (!dontRotate)
                {
                    actualKnife.transform.eulerAngles = new Vector3(0, 0, 90);
                }
                knifePicked = true;
            }
            else
            {
                put.Play();
                Destroy(actualKnife.GetComponent<pick>());
                manager.picked = false;
                manager.pickObj = null;
                actualKnife.transform.eulerAngles = new Vector3(0, 0, 0);
                actualKnife.transform.position = transform.position;
                knifePicked = false;
            }
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
