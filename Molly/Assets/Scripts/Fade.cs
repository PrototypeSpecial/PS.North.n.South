using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
	GUITexture Image;
	public float Fade_Time = 2f;
	public float Fade_Max = 1f;
	float _time;
	public bool FadeIn_ing = true;
	public bool FadeOut_ing;

	void Start ()
	{
		Image = GetComponent<GUITexture> ();
	}

	void Update ()
	{
		if (FadeIn_ing) {
			_time += Time.deltaTime;
			Image.color = Color.Lerp (new Color (Image.color.r, Image.color.g, Image.color.b, Fade_Max), new Color (Image.color.r, Image.color.g, Image.color.b, 0), _time / Fade_Time);
		}

		if (FadeOut_ing) {
			_time += Time.deltaTime;
			Image.color = Color.Lerp (new Color (Image.color.r, Image.color.g, Image.color.b, 0), new Color (Image.color.r, Image.color.g, Image.color.b, Fade_Max), _time / Fade_Time);
		}

		if (_time >= Fade_Time) {
			_time = 0;
			FadeIn_ing = false;
			FadeOut_ing = false;
		}
	}

	public void FadeIn ()
	{
		FadeIn_ing = true;
	}

	public void FadeOut ()
	{
		FadeOut_ing = true;
	}
}