using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    [Header("UI 요소")]
    public Image iconImage;
    public Image borderImage; // 착용 상태 테두리용

    [HideInInspector]
    public ItemData currentItem;

    public UIInventory uiInventory;
    public PlayerStatus playerStatus;

    // 아이템 정보 설정
    public void Setup(ItemData item)
    {
        currentItem = item;
        Debug.Log($"[ItemSlot] 설정됨: {item.displayName}, Icon: {(item.Icon != null ? "OK" : "null")}");

        iconImage.sprite = item.Icon;

        UpdateEquipVisual(); // 착용 여부 표시
    }

    // 설명창 호출
    public void OnClickSlot()
    {
        uiInventory.ShowItem(currentItem);
    }

    
    public void UpdateEquipVisual()
    {
        if (playerStatus != null && playerStatus.IsEquipped(currentItem))
        {
            borderImage.enabled = true;
            borderImage.color = Color.yellow;
        }
        else
        {
            borderImage.enabled = false; // 아예 꺼버리기!
        }
    }

}
