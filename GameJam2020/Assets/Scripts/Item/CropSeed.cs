using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewItemObject", menuName ="Inventory/Item/Crop Seed")]
public class CropSeed : Item
{
    [Range(1,5)]
    public int GrowthTime;
    public Item crop;
    public PlayerControl player;
    //when used on plot, spawn plant
    public override void Use()
    {
      player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
      if (player.currentSpot != null && player.stamina >=10)
      {
        Debug.Log("Planting " + name);
        Inventory.instance.Remove(this);
        GameObject newPlant = (GameObject)Instantiate(Resources.Load("Plant"));
        newPlant.gameObject.GetComponent<PlantGrowth>().crop = this;
        Instantiate(newPlant, player.currentSpot.transform.position,Quaternion.identity);
        player.ReduceStamina(10);
      }
      else
      {
        Debug.Log("Not standing on a planting spot");
      }

    }

}
