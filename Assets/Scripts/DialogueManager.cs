using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> nameslist;

    public Dialogue dialup;
    public TextMeshProUGUI dialbox;
    public TextMeshProUGUI namebox;
    public bool isTalking;
    public Image RegUI;

    public Animator dialAnimator;

    //Government Representative Dialogue  move this and mobdial to singular dialogue manage class for easier usage and cleaner code.
    public Dialogue[] govdial;
    public bool[] govcheck;
    public int govcount;

    public Dialogue[] tutdial;
    public bool[] tutcheck;
    public int tutcount;

    public Dialogue[] mobdial;
    public bool[]  mobcheck;
    public int mobcount;


    void Start ()
    {
        nameslist = new Queue<string>();
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        sentences.Clear();
        isTalking = true;
        RegUI.gameObject.SetActive(false);
        dialAnimator.SetBool("dialin", true);
        foreach (string sentence in dialogue.lines)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string name in dialogue.names)
        {
            nameslist.Enqueue(name);
        }
        dialbox.SetText(sentences.Dequeue());
        namebox.SetText(nameslist.Dequeue());
    }


    public void DisplayNextSentence()
    {
        StartCoroutine(AppearDelay());

            EndDialogue();
            dialAnimator.SetBool("dialin", false);
        return;
    }

    public void Update()
    {
        if (Input.GetKeyDown("u")){
            StartDialogue(dialup);
        }
        if (isTalking == true)
        {
            if (Input.GetKeyDown("i") && sentences.Count == 0)
            {
                DisplayNextSentence();
            }
            else if (Input.GetKeyDown("i"))
            {
                dialbox.SetText(sentences.Dequeue());
                namebox.SetText(nameslist.Dequeue());
            }
        }
    }

    IEnumerator AppearDelay()
    {
        yield return new WaitForSeconds(1);
        RegUI.gameObject.SetActive(true);
    }

    private  void EndDialogue()
    {
        isTalking = false;
        //end dialogue
    }
}
