using UnityEngine;

public class FlashingObject : MonoBehaviour
{
    void Update()
    {
        var spriteRenderer = this.GetComponent<SpriteRenderer>();
        var color = spriteRenderer.color;
        var a = (Mathf.Sin(Time.time) + 1) / 2;

        spriteRenderer.color = new Color(color.r, color.g, color.b, a);
    }
}
