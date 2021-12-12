using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public float life;
    public float hunger;
    public bool picked;
    public GameObject pickObj;
    public GameObject health;
    public bool cameraMoving;
    public GameObject seaweed;
    public GameObject plate;
    public GameObject thePlate;
    public GameObject theSeaweed;
    public Transform platePos;
    public Transform seaweedPos;
    public Transform plateGen;
    public Transform seaweedGen;
    public wrapController theWrapper;
    public int money;
    public Text moneyTxt;
    public GameObject timer;
    public float gameCount;
    public float maxGameCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (thePlate == null)
        {
            GameObject newPlate = Instantiate(plate, plateGen.position, Quaternion.Euler(0, 0, 0));
            thePlate = newPlate;
            thePlate.GetComponent<SpriteRenderer>().sortingOrder = 0;
            generateSeaweed();
            theWrapper.startScroll = false;
            theWrapper.scrollCounter = 0;
            
        }
        else
        {
            thePlate.transform.position = Vector2.MoveTowards(thePlate.transform.position, platePos.position, 0.5f);
        }

        if (theSeaweed != null)
        {
            theSeaweed.transform.position = Vector2.MoveTowards(theSeaweed.transform.position, seaweedPos.position, 0.5f);
        }

        string moneyString = money.ToString();
        moneyTxt.text = moneyString;

        if (gameCount < maxGameCount)
        {
            gameCount += 1;
            timer.transform.eulerAngles = new Vector3(0, 0, -(gameCount / maxGameCount) * 360);
        }
        else
        {
            ES3.Save("money", money);
            SceneManager.LoadScene("end screen 1", LoadSceneMode.Single);
        }


    }

    public void generateSeaweed()
    {
        GameObject newSeaweed = Instantiate(seaweed, seaweedGen.position, Quaternion.Euler(0, 0, 0));
        theSeaweed = newSeaweed;
        theWrapper.currentSeaweed = theSeaweed;
    }
}
