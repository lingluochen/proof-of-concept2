using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartManager : MonoBehaviour
{
    public int health;
    public List<GameObject> hearts;
    public GameObject heart;
    public Sprite grayHeart;
    public Sprite redHeart;
    // Start is called before the first frame update
    void Start()
    {
        float newXPos = transform.position.x;
        float y = transform.position.y;
        redHeart = heart.GetComponent<SpriteRenderer>().sprite;
        for (int i = 0; i < health; i++)
        {
            GameObject theHeart = Instantiate(heart, new Vector2(newXPos, y), Quaternion.Euler(0, 0, 0));
            newXPos += 1f;
            hearts.Add(theHeart);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < health)
            {
                hearts[i].GetComponent<SpriteRenderer>().sprite = redHeart;
            }
            else
            {
                hearts[i].GetComponent<SpriteRenderer>().sprite = grayHeart;
            }
        }
    }
}
