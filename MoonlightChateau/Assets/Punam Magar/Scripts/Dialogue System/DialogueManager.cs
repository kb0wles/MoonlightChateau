using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] DialogueNode startDialogueNode;

    [SerializeField] GameObject choiceParent;

    // UI Elements
    [SerializeField] GameObject nextCloseGO;
    [SerializeField] GameObject closeableGO;

    // settings
    [SerializeField] float typeSpeed = 0.02f;

    [SerializeField] TextMeshProUGUI dialogueBoxTXT;
    [SerializeField] Image characterIMG;

    DialogueNode currentDialougeNode;
    TextMeshProUGUI nextCloseTXT;
    Button nextCloseBTN;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentDialougeNode = startDialogueNode;
        nextCloseTXT = nextCloseGO.GetComponentInChildren<TextMeshProUGUI>();
        nextCloseBTN = nextCloseGO.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DisplayDialogue(startDialogueNode);
        }
    }

    public void DisplayDialogue(DialogueNode node)
    {
        currentDialougeNode = node;
        closeableGO.SetActive(true);

        characterIMG.sprite = node.character.GetPortraitByEmotion(node.emotion);

        StartCoroutine(TypeText(node));
    }

    IEnumerator TypeText(DialogueNode node)
    {
        dialogueBoxTXT.text = "";

        foreach (char letter in node.dialogueText.ToCharArray()) 
        {
            dialogueBoxTXT.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        AddChoices(node);
    }

    void AddChoices(DialogueNode node) 
    {
        if (node.choices.Count == 0) 
        {
            // End of dialogue
            // Handle end of dialogue here
            //Close button
            AddOnClickClose();
        }
        if (node.choices.Count == 1) 
        {
            //Linear Dialogue
            //Add next dialogue button
            //Add listener to button to go to next dialogue
            AddOnClickNext(node);
        }
        else 
        {
            //Multiple Choices
            //Generate choice buttons
        }
    }

    void OnClickNext(DialogueNode node) 
    {
        nextCloseBTN.onClick.RemoveAllListeners();
        DisplayDialogue(node.choices[0].nextNode);
        nextCloseGO.SetActive(false);
    }

    void AddOnClickNext(DialogueNode node) 
    {
        nextCloseGO.SetActive(true);
        nextCloseTXT.text = "NEXT";
        nextCloseBTN.onClick.AddListener(() => OnClickNext(node));
    }

    void AddOnClickClose() 
    {
        nextCloseGO.SetActive(true);
        nextCloseTXT.text = "CLOSE";
        nextCloseBTN.onClick.AddListener(OnClickClose);
    }

    void OnClickClose() 
    {
        nextCloseBTN.onClick.RemoveAllListeners();
        closeableGO.SetActive(false);
        nextCloseGO.SetActive(false);
    }
}
