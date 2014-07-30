using UnityEngine;
using System.Collections;

public enum MoleState
{
    None,
    Open,
    Idle,
    Close,
    Catch
}

public class Hole : MonoBehaviour {

    public MoleState MS;

    public Texture[] EnemyOpenImages;
    public Texture[] EnemyIdleImages;
    public Texture[] EnemyCloseImages;
    public Texture[] EnemyCatchImages;

    public Texture[] AllyOpenImages;
    public Texture[] AllyIdleImages;
    public Texture[] AllyCloseImages;
    public Texture[] AllyCatchImages;

    public float AniSpeed;
    public float NowAniTime;
    public int AniCount=0;

    public AudioClip OpenSound;
    public AudioClip CatchSound;

    public bool AllyMole;
    public int PerGood = 15;

    public GameManager GM;
    GUIText PlusPointGUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(NowAniTime >= AniSpeed)
        {
            if (MS == MoleState.Open)
            {
                OpenIng();
            }
            if (MS == MoleState.Idle)
            {
                IdleIng();
            }
            if (MS == MoleState.Close)
            {
                CloseIng();
            }
            if (MS == MoleState.Catch)
            {
                CatchIng();
            }
            NowAniTime = 0;
        }
        else
        {
            NowAniTime += Time.deltaTime;
        }
	}

    public void OpenOn()
    {
        MS = MoleState.Open;
        AniCount = 0;

        audio.clip = OpenSound;
        audio.Play();

        int a = Random.Range(0, 100);
        if (a<=PerGood)
        {
            AllyMole = true;
        }
        else
        {
            AllyMole = false;
        }

        if (GM.GS == GameState.Ready)
            GM.GO();
    }

    public void OpenIng()
    {
        if (AllyMole == false)
        {
            renderer.material.mainTexture = EnemyOpenImages[AniCount];
        }
        else
        {
            renderer.material.mainTexture = AllyOpenImages[AniCount];
        }
        AniCount += 1;
        if (AniCount >= EnemyOpenImages.Length)
        {
            IdleOn();
        }
    }

    public void IdleOn()
    {
        MS = MoleState.Idle;
        AniCount = 0; 
    }

    public void IdleIng()
    {
        if (AllyMole == false)
        {
            renderer.material.mainTexture = EnemyIdleImages[AniCount];
        }
        else
        {
            renderer.material.mainTexture = AllyIdleImages[AniCount];
        }
        AniCount += 1;
        if (AniCount >= EnemyIdleImages.Length)
        {
            CloseOn();
        }
    }

    public void CloseOn()
    {
        MS = MoleState.Close;
        AniCount = 0; 
    }

    public void CloseIng()
    {
        if (AllyMole == false)
        {
            renderer.material.mainTexture = EnemyCloseImages[AniCount];
        }
        else
        {
            renderer.material.mainTexture = AllyCloseImages[AniCount];
        }
        AniCount += 1;
        if (AniCount >= EnemyCloseImages.Length)
        {
            StartCoroutine("Wait");
        }
    }

    public void CatchOn()
    {
        MS = MoleState.Catch;
        AniCount = 0;
        audio.clip = CatchSound;
        audio.Play();

        if (AllyMole == false)
        {
            GM.CountCatchedEnemy += 1;
            GM.CountCombo += 1;
            if (GM.CountCombo >= 2)
            {
                GM.ComboText.text = string.Format("{0} Combo!", GM.CountCombo);

                int ExclamationMarkMax = GM.CountCombo/5;
                for (int i = 0; i < ExclamationMarkMax; i++)
                {
                    GM.ComboText.text += string.Format("!");
                }
            }
        }
        else
        {
            Handheld.Vibrate();
            GM.CountCatchedAlly += 1;
            GM.CountCombo = 0;
            GM.ComboText.text = string.Format("Miss!!");
        }

    }

    public void CatchIng()
    {
        if (AllyMole == false)
        {
            renderer.material.mainTexture = EnemyCatchImages[AniCount];
        }
        else
        {
            renderer.material.mainTexture = AllyCatchImages[AniCount];
        }
        AniCount += 1;
        if (AniCount >= EnemyCatchImages.Length)
        {
            PlusPointGUI.gameObject.SetActive(false);
            Destroy(PlusPointGUI.gameObject);
            StartCoroutine("Wait");
        }
    }

    public IEnumerator Wait()
    {
        MS = MoleState.None;
        AniCount = 0;

        float waitTime = Random.Range(0.5f, 4.5f);
        yield return new WaitForSeconds(waitTime);
        OpenOn();
    }

    public void OnMouseDown()
    {
        if (MS == MoleState.Idle || MS == MoleState.Open)
        {
            if (AllyMole == false)
            {
                PlusPointGUI = (GUIText)Instantiate(GM.Plus100);
            }
            else
            {
                PlusPointGUI = (GUIText)Instantiate(GM.Minus100);
            }
       
            // 오브젝트 위치로부터 변환
            Vector3 NewVec3 = GM.MainCamera.WorldToViewportPoint(transform.position);
            NewVec3.z = 0;

            // 클릭한 위치로부터 변환
            //Vector3 NewVec3 = GM.MainCamera.ScreenToViewportPoint(Input.mousePosition);

            NewVec3.x -= 0.5f;
            NewVec3.y -= 0.45f;

            PlusPointGUI.transform.Translate(NewVec3);
            PlusPointGUI.gameObject.SetActive(true);
            
            CatchOn();
        }
    }
}
