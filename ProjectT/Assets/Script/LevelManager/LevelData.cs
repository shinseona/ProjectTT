using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Object/LevelData", order = int.MaxValue)]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private string levelName;
    public string LevelName { get => levelName; }

}