using UnityEngine;
using System.Collections;

public enum GameState
{
    Play,
    Pause,
    End
}
public class GameManager : MonoBehaviour {

    public GameState GS;

    public GUIText Text_Meter;
    public GUIText Text_Gold;

    public GameObject Final_GUI;

    public GUIText Final_Meter;
    public GUIText Final_Gold;

    public GameObject Pause_GUI;

    public float Speed;
    public float Meter;
    public int Gold;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if(GS==GameState.Play)
        {
            Meter += Time.deltaTime * Speed;
            Text_Meter.text = string.Format("{0:N0}m", Meter);
        }
	}

    public void CoinGet()
    {
        Gold += 1;
        Text_Gold.text = string.Format("{0}", Gold);
    }

    public void GameOver()
    {
        Final_Meter.text = string.Format("{0:N1}", Meter);
        Final_Gold.text = string.Format("{0}", Gold);

        GS = GameState.End;
        Final_GUI.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("PlayScene");
    }

    public void MainGo()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("IntroScene");
    }

    public void Pause()
    {
        GS = GameState.Pause;
        Time.timeScale = 0f;
        Pause_GUI.SetActive(true);
    }

    public void UnPause()
    {
        GS = GameState.Play;
        Time.timeScale = 1f;
        Pause_GUI.SetActive(false);
    }
}
