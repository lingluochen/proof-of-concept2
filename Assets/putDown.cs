using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putDown : MonoBehaviour
{
    public gameManager gm;
    public bool canPut = true;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (gm.picked && Input.GetMouseButtonDown(0) && gm.pickObj != null && canPut && gm.pickObj.tag != "knife" && gm.pickObj.tag != "cooked")
        {
            gm.pickObj.GetComponent<pick>().beingPicked = false;
            gm.pickObj.transform.parent = this.gameObject.transform;
            gm.picked = false;
            gm.pickObj = null;
            audio.Play();
        }
    }


}
