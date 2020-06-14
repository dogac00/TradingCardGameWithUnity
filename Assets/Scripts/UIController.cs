using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public InputField Input1, Input2;

    public void Submit()
    {
        var name1 = Input1.text;
        var name2 = Input2.text;

        GameObject.FindGameObjectWithTag("Player1").name = name1;
        GameObject.FindGameObjectWithTag("Player2").name = name2;
    }
}
