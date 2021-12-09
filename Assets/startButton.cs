using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public Sprite blue;
    public Sprite orange;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        orange = GetComponent<SpriteRenderer>().sprite;
        scale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.localScale = new Vector2(scale * 0.8f, scale * 0.8f);
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = blue;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = orange;
    }
}
