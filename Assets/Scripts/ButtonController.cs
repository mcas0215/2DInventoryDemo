using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class ButtonController : MonoBehaviour
{
    public RectTransform UIMainMenu;
    public RectTransform UIStatus;
    public RectTransform UIInventory;
    public RectTransform UIPlayer;
    public RectTransform ButtonStart;
    public RectTransform ButtonStatus;
    public RectTransform ButtonInventory;
    public RectTransform ButtonCancel;

    public float slideDistance = 1200f;
    public float slideDuration = 1f;


    IEnumerator ButtonAction(RectTransform fromUI, Vector2 offsetFrom, RectTransform toUI, Vector2 offestTo, float duration)
    {
        Vector2 fromStart = fromUI.anchoredPosition;
        Vector2 fromTarget = fromStart + offsetFrom;

        Vector2 toTarget = fromStart;
        Vector2 toStart = toTarget + offestTo;

        toUI.anchoredPosition = toStart;
        toUI.gameObject.SetActive(true);
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float normalized = Mathf.Clamp01(t / duration); //지금 애니메이션이 얼마나 진행됐는지 0~1 사이의 비율로 계산하고, 그 값을 안전하게 제한

            fromUI.anchoredPosition = Vector2.Lerp(fromStart, fromTarget, normalized);
            toUI.anchoredPosition = Vector2.Lerp(toStart, toTarget, normalized);

            yield return null;
        }
        fromUI.gameObject.SetActive(false);
    }

    public void OnStartButton()
    {
        StartCoroutine(ButtonAction(ButtonStart, new Vector2(1000f, 0), UIMainMenu, new Vector2(slideDistance, 0), slideDuration));
        UIPlayer.gameObject.SetActive(true);
    }
    public void OnStatusButton()
    {
        StartCoroutine(ButtonAction(UIMainMenu, new Vector2(1000f, 0), UIStatus, new Vector2(slideDistance, 0), slideDuration));
    }
    public void OnInventoryButton()
    {
        StartCoroutine(ButtonAction(UIMainMenu, new Vector2(1000f, 0), UIInventory, new Vector2(slideDistance, 0), slideDuration));
    }
    public void OnCancelButton()
    {
        if (UIStatus.gameObject.activeSelf)
        {
            StartCoroutine(ButtonAction(UIStatus, new Vector2(slideDistance, 0), UIMainMenu, new Vector2(slideDistance, 0), slideDuration));
        }
        else if (UIInventory.gameObject.activeSelf)
        {
            StartCoroutine(ButtonAction(UIInventory, new Vector2(slideDistance, 0), UIMainMenu, new Vector2(slideDistance, 0), slideDuration));
        }
    }
}
