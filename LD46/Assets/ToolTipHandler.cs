using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ToolTipHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tooltipText;
    [SerializeField] private float showTime = 3.0f;
    private float showTimer = 0f;
    private bool lastFrameActive = false;
    public static ToolTipHandler instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else Debug.LogWarning("2 ToolTipHandlers");
    }

    // Update is called once per frame
    void Update()
    {
        if(showTimer > 0)
        {
            showTimer -= Time.deltaTime;
            lastFrameActive = true;
        }
        else if(lastFrameActive)
        {
            showTimer = 0;
            lastFrameActive = false;
            tooltipText.text = "";
        }
    }

    public void SetText(string text)
    {
        tooltipText.text = text;
        showTimer = showTime;
    }
}
