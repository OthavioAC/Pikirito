using UnityEngine;
using UnityEngine.EventSystems;

public class BottomSheetTab : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private float originalHeight;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalHeight = rectTransform.sizeDelta.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.GetComponent<SideBlock>().SetBlocked(true);
        if (rectTransform == null)
            return;

        rectTransform.sizeDelta += new Vector2(0, eventData.delta.y);

        if (rectTransform.sizeDelta.y < 0)
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 0);
        else if (rectTransform.sizeDelta.y > originalHeight)
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, originalHeight);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.GetComponent<SideBlock>().SetBlocked(false);
        // Debug.Log("kkk");
        // You can add behavior for when the user stops dragging here
    }
}


