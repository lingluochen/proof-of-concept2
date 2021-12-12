using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyEarned : MonoBehaviour
{
    public int money;
    public Text moneyTxt;
    // Start is called before the first frame update
    void Start()
    {
        money = ES3.Load<int>("money");
        moneyTxt.text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
