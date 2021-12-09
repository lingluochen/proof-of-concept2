using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCan : MonoBehaviour
{
    public gameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnMouseOver()
    {
        if (manager.picked && manager.pickObj != null && Input.GetMouseButtonDown(0))
        {
            manager.picked = false;
            GameObject theObj = manager.pickObj;
            manager.pickObj = null;
            Destroy(theObj);

        }
    }
}
