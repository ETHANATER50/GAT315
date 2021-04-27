using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSelect : MonoBehaviour
{
    [System.Serializable]
    public struct PanelInfo
    {
        public GameObject panel;
        public Button button;
        public KeyCode keyCode;
    }

    public KeyCode toggleKey;
    public GameObject panel;
    public PanelInfo[] panelInfos;

    void Start()
    {
        foreach (var panelInfo in panelInfos)
        {
            panelInfo.button.onClick.AddListener(delegate { buttonEvent(panelInfo); });
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            panel.SetActive(!panel.activeSelf);
        }

        foreach (var panelInfo in panelInfos)
        {
            if (Input.GetKeyDown(panelInfo.keyCode))
            {
                setPanelActive(panelInfo);
            }
        }
    }

    void setPanelActive(PanelInfo panelInfo)
    {
        for (int i = 0; i < panelInfos.Length; i++)
        {
            bool active = panelInfos[i].Equals(panelInfo);
            panelInfos[i].panel.SetActive(active);
        }
    }

    void buttonEvent(PanelInfo panelInfo)
    {
        setPanelActive(panelInfo);
    }
}
