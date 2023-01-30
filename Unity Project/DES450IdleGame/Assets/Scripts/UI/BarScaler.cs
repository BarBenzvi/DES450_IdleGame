using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScaler : MonoBehaviour
{
    public RectTransform.Axis ScaleAxis = RectTransform.Axis.Horizontal;

    public float MaxSize = 100f;

    public float CatchupSpeed = 0.8f;

    public float targetSize = 0.0f;
    float currSize = 0.0f;



    RectTransform rTransform;

    // Start is called before the first frame update
    void Awake()
    {
        rTransform = GetComponent<RectTransform>();
        currSize = targetSize;
    }

    void Update()
    {
        if (currSize != targetSize)
        {
            currSize = Mathf.Lerp(currSize, targetSize, CatchupSpeed * Time.deltaTime);
            rTransform.SetSizeWithCurrentAnchors(ScaleAxis, currSize);
            if (Mathf.Abs(targetSize - currSize) < Mathf.Epsilon)
            {
                currSize = targetSize;
                rTransform.SetSizeWithCurrentAnchors(ScaleAxis, currSize);
            }
        }
    }

    public void SetScale(float curr, float max)
    {
        float value = Mathf.Lerp(0, MaxSize, curr / max);

        if (curr <= 0.0f)
        {
            value = 0.0f;
        }
        else if (curr >= max)
        {
            value = MaxSize;
        }

        targetSize = value;

        //rTransform.SetSizeWithCurrentAnchors(ScaleAxis, value);
    }
}
