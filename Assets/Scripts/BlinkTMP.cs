using UnityEngine;
using TMPro;

public class BlinkTMP : MonoBehaviour
{
    public float speed = 1f;
    private TextMeshProUGUI tmp;
    private Color baseColor;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        baseColor = tmp.color;
    }

    void Update()
    {
        float alpha = Mathf.Abs(Mathf.Sin(Time.time * speed));
        tmp.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
    }
}
