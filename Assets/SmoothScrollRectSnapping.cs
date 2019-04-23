using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothScrollRectSnapping : MonoBehaviour
{

    // made with this: Mathf.SmoothDamp
    // https://docs.unity3d.com/ScriptReference/Mathf.SmoothDamp.html

    [SerializeField]
    private Scrollbar scrollBar; 
    // [SerializeField]
    // private Transform target;
    // [SerializeField]
    private float smoothTime = 0.3f;
    [SerializeField]
    private float yVelocity = 0.0f;

    [SerializeField]
    private float targetValue;

    [SerializeField]
    private float currentVelocity;

    // Update is called once per frame
    void Update()
    {
        float value = scrollBar.value;

        if(value > 0 && value < 0.25)
        {
            targetValue = 0.25f;
        }
        else if(value > 0.25 && value < 0.5)
        {
            targetValue = 0.55f;
        }
        else if(value > 0.5 && value < 0.75)
        {
            targetValue = 0.75f;
        }
        else
        {
            targetValue = 1;
        }

        float newValue = Mathf.SmoothDamp(value, targetValue, ref currentVelocity, smoothTime);
        scrollBar.value = newValue;
        /*
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
         */
    }

}
