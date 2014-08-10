using UnityEngine;
using System.Collections;

public class PlayManager : MonoBehaviour {
    public bool PlayEnd;
    public float Limit_Time = 60f;
    public int Enemy_Count = 10;

    public UILabel TimeLabel;
    public UILabel EnemyLabel;
    public GameObject FinalGUI;
    public UILabel FinalMessage;
    public UILabel FinalScoreLabel;

    public UILabel PlayerName;

	// Use this for initialization
	void Start () {
        EnemyLabel.text = string.Format("Enemy : {0}", Enemy_Count);
        TimeLabel.text = string.Format("Time : {0:N2}", Limit_Time);
        PlayerName.text = PlayerPrefs.GetString("UserName");
	}
	
	// Update is called once per frame
	void Update () {
        if( PlayEnd != true)
        {
            if (Limit_Time > 0)
            {
                Limit_Time -= Time.deltaTime;
                TimeLabel.text = string.Format("Time: {0:N2}", Limit_Time);
            }
            else
            {
                GameOver();
            }
        }
        
	}

    public void Clear()
    {
        if( PlayEnd != true)
        {
            Time.timeScale = 0;
            PlayEnd = true;
            FinalMessage.text = "Clear!!";

            Player_Ctrl PC = GameObject.Find("Player").GetComponent<Player_Ctrl>();

            float score = 12345f + Limit_Time * 123f + PC.hp * 123f;
            FinalScoreLabel.text = string.Format("{0:N0}", score);

            FinalGUI.SetActive(true);

            BestCheck(score);
        }
    }

    public void GameOver()
    {
        if (PlayEnd != true)
        {
            Time.timeScale = 0;
            PlayEnd = true;
            FinalMessage.text = "Fail...";
            float score = 12345f + Enemy_Count * 123f;
            FinalScoreLabel.text = string.Format("{0:N0}", score);
            FinalGUI.SetActive(true);

            BestCheck(score);

            Player_Ctrl PC = GameObject.Find("Player").GetComponent<Player_Ctrl>();
            PC.PS = PlayerState.Dead;
        }
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("MainPlay");
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Title");
    }

    public void EnemyDie()
    {
        Enemy_Count -= 1;
        EnemyLabel.text = string.Format("Enemy : {0}", Enemy_Count);

        if( Enemy_Count <=0)
        {
            Clear();
        }
    }

    public void BestCheck(float score)
    {
        float BestScore = PlayerPrefs.GetFloat("BestScore");

        if(score > BestScore)
        {
            PlayerPrefs.SetFloat("BestScore", score);
            PlayerPrefs.SetString("BestPlayer", PlayerPrefs.GetString("UserName"));
        }
    }
}


