using UnityEngine;

[CreateAssetMenu(fileName = "ItemDropTable", menuName = "Game/ItemDropTable")]
public class ItemDropTable : ScriptableObject
{
    [System.Serializable]
    public struct ItemData
    {
        public GameObject ItemPrefab;
        [Range(0f, 1f)] public float DropChance;
    }

    public ItemData[] Items;

    public float DropRate = 0.5f;
}
