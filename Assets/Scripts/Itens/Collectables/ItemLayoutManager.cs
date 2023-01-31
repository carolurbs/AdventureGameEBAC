using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

public class ItemLayoutManager : MonoBehaviour
{
   public List<ItemLayout> itemLayouts;
    public ItemLayout prefabLayout;
    public Transform container;
    public void Start()
    {
        CreateItem();
    }
    private void CreateItem()
    {
        foreach(var setup in ItemManager.Instance.ItemSetups)
        {
            var item = Instantiate(prefabLayout, container);
            item.LoadItem(setup);
            itemLayouts.Add(item);
        }
    }
}
