using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;

    public Animator animator;

    private Queue<string> sentences;

    [SerializeField]
    private GameObject playerObject;

    public Dialog Dialog;

    private bool dialogHasBeenTrigged = false;

    void Start()
    {
        sentences = new Queue<string>();
        animator.speed = 0.3f;
    }

    public void OnTriggerEnter(Collider other)
    {
       if (!dialogHasBeenTrigged && other.name != "Limb(Clone)")
        {
            playerObject.GetComponent<PlayerController>().freezePlayer = true;

            dialogHasBeenTrigged = true;
            this.enabled = false;

            StartDialog(Dialog);
        }
    }

    public void StartDialog(Dialog dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.Name;

        sentences.Clear();

        foreach (string sentence in dialogue.Sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            Thread.Sleep(50);
            dialogText.text += letter;
            yield return null;
        }
    }

    void EndDialog()
    {
        animator.SetBool("IsOpen", false);
        playerObject.GetComponent<PlayerController>().freezePlayer = false;
    }

   
}
