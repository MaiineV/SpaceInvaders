using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Level", fileName = "Level")]
public class SOLevel : ScriptableObject
{
    public int level;
    public float spawnTime;
    public int enemiesInLevel;
    public bool isBossLevel;
}
