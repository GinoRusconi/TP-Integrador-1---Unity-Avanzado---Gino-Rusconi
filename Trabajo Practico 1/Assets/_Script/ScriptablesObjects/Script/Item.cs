using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]

public class Item : ScriptableObject
{
    public GameObject objectDrop;
    public Sprite iconObject;
}
