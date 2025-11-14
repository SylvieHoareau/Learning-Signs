using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Identifiant unique de la carte")]
    public int id;

    private CanvasGroup canvasGroup;
    private Canvas canvas;
    public RectTransform rectTransform;
    [HideInInspector]
    public Transform originalParent;
    public S_DropSlot current_slot;
    private Vector3 startPosition;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();

        startPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        if(current_slot)
        {
            current_slot.cardInSlot = null;
            current_slot = null;
        }

        // On place la carte au-dessus du canvas pour qu'elle soit par-dessus
        // transform.SetParent(canvas.transform);

        // Permet aux slots de détecter le drop
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        // transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // La carte peut être déposé sur un slot
        canvasGroup.blocksRaycasts = true;

        // Si le slot n'a pas récupéré l'objet, le remettre à sa position
        if (transform.parent == originalParent)
        {
            rectTransform.anchoredPosition = startPosition;
            // transform.SetParent(originalParent);
            // transform.localPosition = Vector3.zero; // replace correctement dans le layout original 
        }
    }

    public void ResetPos()
    {
        transform.parent = originalParent;
        rectTransform.anchoredPosition = startPosition;
    }

}
