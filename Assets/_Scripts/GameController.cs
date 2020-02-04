using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Util;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameController : MonoBehaviour
{
    public string path;

    public List<Util.Door> doors;

    public List<DoorSO> doorObjects;

    public GameObject fileBrowserUI;

    public uFileBrowser.FileBrowser fileBrowser;

    public Text addressText;
    public Text probabilityFilePathLabel;


    private static GameController _Instance = null;

    private GameController() {}

    public static GameController Instance()
    {
      if(_Instance == null)
      {
        _Instance = new GameController();
        return _Instance;
      }
      return _Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
      doors = new List<Util.Door>();
      path = "Assets/Resources/probabilities.txt";
    }

    public void LoadFile()
    {
      char[] delimiter = new char[] { '\t' };
      Debug.Log(path);
        try
        {
          using(StreamReader reader = new StreamReader(path))
          {
            string line;
            int lineCount = 0;
            while((line = reader.ReadLine()) != null)
            {
              if(lineCount > 0)
              {
                var lineParts = line.Split(delimiter);
                doors.Add(new Util.Door(lineParts[0], lineParts[1], lineParts[2], lineParts[3]));
              }
              lineCount += 1;
            }

            Debug.Log("Finished Loading File!");
            reader.Dispose();
            reader.Close();
          }
        }
        catch (System.Exception)
        {   
        Debug.LogError("Error When Loading File");
        }



        var doorCount = 0;
        foreach (var door in doorObjects)
        {
            doorObjects[doorCount].Hot = this.doors[doorCount].Hot;
            doorObjects[doorCount].Noisy = this.doors[doorCount].Noisy;
            doorObjects[doorCount].Safe = this.doors[doorCount].Safe;
            doorObjects[doorCount].Probability = this.doors[doorCount].Probability;
            doorCount += 1;
        }
    }


    public void OnSelectTextFile_Click()
    {
      fileBrowserUI.SetActive(true);
    }

    public void OnSubmit_Click()
    {
    path = "Assets/Resources/";
      path += fileBrowser.FileName;
      probabilityFilePathLabel.text = path;
    }

    public void OnStartSimulation_Click()
    {
      LoadFile();
      SceneManager.LoadScene("Main");
    }


}
