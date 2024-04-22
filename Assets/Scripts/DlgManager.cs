using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DlgManager : MonoBehaviour
{
    public Queue<string> sentences;

    public Text nameTxt;
    public Text dlgTxt;

    public Animator animator;
    private bool isOpen = false;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDlg(Dialogue dlg)
    {
        Debug.Log("the voices in your head are logging this complaint");

        nameTxt.text = dlg.name;

        sentences.Clear();

        foreach (string sentence in dlg.sentences)
        {
            sentences.Enqueue(sentence);
        }

        NextSntc();
    }

    public void NextSntc()
    {
        if(sentences.Count == 0)
        {
            return;
        }

        string sntc = sentences.Dequeue();
        dlgTxt.text = sntc;
    }
}
