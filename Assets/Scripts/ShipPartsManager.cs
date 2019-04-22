using UnityEngine;

public class ShipPartsManager : MonoBehaviour
{
    // this contains all the prefabs of each part
    public GameObject [] hulls;
    public GameObject [] engines;
    public GameObject [] weatherStations;
    public GameObject [] GPS;
    public GameObject [] nets;
    [SerializeField]
    private int numberOfParts = 5;

    public enum ShipParts { Hull, Engine, WeatherStation, GPS, Net };
    public enum ShipPartState { Blueprint, Highlighted, Finished}

    public void ChangePrefab(ShipParts shipPartsEnum)
    {
        for (int i = 0; i < numberOfParts; i++)
        {
            
        }
    }

    private void changeEngine()
    {

    }
}
