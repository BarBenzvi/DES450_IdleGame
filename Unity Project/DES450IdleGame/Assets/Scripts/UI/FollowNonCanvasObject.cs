using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowNonCanvasObject : MonoBehaviour
{
    public Vector3 posOffset = Vector3.zero;

    Transform followTransform;
    RectTransform rt = null;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (followTransform != null)
        {
            rt.position = followTransform.position;
            rt.localPosition += posOffset;
        }
    }

    public void SetFollowTransform(Transform t)
    {
        followTransform = t;
    }
}
