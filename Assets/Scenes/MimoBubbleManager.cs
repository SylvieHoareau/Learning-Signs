using UnityEngine;

public class MimoBubbleManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image sign;
    [SerializeField] private Sprite bonjour;
    [SerializeField] private Sprite aurevoir;
    [SerializeField] private GameObject bubble;
    [SerializeField] private GameObject sentence;

    void Start()
    {
        DialogueManager.EventTrigger += MimoAction;
    }

    private void MimoAction(string action)
    {
        if (!bubble) return;
        if (!sentence) return;

        switch (action)
        {
            case "Bonjour":
                bubble.SetActive(true);
                sign.sprite = bonjour;
                break;
             case "Aurevoir":
                bubble.SetActive(true);
                sign.sprite = aurevoir;
                break;
            case "None":
                bubble.SetActive(false);
                sentence.SetActive(false);
                break;
            case "Phrase":
                sentence.SetActive(true);
                break;
            default:
                break;
        }
    }
}
