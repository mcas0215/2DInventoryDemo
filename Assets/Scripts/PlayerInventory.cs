using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("UI 관련")]
    public Transform contentParent; // ScrollView의 Content에 해당
    public GameObject slotPrefab;   // ItemSlot 프리팹

    [Header("아이템 목록")]
    public List<ItemData> items = new List<ItemData>();
    public List<ItemSlot> allSlots = new List<ItemSlot>();
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
        slotGO.transform.localScale = Vector3.one;

        ItemSlot slot = slotGO.GetComponent<ItemSlot>();

        slot.uiInventory = FindObjectOfType<UIInventory>();
        slot.playerStatus = FindObjectOfType<PlayerStatus>();

        slot.Setup(item);
        allSlots.Add(slot);

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
    public void RefreshAllSlotVisuals()
    {
        foreach (var slot in allSlots)
        {
            slot.UpdateEquipVisual();
        }
    }


    [Header("초기 아이템")]
    public ItemData[] startingItems;

    private void Start()
    {
        foreach (var item in startingItems)
        {
            AddItem(item);
        }
    }

}
