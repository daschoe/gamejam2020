using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public int currency;
    public int maxCurrency = 9999;
    GameObject currencyUI;
    // Start is called before the first frame update
    void Start()
    {
        currencyUI = GameObject.Find("Currency");
    }

    // Update is called once per frame
    void Update()
    {
        currencyUI.GetComponent<Text>().text = currency.ToString();
        if (currency < 0)
          currency = 0;
    }
}
