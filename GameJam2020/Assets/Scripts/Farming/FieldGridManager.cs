using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGridManager : MonoBehaviour
{
    [SerializeField]
    public int rows = 12;
    [SerializeField]
    public int cols = 12;
    [SerializeField]
    public float tileSize = 0.4f;
    private SpriteRenderer rend;
    private GameObject field;
    // Start is called before the first frame update
    void Start()
    {
      GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void GenerateGrid()
    {
      GameObject referenceTile = (GameObject)Instantiate(Resources.Load("PlantingSpot"));
      for (int i = 0; i < rows*cols; i++) {
          //field = Instantiate(referenceTile, new Vector3(x_Start + (tileSize*(i%cols)), y_Start + (-tileSize*(i/cols))),Quaternion.identity);
          field = Instantiate(referenceTile, new Vector2(transform.position.x + (tileSize*(i%cols)) + (tileSize/2),transform.position.y + (tileSize*(i/cols)) + (tileSize/2)),Quaternion.identity);
          field.transform.SetParent(transform);
          //field.transform.position = new Vector2(0,0);
          //field.transform.localPosition = new Vector2(0,0);
          //CheckRenderer(tile);
      }
      Destroy(referenceTile);
      float gridW = cols * tileSize;
      float gridH = rows * tileSize;
      //transform.position = new Vector2(gridW/2+tileSize/2, -gridH/2-tileSize/2);
      //transform.position = new Vector2(gridW/2+tileSize/2, -gridH*2-gridH/2);
    }
//     void CheckRenderer(GameObject tile)
// {
//     //Check that the GameObject you select in the hierarchy has a SpriteRenderer component
//     if (tile.GetComponent<SpriteRenderer>())
//     {
//         //Fetch the SpriteRenderer from the selected GameObject
//         rend = tile.GetComponent<SpriteRenderer>();
//         //Change the sorting layer to the name you specify in the TextField
//         //Changes to Default if the name you enter doesn't exist
//         rend.sortingLayerName = "Objects";
//         //Change the order (or priority) of the layer
//         rend.sortingOrder = 1;
//     }
// }
}
