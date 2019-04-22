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
    public static string statusOfText = "Point at a part";

    public Text text;

    public GameObject [] prefabs;
    public Material [] materials;

    public bool [] isSelected;

    private Manager managerObject;
    public string [] sceneLoadStrings;


/*
    [SerializeField]
    enum ShipParts {Hull, Engine, WeatherStation, GPS, Net};
 */
    
    
    
        [SerializeField]
        private GameObject [] EngineChildPrefabs;
        [SerializeField]
        private GameObject [] HullChildPrefabs;
        [SerializeField]
        private GameObject [] WeatherStationChildPrefabs;
        [SerializeField]
        private GameObject [] GPSChildPrefabs;
        [SerializeField]
        private GameObject [] NetChildPrefabs;
    

    /*
        [SerializeField]
        private GameObject [][] ShipPrefabs = new GameObject[EngineChildPrefabs][];
    */


/*
    [SerializeField]
    private GameObject [] HullPrefabs;
    [SerializeField]
    private GameObject [] EnginePrefabs;
    [SerializeField]
    private GameObject [] WeatherStationPrefabs;
    [SerializeField]
    private GameObject [] GPSPrefabs;
    [SerializeField]
    private GameObject [] NetPrefabs;
    public GameObject [][] prefabsMatrix;

 */
    [SerializeField]
    // private ShipPartManager shipPartManager;

    // private ShipPartManager.State shipPartState;

    // Start is called before the first frame update
    void Start()
    {
        // shipPartState = ShipPartManager.State.Blueprint;

        // Debug.Log("The image target has " + gameObject.transform.childCount + " children");
        // Debug.Log("The engine has " + gameObject.transform.GetChild(5).childCount + " children");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = statusOfText;


        for(int i = 0; i < prefabs.Length; i++)
        {
            changeMaterial(i, 0);
            isSelected[i] = false;
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
            Debug.DrawRay(Camera.main.gameObject.transform.position, Vector3.forward, Color.red);
            selectPrefab(ray);
        }



/*
    // THIS WORKS!!!!
        if(text.text == "Engine")
        {
            shipPartManager.shipPart[1].SetActive(true);
        }
        else
        {
            shipPartManager.shipPart[1].SetActive(false);
        }
 */
        // UpdatePrefabs();


        for (int i = 0; i < prefabs.Length; i++)
        {
           // if(prefabs[i].transform.childCount > 0)
            {
                if(isSelected[i] == true)
                {
                    // prefabs[i].transform.GetChild(1).gameObject.SetActive(true);
                    if(prefabs[i].tag == "Engine")
                    {
                        // EngineChildPrefabs[1].SetActive(true);
                        changeMaterial(EngineChildPrefabs[0], 1);
                    }
                }
                else{changeMaterial(EngineChildPrefabs[0], 0);}
                /*
                else
                {
                    // prefabs[i].transform.GetChild(1).gameObject.SetActive(false);
                    EngineChildPrefabs[1].SetActive(false);
                }
                 */
            }
        }
             
    }

    private void selectPrefab(Ray ray)
    {
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            prefabName = hit.transform.name;
            GameObject hitPrefab = hit.transform.gameObject;
            Debug.Log("Hit " + hitPrefab);
            for(int i = 0; i < prefabs.Length; i++)
            {
                // if(prefabName == prefabs[i].name)
                /*
                if(hitPrefab == prefabs[i])
                {
                    
                    // Debug.Log("Found " + prefabName + " which is " + prefabs[i].name);
                    Debug.Log("Found " + hitPrefab + " which is " + prefabs[i].name);
                    changeMaterial(i, 1);
                    ChangePrefab(prefabs[i], ShipPartManager.State.Highlighted);
                    // ChangePrefab(prefabs[i], 1, true);
                    // ChangePrefab(prefabs[i], 0, false);
                    // changeChildrenMaterial(i, 1);
                    isSelected[i] = true;
                    // text.text = prefabName;
                    // text.text = hitPrefab.name;
                    statusOfText = hitPrefab.name;
                }
                 */
                if(hitPrefab.tag == prefabs[i].tag)
                {
                    
                    // Debug.Log("Found " + prefabName + " which is " + prefabs[i].name);
                    // Debug.Log("Found " + hitPrefab + " which is " + prefabs[i].name);
                    if(hitPrefab.tag != "Engine") changeMaterial(i, 1);
                    isSelected[i] = true;
                    // hitPrefab.GetComponent<ShipPartManager>().isSelected = isSelected[i];
                    text.text = hitPrefab.name;
                    // shipPartState = ShipPartManager.State.Highlighted;
                    // ChangePrefab(hitPrefab, shipPartState); // change to highlight state
                    // ChangePrefab(prefabs[i], 1, true);
                    // ChangePrefab(prefabs[i], 0, false);
                    // changeChildrenMaterial(i, 1);
                    // text.text = prefabName;
                    // statusOfText = hitPrefab.name;
                }
                else if(hitPrefab.tag != prefabs[i].tag)
                {
                    if(hitPrefab.tag != "Engine") changeMaterial(i, 0);
                    isSelected[i] = false;
                    // hitPrefab.GetComponent<ShipPartManager>().isSelected = isSelected[i];
                    // shipPartState = ShipPartManager.State.Blueprint;
                    // ChangePrefab(hitPrefab, shipPartState); // change to blueprint state
                    // ChangePrefab(prefabs[i], 1, false);
                    // ChangePrefab(prefabs[i], 0, true);
                    // changeChildrenMaterial(i, 0);
                }
                // hitPrefab.GetComponent<ShipPartManager>().isSelected = isSelected[i];
                // Debug.Log("isSelected[i]  is the same as hitPrefab...isSelected: " + (hitPrefab.GetComponent<ShipPartManager>().isSelected == isSelected[i]));
            }
        }
        else
        {
            Debug.Log("Ray hit is null");
        }
    }

    private void changeMaterial(int prefabNumber, int materialNumber)
    {
        prefabs[prefabNumber].GetComponent<Renderer>().material = materials[materialNumber];
        /*
            Debug.Log("Prefab children number > 0: " + (prefabs[prefabNumber].transform.childCount > 0));
            if(prefabs[prefabNumber].transform.childCount > 0) // to change the material of the prefab's children components
            {
                Renderer renderer = GetComponentInChildren<Renderer>();
                renderer.material = materials[materialNumber];
                Debug.Log("Changed the material to " + materials[materialNumber]);
            }
        */
    }

    private void changeMaterial(GameObject prefab, int materialNumber)
    {
        prefab.GetComponent<Renderer>().material = materials[materialNumber];
    }


