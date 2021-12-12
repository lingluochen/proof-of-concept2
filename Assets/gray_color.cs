using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gray_color : MonoBehaviour
{
    public Sprite ori;
    public Sprite gray;
    public gameManager manager;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ori = sr.sprite;
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (manager.theSeaweed == null)
        {
            sr.sprite = gray;
        }else if (!manager.theSeaweed.GetComponent<seaweed>().hasRice || manager.theSeaweed.GetComponent<seaweed>().hasProtein)
        {
            sr.sprite = gray;
        }
        else
        {
            sr.sprite = ori;
        }
    }
}
