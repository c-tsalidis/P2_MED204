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
    public static string statusOfText = "Pege på en del";

    public Text text;

    public GameObject [] prefabs;
    public Material [] materials;

    public bool [] isSelected;

    private Manager managerObject;
    public string [] sceneLoadStrings;

    [SerializeField]
    private int [] efficiencies;


    [SerializeField]
    private int minumumEfficiencyToBeFinished = 75;
    [SerializeField]
    private bool [] prefabIsFinished;


    // Start is called before the first frame update
    void Start()
    {
        // get all the efficiency from the keys stored in the device
        // by default their value is 0
        efficiencies[0] = PlayerPrefs.GetInt("Efficiency Maths");
        efficiencies[1] = PlayerPrefs.GetInt("Efficiency Physics");
        efficiencies[2] = PlayerPrefs.GetInt("Efficiency Biology");
        efficiencies[3] = PlayerPrefs.GetInt("Efficiency Chemistry");
        efficiencies[4] = PlayerPrefs.GetInt("Efficiency Geography");

        for(int i = 0; i < efficiencies.Length; i++)
        {
            // if the efficiency is higher than the 
            if(efficiencies[i] >= minumumEfficiencyToBeFinished)
            {
                prefabIsFinished[i] = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        text.text = statusOfText;

        for(int i = 0; i < prefabs.Length; i++)
        {
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


        UpdatePrefabs();
             
    }

    private void selectPrefab(Ray ray)
    {
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            GameObject hitPrefab = hit.transform.gameObject;
            // Debug.Log("Hit " + hitPrefab);
            for(int i = 0; i < prefabs.Length; i++)
            {
                if(hitPrefab.tag == prefabs[i].tag)
                {
                    isSelected[i] = true;
                    text.text = hitPrefab.name;
                }
                else if(hitPrefab.tag != prefabs[i].tag)
                {
                    isSelected[i] = false;
                }
            }
        }
        else
        {
            // Debug.Log("Ray hit is null");
        }
    }


    private void UpdatePrefabs()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            bool selected = isSelected[i];
            bool isFinished = prefabIsFinished[i];
            GameObject prefab = prefabs[i];
            if(isFinished == true) // if the prefab is finished
            {
                prefab.transform.GetChild(2).gameObject.SetActive(true);
                prefab.transform.GetChild(0).gameObject.SetActive(false);
            }
            else // if the prefab is NOT finished
            {
                prefab.transform.GetChild(2).gameObject.SetActive(false);
                prefab.transform.GetChild(0).gameObject.SetActive(true);
            }
            if(selected == true)
            {
                prefab.transform.GetChild(1).gameObject.SetActive(true);
                prefab.transform.GetChild(2).gameObject.SetActive(false);
            }
            else
            {
                prefab.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }


    public void selectButton()
    {
        for(int i = 0; i < prefabs.Length; i++)
        {
            if(isSelected[i] == true)
            {
                SceneManager.LoadScene(sceneLoadStrings[i]);
            }
        }
    }


    

}
