using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door1", menuName = "Game/Door")]
public class DoorSO : ScriptableObject
{
    public bool Hot;
    public bool Noisy;
    public bool Safe;
    public float Probability;

    public GameObject tile;
}
