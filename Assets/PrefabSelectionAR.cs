using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabSelectionAR : MonoBehaviour
{
    private string prefabName;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
                default:
                        break;
            }
        }
    }
}