/*
    private void ChangePrefab(GameObject parentPrefab, int ChildPrefabNumber, bool activate)
    {
        Debug.Log("Parent prefab: " + parentPrefab.name + "'s child count: " + parentPrefab.transform.childCount);
        if(parentPrefab.transform.childCount > 0)
        {
            parentPrefab.transform.GetChild(ChildPrefabNumber).gameObject.SetActive(activate);
        }
        
            foreach (GameObject prefab in prefabs)
            {
                if(prefab == parentPrefab)
                {

                }
            }
         
    }
 */

    private void ChangePrefab(GameObject prefab, ShipPartManager.State state)
    {
        // for(int i = 0; i < prefabs.Length; i++)
        // Debug.Log("------------------------------- " + prefab);
        if(prefab.tag == "Engine")
        {
            // Debug.Log(prefab.transform.childCount);
            prefab.SendMessage("ChangePrefab", state);
        }
        else
        {
            Debug.Log("Tag not found");
        }
        /*
        switch(prefabTag)
        {
            case "Engine": prefab.SendMessage("ChangePrefab", state);
                            break;
            default:    Debug.Log("Layer not found");
                        break;
        }
         */
    }

    private void ChangePrefab(GameObject prefab, int prefabState)
    {
        prefab.SendMessage("ChangePrefab", prefab);
    }


    private void UpdatePrefabs()
    {
        
        if(gameObject.transform.childCount > 0)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                GameObject parentPrefab = gameObject.transform.GetChild(i).gameObject;
                Debug.Log("Prefab " + parentPrefab.name + " has " + parentPrefab.transform.childCount + " children");
                if(parentPrefab.transform.childCount > 0)
                {
                    Debug.Log(parentPrefab.name + " is selected: " + parentPrefab.GetComponent<ShipPartManager>().isSelected);
                    if(parentPrefab.GetComponent<ShipPartManager>().isSelected == true)
                    {
                        parentPrefab.transform.GetChild(1).gameObject.SetActive(true);
                        //  for (int j = 0; j < parentPrefab.transform.childCount; j++)
                        //  {
                        //      GameObject childPrefab = parentPrefab.transform.GetChild(j).gameObject;
                            /*
                            for (int z = 0; z < parentPrefab.GetComponent<ShipPartManager>().shipPart.Length; z++)
                            {
                                if(parentPrefab.GetComponent<ShipPartManager>().shipPart[z] == childPrefab)
                                {
                                    childPrefab.GetComponent<ShipPartManager>().State
                                }
                            }
                            */
                            // Debug.Log(childPrefab.name  + " has " + childPrefab.transform.childCount + "children");
                        //  }
                    }
                    else
                    {
                        parentPrefab.transform.GetChild(1).gameObject.SetActive(false);
                    }
                }
            }
        }

    }



    /*
    
    
        INSTEAD OF CHANGING THE MATERIAL / COLOR... CHANGE THE GAMEOBJECT / PREFAB
    
     */



    private void changeChildrenMaterial(GameObject [] prefabArray, int materialNumber)
    {
        foreach (GameObject item in prefabArray)
        {
            item.GetComponent<Renderer>().material = materials[materialNumber];
        }
    }

    private void changeChildrenMaterial(int prefabNumber, int materialNumber)
    {
        Renderer [] renderer = prefabs[prefabNumber].GetComponentsInChildren<Renderer>();
        foreach (Renderer item in renderer)
        {
            item.material = materials[materialNumber];
            Debug.Log("Changed child materials: " + (item.material == materials[materialNumber]));
        }
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
