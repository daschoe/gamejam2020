using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaysCounter : MonoBehaviour
{
  [Min(1)]
  public int days = 1;
  GameObject daysUI;
  //Singleton
  public static DaysCounter instance;

  void Awake ()
  {
    if (instance != null)
    {
      Debug.LogWarning("More than one instance of DaysCounter found.");
      return;
    }
    instance = this;
  }
  public delegate void OnDayChanged();
  public OnDayChanged onDayChangedCallback;
  void Start()
  {
      daysUI = GameObject.Find("DayCounter");
  }

  // Update is called once per frame
  void Update()
  {
      daysUI.GetComponent<Text>().text = "Day:"+ days.ToString();
  }
  public void Add ()
  {
    days++;
    if (onDayChangedCallback != null)
    {
      onDayChangedCallback.Invoke();
    }
  }
}
