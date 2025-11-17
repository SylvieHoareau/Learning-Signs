using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_DragQCMManager : MonoBehaviour
{
    [SerializeField] private S_DropSlot[] slots;


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
            SceneManager.LoadScene("HugoLabo");
        }
        else
        {
            // Play wrong feedback
        }
    }
}
