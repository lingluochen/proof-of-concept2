using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flatRice : MonoBehaviour
{
    public float scaleF;
    // Start is called before the first frame update
    void Start()
    {
        scaleF = 0.5f;
        transform.localScale = new Vector2(scaleF, scaleF);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (scaleF < 1f)
        {
            transform.localScale = new Vector2(scaleF, scaleF);
            scaleF += 0.08f;
        }
        else
        {
            scaleF = 1f;
            transform.localScale = new Vector2(scaleF, scaleF);
        }
    }
}
