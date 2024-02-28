using UnityEngine;
using UnityEngine.EventSystems;

public class BottomSheetTab : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private float originalHeight;
    private Camera cam;

    void Start()
    {
        // Obtenha a referência para o RectTransform
        rectTransform = GetComponent<RectTransform>();
        // Defina o tamanho do RectTransform para corresponder ao tamanho da câmera

        rectTransform.sizeDelta = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight*2);
            
        originalHeight = rectTransform.sizeDelta.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.GetComponent<SideBlock>().SetBlocked(true);
        if (rectTransform == null)
            return;

        rectTransform.sizeDelta += new Vector2(0, eventData.delta.y);

        if (rectTransform.sizeDelta.y < 300)
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 300);
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


