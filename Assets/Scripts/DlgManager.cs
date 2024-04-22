using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgManager : MonoBehaviour
{
    public Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDlg(Dialogue dlg)
    {
        Debug.Log("the voices in your head are logging this complaint");
    }
}
