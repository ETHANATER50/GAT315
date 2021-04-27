using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextUI : MonoBehaviour
{
    public StringData data = null;
    public Text label = null;
    private float timer = 0;

    private void OnValidate()
    {
        if (data != null)
        {
            name = data.name;
            label.text = name;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(timer > .25)
        {
            label.text = data.value;
            timer = 0;
        }
    }

}
