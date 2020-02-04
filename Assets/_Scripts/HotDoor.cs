using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDoor : MonoBehaviour
{
  private Material theMaterial;

    // Start is called before the first frame update
    void Start()
    {
    theMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
    theMaterial.SetColor("_Color", new Color(1.0f, 0.0f, 0.0f) * Mathf.PingPong(Time.time, 1.0f));
    theMaterial.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1.0f) * Mathf.PingPong(Time.time, 1.0f));
    theMaterial.EnableKeyword("_EMISSION");

  }
}
