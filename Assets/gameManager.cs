using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            GameObject newSeaweed = Instantiate(seaweed, seaweedGen.position, Quaternion.Euler(0, 0, 0));
            theSeaweed = newSeaweed;
            theWrapper.startScroll = false;
            theWrapper.scrollCounter = 0;
            theWrapper.currentSeaweed = theSeaweed;
        }
        else
        {
            thePlate.transform.position = Vector2.MoveTowards(thePlate.transform.position, platePos.position, 0.5f);
        }

        if (theSeaweed != null)
        {
            theSeaweed.transform.position = Vector2.MoveTowards(theSeaweed.transform.position, seaweedPos.position, 0.5f);
        }
    }
}
