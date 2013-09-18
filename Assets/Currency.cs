using UnityEngine;
using System.Collections;

public class Currency : MonoBehaviour {

    public int StartingMoney;

    [HideInInspector]
    int money;
    public int moneyOverTime;

    public float time;

	// Use this for initialization
	void Start () {
        money = StartingMoney;
        InvokeRepeating("MoneyOverTime", 0f, time);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void MoneyOverTime()
    {
        money += moneyOverTime;
        gameObject.GetComponent<UILabel>().text = "" + money;
    }

    public bool Charge(int cost)
    {
        if (money >= cost)
        {
            money -= cost;
            gameObject.GetComponent<UILabel>().text = "" + money;

            return true;
        }

        return false;
    }
}
