using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelScriptableObject", menuName ="ScriptableObject/Level")]
public class LevelScriptableObject : ScriptableObject
{
    public int numberOfLevels; // Số lượng level
    public Level[] levels; // Mảng chứa dữ liệu của từng level

    [System.Serializable]
    public class Level
    {
        public int level;
        public int numberOfMeteor;
        public int minHealth;
        public int maxHealth;
    }
}

