using UnityEngine;
using static ItemDropTable;

[CreateAssetMenu(fileName = "EnemyTable", menuName = "Game/EnemyTable")]
public class EnemyTable : ScriptableObject
{
    [System.Serializable]
    public struct EnemyData
    {
        public GameObject EnemyPrefab;
        [Range(0f, 1f)] public float SpawnChance;
        public int Score;
    }

    public EnemyData[] enemys;
}
