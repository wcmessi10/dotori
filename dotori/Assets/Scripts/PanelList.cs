using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelList : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    
    // Start is called before the first frame update
    public void NextPanel()
    {
        panel2.SetActive(true);
        panel1.SetActive(false);
    }
    
}
