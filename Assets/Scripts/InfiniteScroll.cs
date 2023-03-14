using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour, IBeginDragHandler, IDragHandler, IScrollHandler
{
    #region Private Members

    /// <summary>
    /// The ScrollContent component that belongs to the scroll content GameObject.
    /// </summary>
    [SerializeField]
    private ScrollContent scrollContent;

    /// <summary>
    /// How far the items will travel outside of the scroll view before being repositioned.
    /// </summary>
    [SerializeField]
    private float outOfBoundsThreshold;

    /// <summary>
    /// The ScrollRect component for this GameObject.
    /// </summary>
    private ScrollRect scrollRect;

    /// <summary>
    /// The last position where the user has dragged.
    /// </summary>
    private Vector2 lastDragPosition;

    /// <summary>
    /// Is the user dragging in the positive axis or the negative axis?
    /// </summary>
    private bool positiveDrag;

    #endregion

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        scrollRect.vertical = scrollContent.Vertical;
        scrollRect.horizontal = scrollContent.Horizontal;
        scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
    }

    /// <summary>
    /// Called when the user starts to drag the scroll view.
    /// </summary>
    /// <param name="eventData">The data related to the drag event.</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        lastDragPosition = eventData.position;
    }

    /// <summary>
    /// Called while the user is dragging the scroll view.
    /// </summary>
    /// <param name="eventData">The data related to the drag event.</param>
    public void OnDrag(PointerEventData eventData)
    {
        if (scrollContent.Vertical)
        {
            positiveDrag = eventData.position.y > lastDragPosition.y;
        }
        else if (scrollContent.Horizontal)
        {
            positiveDrag = eventData.position.x > lastDragPosition.x;
        }

        lastDragPosition = eventData.position;
    }

    /// <summary>
    /// Called when the user starts to scroll with their mouse wheel in the scroll view.
    /// </summary>
    /// <param name="eventData">The data related to the scroll event.</param>
    public void OnScroll(PointerEventData eventData)
    {
        if (scrollContent.Vertical)
        {
            positiveDrag = eventData.scrollDelta.y > 0;
        }
        else
        {
            positiveDrag = eventData.scrollDelta.y < 0;
        }
    }
    public void OnViewScroll()
    {
        if (scrollContent.Vertical)
        {
            HandleVerticalScroll();
        }
    }

    private void HandleVerticalScroll()
    {
        int currItemIndex = positiveDrag ? scrollRect.content.childCount - 1 : 0;
        var currItem = scrollRect.content.GetChild(currItemIndex);

        if (!ReachedThreshold(currItem))
        {
            return;
        }

        int endItemIndex = positiveDrag ? 0 : scrollRect.content.childCount - 1;
        Transform endItem = scrollRect.content.GetChild(endItemIndex);
        Vector2 newPos = endItem.position;

        if (positiveDrag)
        {
            newPos.y = endItem.position.y - scrollContent.ChildHeight * 1.5f + scrollContent.ItemSpacing;
        }
        else
        {
            newPos.y = endItem.position.y + scrollContent.ChildHeight * 1.5f - scrollContent.ItemSpacing;
        }

        currItem.position = newPos;
        currItem.SetSiblingIndex(endItemIndex);
    }

    private bool ReachedThreshold(Transform item)
    {
        if (scrollContent.Vertical)
        {
            float posYThreshold = transform.position.y + scrollContent.Height * 0.5f + outOfBoundsThreshold;
            float negYThreshold = transform.position.y - scrollContent.Height * 0.5f - outOfBoundsThreshold;
            return positiveDrag ? item.position.y - scrollContent.ChildWidth * 0.5f > posYThreshold :
                item.position.y + scrollContent.ChildWidth * 0.5f < negYThreshold;
        }
        else
        {
            float posXThreshold = transform.position.x + scrollContent.Width * 0.5f + outOfBoundsThreshold;
            float negXThreshold = transform.position.x - scrollContent.Width * 0.5f - outOfBoundsThreshold;
            return positiveDrag ? item.position.x - scrollContent.ChildWidth * 0.5f > posXThreshold :
                item.position.x + scrollContent.ChildWidth * 0.5f < negXThreshold;
        }
    }
}
