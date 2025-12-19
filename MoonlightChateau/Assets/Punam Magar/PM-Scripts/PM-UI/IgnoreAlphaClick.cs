using UnityEngine;
using UnityEngine.UI;

public class IgnoreAlphaClick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Range(1, 2.0f)]
    [SerializeField] float hoverScale;

    RectTransform rectTransform;
    Vector2 originalScale;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        originalScale = rectTransform.sizeDelta;

        //Ignore clicks on transparent areas of the image
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void OnHoverEnter()
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.rect.width * hoverScale, rectTransform.rect.height * hoverScale);
    }

    public void OnHoverExit()
    {
        rectTransform.sizeDelta = originalScale;
    }
}
