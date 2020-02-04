using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MazeController : MonoBehaviour
{
  public List<DoorSO> doors;
  public List<Vector3> grid;
  public List<GameObject> tiles;

  public Transform tilesContainer;
  public GameObject statsPanel;

  public List<Text> tileCounters;


    void Start()
    {

    buildGrid();
    generateTiles();
    randomlyPlaceTiles();

    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.BackQuote))
      {
        if(!statsPanel.activeInHierarchy)
        {
        statsPanel.SetActive(true);
        }
        else
        {
        statsPanel.SetActive(false);
        }
        
      }
    }


    void buildGrid()
  {
    grid = new List<Vector3>();

    for (int row = 0; row < 4; row++)
    {
      for (int col = 0; col < 5; col++)
      {
        grid.Add(new Vector3(col * 16.0f, 0.0f, row * 16.0f));
      }
    }
  }

  void generateTiles()
  {
    tiles = new List<GameObject>();

    int counter = 0;
    foreach (var door in doors)
    {
      
      var tileCount = Mathf.RoundToInt(door.Probability * 20.0f);
      tileCounters[counter].text = tileCount.ToString();
      for (int count = 0; count < tileCount ; count++)
      {
        tiles.Add(door.tile);
      }

      counter += 1;
    }
  }

  void randomlyPlaceTiles()
  {
    foreach (var tile in tiles)
    {
      int randomGridIndex = Random.Range(0, grid.Count);
      Vector3 position = grid[randomGridIndex];
      grid.RemoveAt(randomGridIndex);
      Instantiate(tile, position, Quaternion.identity).transform.parent = tilesContainer;
    }
  }


    
}
