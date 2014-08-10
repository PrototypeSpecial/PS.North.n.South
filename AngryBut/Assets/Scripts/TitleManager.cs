using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {
    public UILabel NameLabel;
    public GameObject BestData;
    public UILabel BestuserData_Label;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GoPlay()
    {
        if (NameLabel.text == "Type Your Name")
        {
            return;
        }

        PlayerPrefs.SetString("UserName", NameLabel.text);

        Application.LoadLevel("MainPlay");
    }

    void BestScore()
    {
        BestuserData_Label.text = string.Format("{0}:{1:N0}",
                                    PlayerPrefs.GetString("BestPlayer"),
                                    PlayerPrefs.GetFloat("BestScore"));

        if(BestuserData_Label.text != ":0" )
        {
            BestData.SetActive(true);
        }
    }

    void Quit()
    {
        Application.Quit();

    }

}
