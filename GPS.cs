using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }
    public double latitude,longitude;

    public Text coordinates, msg;

    //private double MiniLatitude;
    private double CansLatitude;
    //private double MiniLongitude;
    private double CansLongitude;
    private double referenceDistance;
    public AudioClip MusicClip1, MusicClip2;
    public AudioSource MusicSource;


    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //latitude
        //MiniLatitude = 3.7204110622406;
        CansLatitude = 3.72396421432495;
        //Longitude
        //MiniLongitude = 103.120552062988;
        CansLongitude = 103.121673583984;
        //referenceDistance
        referenceDistance = 0.008;
        StartCoroutine(StartLocationService());
    }

    private void Update()
    {
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        //coordinates.text = "Your current location is (Lat,Lon): " + latitude.ToString() + " - " + longitude.ToString();
        coordinates.text = "Loading....";

        if (referenceDistance >= distanceBetweenPoints(CansLatitude, CansLongitude, latitude, longitude))
        {
            msg.text = "You are approached to Mini Stadium";
            coordinates.text = "";
            MusicSource.clip = MusicClip1;
            MusicSource.Play();
            Invoke("changeMiniscene", 8);
        }
        else
        {
            msg.text = "Mini Stadium is far away from you. Keep walking";
            coordinates.text = "";
            MusicSource.clip = MusicClip2;
            MusicSource.Play();
        }
      
    }
    public double distanceBetweenPoints(double startlat,double startlong, double endlat, double endlong)
    {
        double w = startlat * Math.PI / 180;
        double x = startlong * Math.PI / 180;
        double y = endlat * Math.PI / 180;
        double z = endlong * Math.PI / 180;
        double distancelat = y - w;
        double distancelong = z - x;
        double m = Math.Pow(Math.Sin(distancelat / 2), 2) + Math.Cos(w) * Math.Cos(y) * Math.Pow(Math.Sin(distancelong / 2), 2);
        double n = 2 * Math.Asin(Math.Sqrt(m));
        double r = 6371;
        double total = n * r;
        return total;
    }

    public void changeMiniscene()
    {
        SceneManager.LoadScene("SceneMini");
    }

    private bool KSUCloseEnoughForMe(double value1, double value2, double acceptableDifference)
    {
        return Math.Abs(value1 - value2) <= acceptableDifference;
    }

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            print("User has not enabled GPS");
            yield break;
        }

        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        yield break;
    }

    //exit the application
    public void ExitApp()
    {
        print("You click on exit button!");
        Application.Quit();
    }

    public void RefreshLocation()
    {
        Input.location.Start();
        Debug.Log("Updated");   
    }
}
