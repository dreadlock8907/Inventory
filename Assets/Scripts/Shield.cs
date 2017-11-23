using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Shield", fileName = "New Shield Name")]
public class Shield : Item {

    [Header("Shield properties")]
    [Range(0, 300)]
    public int Defence;
    [Range(0.0f, 1.0f)]
    public float BlockChance;
    public Mesh Model;
}
