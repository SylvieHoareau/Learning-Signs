using UnityEngine;

public class KeepInLoad : MonoBehaviour
{
    public static KeepInLoad Instance;
    [SerializeField] private GameObject dialoguePanel;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            EventCatcher.ChangeScene += ShowDialogue;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void ShowDialogue(bool bo)
    {
        dialoguePanel.SetActive(bo);
    }
}
