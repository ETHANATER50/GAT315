using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor : MonoBehaviour
{
    public Action[] actions;

    public void startAction()
    {
        actions[0].startAction();
    }

    public void stopAction()
    {
        actions[0].stopAction();
    }
}
