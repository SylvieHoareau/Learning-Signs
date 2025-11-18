using UnityEngine;

public class MimoBubbleManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image sign;
    [SerializeField] private Sprite bonjour;
    [SerializeField] private GameObject bubble;

    void Start()
    {
        DialogueManager.EventTrigger += MimoAction;
    }

    private void MimoAction(string action)
    {
        switch (action)
        {
            case "Bonjour":
                bubble.SetActive(true);
                sign.sprite = bonjour;
                break;
            case "None":
                bubble.SetActive(false);
                break;
            default:
                break;
        }
    }
}
