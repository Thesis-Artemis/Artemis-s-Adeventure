using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataClass", menuName = "GameConfiguration/PlayerController", order = 1)]
public class DataClass : ScriptableObject
{
    // Start is called before the first frame update

    public float maxSpeed;
    public float jumpHeight;
}
