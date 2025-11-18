using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class FontSizeController : MonoBehaviour
{
    public static FontSizeController instance;
    public static int size = 20;
    public static event System.Action OnSizeChanged;

    [SerializeField] int targetSize = 10;
    [SerializeField] bool updateInEditMode = false;

    public Slider fontSizeSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        if (!Application.isPlaying) return;
        
        size = PlayerPrefs.GetInt("FontSize", 50);
        fontSizeSlider.value = size;

    }

    private void Update()
    {
        if (!updateInEditMode)
            return; 
        if (targetSize != size)
        {
            size = targetSize;
            OnSizeChanged?.Invoke();
        }
    }

    public void UpdateSizeFromSlider(float get)
    {
        size = Mathf.RoundToInt(get);
        OnSizeChanged?.Invoke();
        PlayerPrefs.SetInt("FontSize", size);
        PlayerPrefs.Save(); 
    }
}
