using UnityEngine;
using TMPro;

public class UIInventory : MonoBehaviour
{
    [Header("설명창 관련")]
    public GameObject ItemInfoPanel;
    public TMP_Text ItemNameText;
    public TMP_Text ItemDescriptionText;

    /// <summary>
    /// 아이템을 선택했을 때 설명창을 표시하거나 숨깁니다.
    /// </summary>
    public void ShowTooltip(ItemData item)
    {
        if (item == null)
        {
            ItemInfoPanel.SetActive(false); // null이면 창 닫기
            return;
        }

        ItemInfoPanel.SetActive(true);
        ItemNameText.text = item.displayName;
        ItemDescriptionText.text = item.description;
    }
}
