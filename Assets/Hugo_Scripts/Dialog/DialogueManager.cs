using UnityEngine;
using Newtonsoft.Json;
using System;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public static event Action<string> EventTrigger;
    private TextAsset jsonFile;

    private ConversationData dataConversation;
    [SerializeField] TextMeshProUGUI textMP;
    private int currentStep = 0;
    private Coroutine typeScriptCoroutine;
    private bool findTextBalise = false;
    private bool skipText = false;
    private float timeText = 0.05f;
    private string balise;

    [SerializeField] private NPCControler npc;

    [SerializeField] private GameObject dialogBox;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            jsonFile = Resources.Load<TextAsset>("Dialogue");
            DeserializedJson();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ResetStateDialog()
    {
        if (!dialogBox.activeSelf) dialogBox.SetActive(true);

        textMP.text = "";
        timeText = 0.05f;
        balise = "";
        findTextBalise = false;
        skipText = false;
    }

    public void NextStep(InputAction.CallbackContext context)
    {

        if (context.performed && context.ReadValue<float>() == 1)
        {
        ResetStateDialog();

        if (typeScriptCoroutine != null) { StopCoroutine(typeScriptCoroutine); }

        foreach (var conv in dataConversation.Conversations)
        {
            if (conv.Id == npc.id + npc.numberDialog.ToString())
            {

                if (currentStep != -1)
                    TypescriptEffect(conv.Steps[currentStep].Text);
                else
                {
                    dialogBox.SetActive(false);
                    currentStep = 0;
                    return;
                }

                if (conv.Steps[currentStep].Event != null)
                    EventTrigger?.Invoke(conv.Steps[currentStep].Event);
 

                if (conv.Steps[currentStep].Next == null)
                {
                    currentStep = -1;
                    npc.numberDialog += 1;
                    Debug.Log(npc.numberDialog);
                    if (npc.numberDialog > int.Parse(conv.MaxDialog)) npc.numberDialog = 1;
                    return;
                }
                else
                {
                    currentStep = int.Parse(conv.Steps[currentStep].Next);
                }
            }
        }
        }
    }
    

    public void TypescriptEffect(string str)
    {
        typeScriptCoroutine = StartCoroutine(WaitForTypescript(str));
    }

    IEnumerator WaitForTypescript(string str)
    {
        int i = 0;

        while (i < str.Length)
        {
            if (str[i] == '<') findTextBalise = true;
            if (str[i] == '[') skipText = true;

            if (!findTextBalise) yield return new WaitForSeconds(timeText);
            
            if (str[i] == '>') findTextBalise = false;

            if (!skipText)
            {
                textMP.text += str[i].ToString();
            }
            else
                balise += str[i];
            if (str[i] == ']')
            {
                skipText = false;
                AnalyseBalise();
            }
            i++;
        }
    }
    
    private void AnalyseBalise()
    {
        switch (balise[1])
        {
            case 'w':
                timeText = float.Parse(balise.Substring(3, balise.Length - 1 - 3));
                break;
            default:
                break;
        }

        balise = "";
    }

    private void DeserializedJson()
    {
        if (jsonFile == null)
        {
            Debug.LogError("No JSON find");
            return;
        }

        try
        {
            dataConversation = JsonConvert.DeserializeObject<ConversationData>(jsonFile.text);
        }
        catch (Exception ex)
        {
            Debug.LogError("JSON Serialization error : " + ex.Message);
            return;
        }
    }
}