using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Itens
{


    public enum ItemType
{ COIN,
   LIFE_PACK


}
public class ItemManager : Singleton<ItemManager>
{
        public List<ItemSetup> ItemSetups;
    new private void Awake()
    {
        base.Awake();
        Reset();

    }
    private void Reset()
    {
            foreach(var i  in ItemSetups )
            {
                i.soInt.value = 0;
            }
    }
        public  ItemSetup GetItemByType(ItemType itemType)
        {
          return  ItemSetups.Find(i => i.itemType == itemType);
        }
        public void AddByType(ItemType itemType, int amount = 1)
    {
            if (amount < 0) return; 
            ItemSetups.Find(i => i.itemType == itemType).soInt.value+= amount;
    }
        public void RemoveByType(ItemType itemType, int amount =1)
        {
            if (amount <= 0) return;

            var item = ItemSetups.Find(i => i.itemType == itemType);
            item.soInt.value -= amount;
            
            if(item.soInt.value<0)item.soInt.value = 0;
        }


        [NaughtyAttributes.Button]
        private void AddCoin()
        {
            AddByType(ItemType.COIN, 1);
        }
        [NaughtyAttributes.Button]
        private void AddLifePack()
        {
            AddByType(ItemType.LIFE_PACK, 1);
        }
    }
    [System.Serializable]
    public class ItemSetup
    {
        public ItemType itemType;
        public SOInt soInt;
        public Sprite icon;
    }
}
