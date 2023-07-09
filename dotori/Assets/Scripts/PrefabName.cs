using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabName : MonoBehaviour
{
    public Text name;
    public Text studentID;
    public GameObject prefab;

    void Start()
    {
        
    }
    public void Change(string newname, string newstudentID)
    {
        name.text = newname;
        studentID.text = newstudentID;
    }
}
