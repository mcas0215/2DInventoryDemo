using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("UI 관련")]
    public Transform contentParent; // ScrollView의 Content에 해당
    public GameObject slotPrefab;   // ItemSlot 프리팹

    [Header("아이템 목록")]
    public List<ItemData> items = new List<ItemData>();

    // 아이템 추가
    public void AddItem(ItemData newItem)
    {
        items.Add(newItem);
        CreateSlot(newItem);
    }

    // 슬롯 생성
    private void CreateSlot(ItemData item)
    {
        GameObject slotGO = Instantiate(slotPrefab, contentParent);
        ItemSlot slot = slotGO.GetComponent<ItemSlot>();
        slot.Setup(item);
    }
    public void RefreshInventory()
    {
        // 기존 슬롯 모두 제거
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // 아이템 리스트 기반으로 다시 슬롯 생성
        foreach (var item in items)
        {
            CreateSlot(item);
        }
    }
}
