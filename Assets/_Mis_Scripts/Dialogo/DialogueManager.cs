using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private void Awake()
    {/*
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;*/
    }

    public void ImprimirContador()
    {
        Debug.Log("Contador: " + AnimatorMnager.contador);
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) // al entrar el contador aumenta 1
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ImprimirContador();

        ContinueStory(); 

    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

         /* if(InputManager.GetInstance().GetSubmitPressed())
          {

          }*/

     /*   if(BNG.InputBridge.Instance.LeftTrigger == 1 || BNG.InputBridge.Instance.RightTrigger == 1)
        {
            ContinueStory();

        }*/
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            AnimatorMnager.contador++;
            DisplayChoices();
            ImprimirContador();
        }
        else
        {
            AnimatorMnager.contador = 0;
            ExitDialogueMode();   //mantener comentada para pruebas
        }
    }

    private void DisplayChoices()
    { 
        List<Choice> currentChoices = currentStory.currentChoices; 
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " 
                + currentChoices.Count);
        }

        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    // min 27 del video pero me salto por ahora, en caso de que funcione sin esto
    private IEnumerator SelectFirstChoice() 
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    } 


    //recordatorio revisar si al presionar en el personaje de nuevo se reinicia el dialogo min20 de video
    //En vez del Dialogue Trigger esta el On Click Event
}
