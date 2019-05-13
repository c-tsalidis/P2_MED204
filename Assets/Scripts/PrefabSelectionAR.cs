using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// In charge of managing the ShipAR scene
/// Shows the parts of the ship in AR using the Vuforia software
/// </summary>
public class PrefabSelectionAR : MonoBehaviour
{

    // private variables
    
    // the name of the prefab
    private string prefabName;
    // to load the scenes depending on which part of the ship is being highlighted
    private Manager managerObject;

    // [SerializeField] used to be able to view and modify the variable directly in the Unity Editor

    // the efficiencies of each subject
    [SerializeField]
    private int [] efficiencies;
    // the minimum efficiency required to have the finished version of the part
    [SerializeField]
    private int minumumEfficiencyToBeFinished = 75;
    // to check whether or not the part of the ship is finished 
    // (efficiency of the subject the part belongs to is higher than the minimum efficiency)
    [SerializeField]
    private bool [] prefabIsFinished;
    
    
    // public variables

    /// <summary>
    /// the string that shows the status of the pointing function.
    /// specifically, displays the name of the part of that is being pointed at by the user.
    /// as well as the subject corresponding to that part.
    /// if the user is not pointing at any part its value will be: "Point at a part".
    /// </summary>
    public static string statusOfText = "Pege på en del";
    // the text that displays the statusOfText string to the user 
    public Text text; 

    // the prefabs of each part of the boat
    public GameObject [] prefabs;
    // the materials of each part --> Blueprint, Highlighted, Finished
    public Material [] materials;

    // checks wether or not a part is being selected
    // let's say for example that the user is pointing at the Hull
    // then --> hull.PrefabSelectionAR.isSelected = true
    // it's false by default
    public bool [] isSelected;

    // the scene names corresponding to each part 
    public string [] sceneLoadStrings;



    // Start is called before the first frame update
    void Start()
    {
        // get all the efficiencies from the keys stored in the device corresponding to each subject
        // by default their value is 0
        efficiencies[0] = PlayerPrefs.GetInt("Efficiency Maths");
        efficiencies[1] = PlayerPrefs.GetInt("Efficiency Physics");
        efficiencies[2] = PlayerPrefs.GetInt("Efficiency Biology");
        efficiencies[3] = PlayerPrefs.GetInt("Efficiency Chemistry");
        efficiencies[4] = PlayerPrefs.GetInt("Efficiency Geography");

        // goes through all the efficiencies
        for(int i = 0; i < efficiencies.Length; i++)
        {
            // if the efficiency is higher than the minimum efficiency that the user has to score
            // for the prefab to be textured (with the finished material)
            if(efficiencies[i] >= minumumEfficiencyToBeFinished)
            {
                // the part is finished, so it would activate the finished prefab of the part
                prefabIsFinished[i] = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        // sets the text on screen to be the same as the status of the text string
        text.text = statusOfText;

        // goes through all the parts of the ship
        for(int i = 0; i < prefabs.Length; i++)
        {
            // Makes sure that by default they're nor being selected
            isSelected[i] = false;
        }

        // This script is based on this tutorial: 
        // https://www.youtube.com/watch?v=hi_KDpC1nzk&t=317s

        // to use the click / touch input on the parts of the ship
        // If the user clicks on or touches the hull for example, then it will select the hull prefab
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
        // if the user is selecting it with the camera's view (by default, as the )
        else
        {
            // how to send a ray from the camera's center (for the crosshair):
            // https://docs.unity3d.com/ScriptReference/Camera.ViewportPointToRay.html
            // 0.5f in x and 0.5f in y in the center of the screen (goes from (0,0) to (1,1))
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            // to visualize the ray in red color in the Unity Editor onRuntime
            Debug.DrawRay(Camera.main.gameObject.transform.position, Vector3.forward, Color.red);
            // select the part of the ship that the ray is colliding with
            selectPrefab(ray);
        }


        UpdatePrefabs();
             
    }

    // select the part of the ship that the ray is colliding with
    private void selectPrefab(Ray ray)
    {
        // the hit of the ray
        RaycastHit hit;
        // if the ray collides with a gameobject, it sends out the hit gameobject (which is the gameobject it collided with)
        if(Physics.Raycast(ray, out hit))
        {
            // make a gameobject out of the part the ray hit with
            GameObject hitPrefab = hit.transform.gameObject;
            // Debug.Log("Hit " + hitPrefab);
            // goes trough all the ship parts (prefabs)
            for(int i = 0; i < prefabs.Length; i++)
            {
                // if the part's tag is the same as the one in the array with index i
                if(hitPrefab.tag == prefabs[i].tag)
                {
                    // mark that part of the ship as selected
                    isSelected[i] = true;
                    // set the text of the game to the name of the part
                    text.text = hitPrefab.name;
                }
                // if the ray doesn't hit the a gameobject with the the tag the same as the one in the prefab array with index of the current i
                else if(hitPrefab.tag != prefabs[i].tag)
                {
                    // mark the part of the boat as not being selected
                    isSelected[i] = false;
                }
            }
        }
        else
        {
            // the ray didn't hit anything
            // Debug.Log("Ray hit is null");
        }
    }


    // In charge of showing the part of the boat as the current verision of it
    // If the part is:
    // not selected --> show the blueprint version of it
    // selected --> show the highlighted version of it
    // finished --> show the finished version of it
    private void UpdatePrefabs()
    {
        // goes through all the parts of the boat
        for (int i = 0; i < prefabs.Length; i++)
        {
            // make a selected bool for the current index of i in the isSelected array
            bool selected = isSelected[i];
            // make a isFinished bool for the current index of i in the isFinished array
            bool isFinished = prefabIsFinished[i];
            // make a GameObject for the current index of i in the prefab array
            GameObject prefab = prefabs[i];
            // if the prefab is finished
            if(isFinished == true)
            {
                // activate the finished version of the part
                prefab.transform.GetChild(2).gameObject.SetActive(true);
                // deactivate the blueprint version of the part
                prefab.transform.GetChild(0).gameObject.SetActive(false);
            }
            // if the prefab is NOT finished
            else
            {
                // deactivate the finished version of the part
                prefab.transform.GetChild(2).gameObject.SetActive(false);
                // activate the blueprint version of the part
                prefab.transform.GetChild(0).gameObject.SetActive(true);
            }
            // if the  part is being selected
            if(selected == true)
            {
                // activate the highlighted version of the part
                prefab.transform.GetChild(1).gameObject.SetActive(true);
                // deactivate the finished version of the part
                prefab.transform.GetChild(2).gameObject.SetActive(false);
            }
            // if the part is not being selected
            else
            {
                // deactivate the highlighted version of the part
                prefab.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    // loads the scene corresponding to the part that is being currently pointed at by the user (selected)
    // when the user clicks on the "select part" button
    public void selectButton()
    {
        // goes through all the parts of the ship
        for(int i = 0; i < prefabs.Length; i++)
        {
            // if the part is being selected
            if(isSelected[i] == true)
            {
                // load the scene corresponding to the part that is being pointed at(selected) by the user
                SceneManager.LoadScene(sceneLoadStrings[i]);
            }
        }
    }    

}
