using UnityEngine;

[System.Serializable]

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private ItemDropTable _itemDropTable;

    public void TryDropItem(Vector2 position)
    {
        if (_itemDropTable == null) return;

        float randomValue = Random.value;
        if (randomValue > _itemDropTable.DropRate) return;

        DropItem(position);
    }

    private void DropItem(Vector2 position)
    {
        float randomValue = Random.value;
        float cumulative = 0f;

        foreach (var item in _itemDropTable.Items)
        {
            cumulative += item.DropChance;
            if (randomValue <= cumulative)
            {
                Instantiate(item.ItemPrefab, position, Quaternion.identity);
                return;
            }
        }
        Instantiate(_itemDropTable.Items[_itemDropTable.Items.Length - 1].ItemPrefab, position, Quaternion.identity);
    }
}
