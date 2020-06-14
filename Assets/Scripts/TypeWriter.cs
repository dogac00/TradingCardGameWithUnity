using System.Collections;
using TMPro;
using UnityEngine;

public class TypeWriter : MonoBehaviour
{
    public void ChangeText(string text)
    {
        var tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.text = "";

        StartCoroutine(Writer());

        IEnumerator Writer()
        {
            for (int i = 0; i <= text.Length; i++)
            {
                tmp.text = text.Substring(0, i);
                yield return new WaitForSeconds(0.02F);
            }
        }
    }
}
