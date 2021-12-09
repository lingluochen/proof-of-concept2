using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCamera : MonoBehaviour
{
    public GameObject cam;
    public Transform pos;
    public gameManager manager;
    public bool switchPos;
    public bool moveLeft;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<gameManager>();
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (switchPos)
        {
            if (!moveLeft)
            {
                if (cam.transform.position.x < pos.position.x)
                {
                    cam.transform.Translate(new Vector2(0.5f, 0));
                    manager.cameraMoving = true;
                    GameObject.Find("moving tentacle").transform.GetChild(0).GetComponent<pick>().beingPicked = false;
                }
                else
                {
                    switchPos = false;
                    manager.cameraMoving = false;
                    cam.transform.position = new Vector3(pos.position.x, cam.transform.position.y,-10);
                    GameObject.Find("moving tentacle").transform.GetChild(0).GetComponent<pick>().beingPicked = true;
                }
            }
            else
            {
                if (cam.transform.position.x > pos.position.x)
                {
                    cam.transform.Translate(new Vector2(-0.5f, 0));
                    manager.cameraMoving = true;
                    GameObject.Find("moving tentacle").transform.GetChild(0).GetComponent<pick>().beingPicked = false;
                }
                else
                {
                    switchPos = false;
                    manager.cameraMoving = false;
                    cam.transform.position = new Vector3(pos.position.x, cam.transform.position.y,-10);
                    GameObject.Find("moving tentacle").transform.GetChild(0).GetComponent<pick>().beingPicked = true;
                }
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !manager.picked && !manager.cameraMoving)
        {
            switchPos = true;
        }
    }
}
