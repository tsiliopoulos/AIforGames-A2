using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
  [System.Serializable]
  public class Door
  {
    // PUBLIC PROPERTIES
    public bool Hot { get; set; }
    public bool Noisy { get; set; }
    public bool Safe { get; set; }
    public float Probability { get; set; }

    public Door(string hot = "N", string noisy = "N", string safe = "N", string probability = "0.0")
    {
      this.Hot = (hot == "Y") ? true : false;
      this.Noisy = (noisy == "Y") ? true : false;
      this.Safe = (safe == "Y") ? true : false;
      this.Probability = float.Parse(probability);
    }

  }
}



