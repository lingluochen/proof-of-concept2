using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heartManager : MonoBehaviour
{
    public int health;
    public List<GameObject> hearts;
    public GameObject heart;
    public Sprite grayHeart;
    public Sprite redHeart;
    public int maxHealth; 

    public GameObject hurt;
    // Start is called before the first frame update
    void Start()
    {
        hurt.SetActive(false);
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
        hurt.SetActive(false);
        if (health > maxHealth)
        {
            health = maxHealth;
        }
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
        if (health == 1)
        {
            hurt.SetActive(true);
        }
        if (health <= 0)
        {
            SceneManager.LoadScene("end screen 2", LoadSceneMode.Single);
        }
    }
}
