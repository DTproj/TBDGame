using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlgTrigger : MonoBehaviour
{
    public Dialogue dlg;

    public void TriggerDlg()
    {
        FindObjectOfType<DlgManager>().StartDlg(dlg);
    }
}
