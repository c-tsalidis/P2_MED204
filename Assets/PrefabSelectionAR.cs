using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrefabSelectionAR : MonoBehaviour
{

    // This script is based on this tutorial:
    // https://www.youtube.com/watch?v=hi_KDpC1nzk&t=317s

    private string prefabName;
    private string statusOfText = "Point at a part";

    public Text text;

    public GameObject [] prefabs;
    public Material [] materials;

    public bool [] isSelected;

    private Manager managerObject;
    public string [] sceneLoadStrings;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = statusOfText;

        for(int i = 0; i < prefabs.Length; i++)
        {
            changeMaterial(i, 0);
            // isSelected[i] = false;
        }

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
            for(int i = 0; i < prefabs.Length; i++)
            {
                if(prefabName == prefabs[i].name)
                {
                    Debug.Log("Found " + prefabName + " which is " + prefabs[i].name);
                    changeMaterial(i, 1);
                    isSelected[i] = true;
                    text.text = prefabName;
                }
                else
                {
                    changeMaterial(i, 0);
                    isSelected[i] = false;
                }
            }
        }
    }

    private void changeMaterial(int prefabNumber, int materialNumber)
    {
        prefabs[prefabNumber].GetComponent<Renderer>().material = materials[materialNumber];
    }

    public void selectButton()
    {
        for(int i = 0; i < prefabs.Length; i++)
        {
            if(isSelected[i] == true)
            {
                // managerObject.LoadScene(sceneLoadStrings[i]);
                SceneManager.LoadScene(sceneLoadStrings[i]);
            }
        }
    }
}
