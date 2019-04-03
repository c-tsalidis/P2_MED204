using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabSelectionAR : MonoBehaviour
{

    // This script is based on this tutorial:
    // https://www.youtube.com/watch?v=hi_KDpC1nzk&t=317s

    private string prefabName;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Point at a cube";
        // if it's a phone
        if((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))
        {
            Debug.Log("it's a click on the phone");
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            selectPrefab(ray);
        }
        // if it's a computer with a mouse
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("it's a click on the computer with the mouse");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            selectPrefab(ray);
        }
        // if the user is selecting it with the camera's view
        else
        {
            // how to send a ray from the camera's center:
            // https://docs.unity3d.com/ScriptReference/Camera.ViewportPointToRay.html
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); // 0.5f in x and 0.5f in y in the center of the screen (goes from (0,0) to (1,1))
            selectPrefab(ray);
        }
        
        
    }

    private void selectPrefab(Ray ray)
    {
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            prefabName = hit.transform.name;
            switch(prefabName)
            {
                case "Green Cube":
                            Debug.Log(prefabName + " Touched");
                            text.text = prefabName + " Touched";
                            break;
                case "Red Cube":
                            Debug.Log(prefabName + " Touched");
                            text.text = prefabName + " Touched";
                            break;
                default:    text.text = "Point at \n a cube";
                        break;
            }
        }
    }
}
