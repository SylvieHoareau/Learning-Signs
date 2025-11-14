using UnityEngine;

public class MimoBubbleManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image sign;
    [SerializeField] private Sprite bonjour;

    void Start()
    {
        DialogueManager.EventTrigger += MimoAction;
    }

    private void MimoAction(string action)
    {
        switch (action)
        {
            case "Bonjour":
                sign.sprite = bonjour;
                break;
            default:
                break;
        }
    }
}
