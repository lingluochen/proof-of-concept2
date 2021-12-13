using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutLine : MonoBehaviour
{
    public bool over;
    public bool beingCut;
    public GameObject cutAudio;
    // Start is called before the first frame update
    void Start()
    {
        cutAudio = transform.GetChild(0).gameObject;
        cutAudio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (over)
        {
            if (!beingCut)
            {
                GetComponent<SpriteRenderer>().color = new Color32(225,178,102,225);
            }
        }
        else
        {
            if (!beingCut)
            {
                GetComponent<SpriteRenderer>().color = new Color32(225, 102, 102, 225);
            }
        }

        if (beingCut)
        {
            GetComponent<SpriteRenderer>().color = new Color32(153, 255, 153, 225); //green
            cutAudio.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("3");
    }
}
