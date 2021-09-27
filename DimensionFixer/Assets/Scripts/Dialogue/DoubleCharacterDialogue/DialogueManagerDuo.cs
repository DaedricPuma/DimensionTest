using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerDuo : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public SpriteRenderer charSprite;
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<Sprite> charIcons;
    //public GameObject relatedButton;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
        charIcons = new Queue<Sprite>();
    }

    // Update is called once per frame

    public void StartDialogue(DialogueDuo dialogue)
    {
        animator.SetBool("IsOpen", true);

        //Debug.Log("Starting conversation with " + dialogue.name);

        //nameText.text = dialogue.name;

        sentences.Clear();
        names.Clear();
        charIcons.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach (Sprite charIcon in dialogue.charIcons)
        {
            charIcons.Enqueue(charIcon);
        }

        DisplayNextSentece();
        DisplayNextName();
        DisplayNextIcon();
    }

    public void DisplayNextName()
    {
        if (names.Count == 0)
        {
            EndDialogue();
            return;
        }

        string name = names.Dequeue();
        //StopAllCoroutines();
        nameText.text = name;
    }

    public void DisplayNextSentece()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayNextIcon()
    {
        if (charIcons.Count == 0)
        {
            EndDialogue();
            return;
        }

        Sprite charIcon = charIcons.Dequeue();
        //StopAllCoroutines();
        charSprite.sprite = charIcon;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation");
        //relatedButton.SetActive(false);
    }
}
