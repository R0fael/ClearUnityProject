using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("In Development...")]
    public Item[] items;
    public int maxCount;

    /*
    public bool PickItem(Item item)
    {
        foreach (Item _item in items)
        {
            if (_item.name == item.name && (_item.amount + item.amount) < _item.maxAmount)
            {
                _item.amount += item.amount;
                return true;
            }
        }

        foreach (Item _item in items)
        {
            if (_item.name == item.name && (_item.amount + item.amount) < _item.maxAmount)
            {
                _item.amount += item.amount;
                return true;
            }
        }

        return false;
    }
    */
}
