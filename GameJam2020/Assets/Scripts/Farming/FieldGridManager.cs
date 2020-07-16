using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGridManager : MonoBehaviour
{
    public float x_Start, y_Start;
    [SerializeField]
    public int rows = 12;
    [SerializeField]
    public int cols = 12;
    [SerializeField]
    public float tileSize = 0.4f;
    private SpriteRenderer rend;
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
      transform.position = new Vector2(0,0);
      for (int i = 0; i < rows*cols; i++) {

          Instantiate(referenceTile, new Vector3(x_Start + (tileSize*(i%cols)), y_Start + (-tileSize*(i/cols))),Quaternion.identity);
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
