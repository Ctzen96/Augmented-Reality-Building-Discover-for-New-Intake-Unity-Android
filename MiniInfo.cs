using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class MiniInfo : MonoBehaviour
{
    public Text information,title;
    
    // Start is called before the first frame update
    void Start()
    {
        information.text = "";
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    //Level 1 
    public void Level1Aud()
    {
        title.text = "Ground Floor Auditorium Area";
        information.text = "There are separated into two sides which are left and right." +
            "Each side consists 15 columns with 8 rows, hence there are total with 120 seats for one side." +
            "As the result, there are 240 seats for ground floor auditorium area.";
    }

    //Level 2
    public void Level2Aud()
    {
        title.text = "Level 1 Auditorium Area";
        information.text = "Level 1 Auditorium Area consists only 45 seats for each side." +
            "Hence, the auditorium area of Mini Stadium able accommodate about 330 seats." +
            "This area is the best view for watching the competition like football competition. ";
    }

    //Stage
    public void stage()
    {
        title.text = "Stage";
        information.text = "The mini stage is usually used for small scale performance purposes," +
            "especially any run events in UMP.  It faces outwards to the green football field " +
            "which is most likely where the audience will be when the performances happen.";
    }

    //Facilities
    public void Facilities()
    {
        title.text = "Facilities";
        information.text = "Level 1: \nFemale Gym Room, Indoor Sports Room, Combat Sports Room, Media Room" +
            "\n\n" +
            "Level 2: \nMale Gym Room, Toilet";
    }
}
