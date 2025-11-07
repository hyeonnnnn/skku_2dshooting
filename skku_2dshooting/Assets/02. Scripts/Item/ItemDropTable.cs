using UnityEngine;

[CreateAssetMenu(fileName = "ItempDropTable", menuName = "Game/ItemDropTable")]
public class ItemDropTable : ScriptableObject
{
    [System.Serializable]
    public struct ItemData
    {
        public GameObject ItemPrefab;
        public float DropChance;
    }

    public ItemData[] Items;

    public float DropRate = 0.5f;
}
