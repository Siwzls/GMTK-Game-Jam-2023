using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    private ItemData _item;

    public ItemData Item => _item;

    public Task (ItemData item)
    {
        _item = item;
    }
}
