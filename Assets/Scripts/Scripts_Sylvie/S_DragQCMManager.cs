using UnityEngine;
using UnityEngine.SceneManagement;

public class S_DragQCMManager : MonoBehaviour
{
    [SerializeField] private S_DropSlot[] slots;
    [SerializeField] private GameObject wrongFeedbackPanel;


    public void CheckAnswers()
    {
        bool all_correct = true;
        for (int i = 0; i < slots.Length; i++)
        {
            if(!slots[i].CheckSlot())
            {
                all_correct = false;
            }
        }

        if(all_correct)
        {
            // Continue to next game
            EventCatcher.Instance.SendSignalScene(true);
            DialogueManager.Instance.isTalking = true;
            SceneManager.LoadScene("HugoLabo");
        }
        else
        {
            // Play wrong feedback
            if (wrongFeedbackPanel != null)
            {
                wrongFeedbackPanel.SetActive(true);
            }
        }
    }

    // Called by the UI "Rejouer" button (or from code) to restart the current scene
    public void Replay()
    {
        if (wrongFeedbackPanel != null)
        {
            wrongFeedbackPanel.SetActive(false);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
