using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipSpawner : MonoBehaviour
{
    public GameObject TooltipPrefab = null;
    public Vector2 TooltipPositionOffset = new Vector2(10, 0);
    public float TooltipOffsetMultiplier = 1.0f;

    public string DisplayName = "";

    [TextArea]
    public string DisplayTooltip = "Lorem ipsum...";

    public Transform TooltipParent = null;

    GameObject currTooltip = null;
    RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void SpawnTooltip()
    {
        if(currTooltip == null && enabled)
        {
            currTooltip = Instantiate(TooltipPrefab, TooltipParent);
            RectTransform crt = currTooltip.GetComponent<RectTransform>();
            crt.anchoredPosition = (new Vector2(rt.anchoredPosition.x + crt.rect.width / 2.0f + rt.rect.width / 2.0f, rt.anchoredPosition.y) + TooltipPositionOffset) * TooltipOffsetMultiplier;
            TooltipBehavior tb = currTooltip.GetComponent<TooltipBehavior>();
            tb.NameText.text = DisplayName;
            tb.TooltipText.text = DisplayTooltip;
        }
    }

    public void DestroyTooltip()
    {
        if(currTooltip != null && enabled)
        {
            Destroy(currTooltip);
            currTooltip = null;
        }
    }
}
