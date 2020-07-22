using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
  public CropSeed crop;
  public Sprite seed;
  public Sprite seedling;
  public Sprite smallPlant;
  public Sprite plant;
  private int dayCounter;

    // Start is called before the first frame update
    void Start()
    {
      dayCounter = 0;
      this.GetComponent<SpriteRenderer>().sprite = seed;
      DaysCounter.instance.onDayChangedCallback += UpdatePlant;
    }
    //Update plant status on day change, spawn crop on final day
    void UpdatePlant ()
    {
      dayCounter++;
      if (dayCounter > crop.GrowthTime)
      {
        Debug.Log("Spawn Item: "+ crop.crop);
        Instantiate(crop.crop,transform.position,Quaternion.identity,transform.parent);
        Destroy(gameObject);
      } else if (dayCounter == crop.GrowthTime)
      {
        this.GetComponent<SpriteRenderer>().sprite = plant;
      } else
      {
        if ( dayCounter == 1)
        {
          this.GetComponent<SpriteRenderer>().sprite = seedling;
        } else if (dayCounter < (crop.GrowthTime/2))
          {
            this.GetComponent<SpriteRenderer>().sprite = smallPlant;
          } else {
            this.GetComponent<SpriteRenderer>().sprite = plant;
          }
      }
    }

}
