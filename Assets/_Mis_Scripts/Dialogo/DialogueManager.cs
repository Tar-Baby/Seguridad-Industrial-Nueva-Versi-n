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
    [SerializeField] private GameObject panelXinfo;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    [SerializeField] private GameObject boxCollider;

    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

  //  private static DialogueManager instance;

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
        boxCollider.GetComponent<BoxCollider>().enabled = false; // Para que no se pueda interactuar con el NPC durante un dialogo
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ImprimirContador();

        ContinueStory(); 

    }

    public void ExitDialogueMode() // NO puedo volver a interactuar con la persona
    {
        AnimatorMnager.contador = 0;
        Debug.Log("Conversacion terminada");
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

    }

    public void ExitDialogueModeAltX()  // Puedo volver a interactuar con la persona, la X
    {
        ExitDialogueMode();
        boxCollider.GetComponent<BoxCollider>().enabled = true;

    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            AnimatorMnager.contador++;
            DisplayChoices();
            ImprimirContador();
            Debug.Log("Conversacion continua");
        }
        else  //cuando ya no hay mas opciones que elegir
        {
            
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

     //   StartCoroutine(SelectFirstChoice());
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    public void ExitSiContador3panelX()
    {
        if (AnimatorMnager.contador == 3)
        {
            ExitDialogueMode();
            panelXinfo.SetActive(false);
        }
    }

    public void ExitSiContador3()
    {
        if (AnimatorMnager.contador == 3)
        {
            ExitDialogueMode();
        }
    }

    public void ExitSiContador4NOPersuadidoTutorial(Animator anim)   // NO termina conversacion definitivamente
    {
        if (AnimatorMnager.contador == 4 && (anim.GetBool("Persuadido") == false))

        {
            ExitDialogueModeAltX();
        }
    }

    public void ExitSiContador4Persuadido(Animator anim)   // termina conversacion definitivamente
    {
        if (AnimatorMnager.contador == 4 && (anim.GetBool("Persuadido") == true))   

        {
            ExitDialogueMode();
        }
    }

    public void ExitSiContador4()  // termina conversacion definitivamente
    {
        if (AnimatorMnager.contador == 4)
        {
            ExitDialogueMode();
        }

    }

    /*
    private IEnumerator SelectFirstChoice() 
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    } */


    //recordatorio revisar si al presionar en el personaje de nuevo se reinicia el dialogo
    //En vez de usar un Dialogue Trigger usamos el On Click Event
}
