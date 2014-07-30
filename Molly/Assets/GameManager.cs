using UnityEngine;
using System.Collections;

public enum GameState
{
    Ready,
    Play,
    End
}

public class GameManager : MonoBehaviour {

    public GameState GS;

    public Hole[] Holes;
    public float LimitTime;
    public GUIText TimeText;
    public int CountCatchedEnemy;
    public int CountCatchedAlly;
    
    public GameObject FinishGUI;
    public GUIText FinalCountBad;
    public GUIText FinalCountGood;
    public GUIText FinalScore;

    public AudioClip ReadySound;
    public AudioClip GoSound;
    public AudioClip FinishSound;

    public int CountCombo;
    public GUIText ComboText;
    public GUIText Plus100;
    public GUIText Minus100;
    public Camera MainCamera;
    void Start()
    {
        audio.clip = ReadySound;
        audio.Play();
    }

    public void GO()
    {
        GS = GameState.Play;
        audio.clip = GoSound;
        audio.Play();
    }

    void Update()
    {
        if (GS==GameState.Play)
        { 
            LimitTime -= Time.deltaTime;

            if(LimitTime<=0)
            { 
                LimitTime = 0;
                End();
            }
        }
        TimeText.text = string.Format("{0:N2}", LimitTime);
    }

    void End()
    {
        GS = GameState.End;
        FinalCountBad.text = string.Format("{0}", CountCatchedEnemy);
        FinalCountGood.text = string.Format("{0}", CountCatchedAlly);
        FinalScore.text = string.Format("{0}", CountCatchedEnemy * 100 - CountCatchedAlly * 1000);
        FinishGUI.gameObject.SetActive(true);
        audio.clip=FinishSound;
        audio.Play();
    }
}
