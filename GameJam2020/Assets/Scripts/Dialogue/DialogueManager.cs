using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
  private Queue<string> sentences;
  public GameObject dialogueBox;
  public Text nameText;
  public Text  dialogueText;
  public int textSpeed;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
      nameText.text = dialogue.name;
      sentences.Clear();
      dialogueBox.SetActive(true);
      foreach (string sentence in dialogue.sentences)
      {
        sentences.Enqueue(sentence);
      }
      DisplayNextSentence();
    }
    public void DisplayNextSentence ()
    {
      if (sentences.Count == 0)
      {
        EndDialogue();
        return;
      }
      string sentence = sentences.Dequeue();
      //dialogueText.text = sentence;
      StopAllCoroutines();
      StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
      dialogueText.text = "";
      foreach (char letter in sentence.ToCharArray())
      {
        dialogueText.text += letter;
        yield return textSpeed;
      }
    }
    void EndDialogue()
    {
      Debug.Log("End of conversation");
      dialogueBox.SetActive(false);
    }
}
