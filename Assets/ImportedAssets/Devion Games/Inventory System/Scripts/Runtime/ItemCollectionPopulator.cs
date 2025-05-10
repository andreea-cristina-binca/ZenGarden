using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevionGames.InventorySystem
{
    [RequireComponent(typeof(ItemCollection))]
    public class ItemCollectionPopulator : MonoBehaviour
    {
        [ItemGroupPicker]
        [SerializeField]
        public ItemGroup m_ItemGroup;

        [ItemPicker]
        [SerializeField]
        public Item lilly;
        [ItemPicker]
        [SerializeField]
        public Item sunflower;
        [ItemPicker]
        [SerializeField]
        public Item snowdrop;
        [ItemPicker]
        [SerializeField]
        public Item poinsettia;


         private void Awake()
         {
            int month = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("MM"));

            if (m_ItemGroup.name == "Vendor")
            {
                int size = m_ItemGroup.Items.Length;
                Item[] items = m_ItemGroup.Items;

                for (int i = 0; i < size; i++)
                {
                    switch (items[i].name)
                    {
                        case "Lilly Seeds":
                        case "Sunflower Seeds":
                        case "Snowdrop Seeds":
                        case "Poinsettia Seeds":
                            if (month == 9 || month == 10 || month == 11)
                            {
                                items[i] = lilly;
                            }
                            if (month == 6 || month == 7 || month == 8)
                            {
                                items[i] = sunflower;
                            }
                            if (month == 3 || month == 4 || month == 5)
                            {
                                items[i] = snowdrop;
                            }
                            if (month == 12 || month == 1 || month == 2)
                            {
                                items[i] = poinsettia;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }
}