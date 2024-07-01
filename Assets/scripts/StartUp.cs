using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    [SerializeField] GameObject cont,newgame;
    private void Start()
    {
        if (File.Exists(Application.dataPath + "/save.json"))
        {
            cont.SetActive (true);
        }
        else
        {
            newgame.transform.position = cont.transform.position;
        }
    }
}
