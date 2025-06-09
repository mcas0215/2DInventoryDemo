using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    [Header("UI 요소")]
    public Image iconImage;
    public TMP_Text nameText;
    public UIInventory uiInventory;
    private ItemData currentItem;

    // 아이템 정보 설정
    public void Setup(ItemData item)
    {
        currentItem = item;
        iconImage.sprite = item.Icon;
        nameText.text = item.displayName;
    }

    // 슬롯 클릭 시 호출할 함수
    public void OnClickSlot()
    {
        Debug.Log($"선택한 아이템: {currentItem.displayName}");
        // 향후: 장비착용, 설명창 띄우기 등 연결 가능
        uiInventory.ShowTooltip(currentItem);
    }
}
