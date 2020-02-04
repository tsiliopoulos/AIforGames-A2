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

  public GameObject player;

  void Start()
    {

    buildGrid();
    generateTiles();
    randomlyPlaceTiles();

    }

    void Update()
    {
        // show stats
       if(Input.GetKeyDown(KeyCode.BackQuote))
       {
           statsPanel.SetActive(!statsPanel.activeInHierarchy);
       }

       // quit the game
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           Application.Quit();
       }

       // reset with new Tile Positions
       if (Input.GetKeyDown(KeyCode.R))
       {
           resetAll();
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

  void removeAllChildren()
  {
      foreach (Transform child in tilesContainer)
      {
          Destroy(child.gameObject);
      }

      
  }

  void resetAll()
  {
      player.GetComponent<CharacterController>().enabled = false;
      player.transform.position = new Vector3(16.0f, 19.0f, 1.6f);
      player.GetComponent<CharacterController>().enabled = true;
        removeAllChildren();
      buildGrid();
      randomlyPlaceTiles();
  }


    
}
