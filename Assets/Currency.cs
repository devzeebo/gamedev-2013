using UnityEngine;
using System.Collections;

public class Currency : MonoBehaviour {

    public int StartingMoney;

    [HideInInspector]
    int money;
    public int moneyOverTime = 1;

    public float time = 1;

	// Use this for initialization
	void Start() {
        money = StartingMoney;
        InvokeRepeating("MoneyOverTime", 0f, time);
	}
	
	// Update is called once per frame
	void Update() {
	}

	void OnGUI() {
		GUI.Box(new Rect(10, 10, 100, 20), "$$$: " + money);
	}

    void MoneyOverTime()
    {
        money += moneyOverTime;
    }

    public bool Charge(int cost)
    {
        if (money >= cost)
        {
            money -= cost;

            return true;
        }

        return false;
    }
}
