using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoisyDoor : MonoBehaviour
{
  public AudioSource audioSource;
  public OutlineFilterObj outline;

    // Update is called once per frame
    void Update()
    {
        if(outline.isEnabled)
        {
          audioSource.Play();
        }
    }
}
