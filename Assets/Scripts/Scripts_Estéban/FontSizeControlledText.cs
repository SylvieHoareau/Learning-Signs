using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
[DisallowMultipleComponent]
public class FontSizeControlledText : MonoBehaviour
{
    TMP_Text targetText;
    int currentSize;

    private void Awake()
    {
        targetText = GetComponent<TMP_Text>();
        currentSize = Mathf.RoundToInt(targetText.fontSize);
    }

    public void UpdateSize()
    {
        var size = FontSizeController.size;
        if (currentSize == size || targetText == null)
            return;

        currentSize = size;
        targetText.fontSize = size;
    }

    private void OnEnable()
    {
        FontSizeController.OnSizeChanged += UpdateSize;
        UpdateSize();
    }

    private void OnDisable()
    {
        FontSizeController.OnSizeChanged -= UpdateSize;
        UpdateSize();
    }
}
