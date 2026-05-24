using UnityEngine;
using UnityEngine.EventSystems;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject textToShow;

    void Start()
    {
        if (textToShow != null) textToShow.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (textToShow != null) textToShow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (textToShow != null) textToShow.SetActive(false);
    }
}
