using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("Dialogues Node")]
    public DialogueNode startDialogueNode;
    public DialogueNode endDialogueNode;

    [Header("Cloasing Dialogue")]
    public bool hasClosingDialogue;
    [SerializeField] DialogueNode closingDialogueNode;

    [Header("UI GameObjects")]
    [SerializeField] GameObject choiceParent;

    // UI Elements
    [SerializeField] GameObject nextCloseGO;
    [SerializeField] GameObject closeableGO;

    [Header("Character INFOs")]
    [SerializeField] TextMeshProUGUI dialogueBoxTXT;
    [SerializeField] TextMeshProUGUI nameTXT;
    [SerializeField] Image characterIMG;

    // settings
    [Header("Type Speed")]
    [SerializeField] float typeSpeed = 0.02f;

    [SerializeField] bool playWhenStart;

    [HideInInspector]
    public DialogueNode currentDialougeNode;        //current dialogue node being displayed

    [HideInInspector]
    public CharacterDialogueProfile currentCharDlgProfile; //current character dialogue profile

    TextMeshProUGUI nextCloseTXT;
    Button nextCloseBTN;

    [HideInInspector]
    public bool isTyping = false;

    bool isDialogueActive = false;
    bool playedClosingDialogue = false;

    Coroutine typeTextCoro;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (startDialogueNode != null)
        {
            currentDialougeNode = startDialogueNode;
        }

        nextCloseTXT = nextCloseGO.GetComponentInChildren<TextMeshProUGUI>();
        nextCloseBTN = nextCloseGO.GetComponent<Button>();

        if (playWhenStart == true)
        {
            DisplayDialogue(startDialogueNode);
        }

        if(!playWhenStart && CheckHasClosingDialogue() && !playedClosingDialogue) 
        {
            DisplayDialogue(closingDialogueNode);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Old Input Handling
        //if (!isTyping && !isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        //{
        //    DisplayDialogue(startDialogueNode);
        //    isDialogueActive = true;
        //}

        // Skip typing effect on mouse click
        if (isTyping && Input.GetKeyDown(KeyCode.Mouse0))
        {
            SkipTyping();
            CheckForSummuryNote(currentDialougeNode);
        }

        ////New Input Handling
        //if(Keyboard.current.spaceKey.wasPressedThisFrame && !isTyping)
        //{
        //    DisplayDialogue(startDialogueNode);
        //}

        //if (isTyping && Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    SkipTyping();
        //}
    }

    public void DisplayDialogue(DialogueNode node)
    {
        currentDialougeNode = node;
        closeableGO.SetActive(true);

        isDialogueActive = true;

        characterIMG.sprite = node.character.GetPortraitByEmotion(node.emotion);
        nameTXT.text = node.character.characterName;

        typeTextCoro = StartCoroutine(TypeText(node));
    }

    IEnumerator TypeText(DialogueNode node)
    {
        isTyping = true;
        dialogueBoxTXT.text = "";

        foreach (char letter in node.dialogueText.ToCharArray())
        {
            dialogueBoxTXT.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
        isTyping = false;

        CheckForSummuryNote(node);
        AddChoices(node);
    }

    void CheckForSummuryNote(DialogueNode node)
    {
        // Add notepad summary if available
        if (node.hasNotepadSummary)
        {
            if (NotepadManager.Instance == null)
            {
                return;
            }

            NotepadManager.Instance.AddSummaryNote();
        }
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
        isDialogueActive = false;
        closeableGO.SetActive(false);
        nextCloseGO.SetActive(false);

        // set current dialogue node to loop node for future dialogues
        if (currentCharDlgProfile != null)
        {
            currentCharDlgProfile.SetLoop();
        }

        // Notify GameManager that dialogue has ended
        CheckForDialogueEnd();
    }

    void SkipTyping()
    {
        StopCoroutine(typeTextCoro);
        dialogueBoxTXT.text = currentDialougeNode.dialogueText;
        isTyping = false;
        AddChoices(currentDialougeNode);
    }

    public void UpdateDialogueSettings(CharacterDialogueProfile charDlgProfile)
    {
        currentCharDlgProfile = charDlgProfile;

        startDialogueNode = charDlgProfile.GetStartNode();
        endDialogueNode = charDlgProfile.GetEndNode();

        currentDialougeNode = startDialogueNode;
    }

    public void CheckForDialogueEnd()
    {
        if (currentDialougeNode == endDialogueNode)
        {
            if (GameManager.Instance != null)
            {

                // Notify GameManager that dialogue has ended
                GameManager.Instance.dialogueEndCount++;

                if (CheckHasClosingDialogue() &&
                    GameManager.Instance.IsAllDialogueEnded() &&
                    playedClosingDialogue == false)
                {
                    playedClosingDialogue = true;
                    DisplayDialogue(closingDialogueNode);

                    return;
                }

                GameManager.Instance.HasAllDialogueEnded();
            }
        }

        if (CheckHasClosingDialogue() && playedClosingDialogue)
        {
            GameManager.Instance.HasAllDialogueEnded();
        }
    }

    bool CheckHasClosingDialogue()
    {
        if (hasClosingDialogue == true && closingDialogueNode != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
