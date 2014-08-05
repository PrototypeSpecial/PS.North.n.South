using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Gui_Layout : MonoBehaviour
{
	public enum positionType
	{
		TopLeft,
		TopMiddle,
		TopRight,
		MiddleLeft,
		Middle,
		MiddleRight,
		BottomLeft,
		BottomMiddle,
		BottomRight
	}

	public positionType _positionType = positionType.Middle;
	public float margin_x;
	public float margin_y;
	public int _depth;
	float screenX;
	float screenY;
	GUIText _gui_text;
	GUITexture _gui_texture;
	float _guiWidth;
	float _guiHeight;

	bool TextureIN=false;
	
	void Awake ()
	{
		#if !(UNITY_EDITOR)
		
		_gui_text = GetComponent<GUIText> ();
		_gui_texture = GetComponent<GUITexture> ();
		screenX = Screen.width;
		screenY = Screen.height;
		
		
		
		if (_gui_texture != null) {
			_guiWidth = _gui_texture.pixelInset.width;
			_guiHeight = _gui_texture.pixelInset.height;
		}

		PositionSetting ();
		#endif
		
		
	}

	void Update ()
	{ 
		#if UNITY_EDITOR
		
		_gui_text = GetComponent<GUIText> ();
		_gui_texture = GetComponent<GUITexture> ();
		screenX = Screen.width;
		screenY = Screen.height;
		
		
		
		if (_gui_texture != null) {
		
			_guiWidth = _gui_texture.pixelInset.width;
			_guiHeight = _gui_texture.pixelInset.height;
			
			if(_gui_texture.texture!=null && TextureIN==false){
				TextureIN =true;
				_guiWidth = _gui_texture.texture.width;
				_guiHeight = _gui_texture.texture.height;
				TextureIN =false;
			}
			
		}
		
		this.gameObject.transform.position = new Vector3 (0, 0, -0.01f * _depth);
		PositionSetting ();
		
		#endif
	}

	void PositionSetting ()
	{
		switch (_positionType) {
		case positionType.TopLeft:

			if (_gui_text != null)
				_gui_text.pixelOffset = new Vector2 (margin_x, screenY - margin_y);
			if (_gui_texture != null)
				_gui_texture.pixelInset = new Rect (margin_x, screenY - _guiHeight - margin_y,_guiWidth, _guiHeight);

			break;

		case positionType.TopMiddle:

			if (_gui_text != null)
				_gui_text.pixelOffset = new Vector2 (screenX * 0.5f - margin_x, screenY - margin_y);
			if (_gui_texture != null)
				_gui_texture.pixelInset = new Rect (screenX * 0.5f + margin_x - _guiWidth * 0.5f, screenY - _guiHeight - margin_y, _guiWidth, _guiHeight);

			break;

		case positionType.TopRight:

			if (_gui_text != null)
				_gui_text.pixelOffset = new Vector2 (screenX - margin_x, screenY - margin_y);
			if (_gui_texture != null)
				_gui_texture.pixelInset = new Rect (screenX - margin_x - _guiWidth, screenY - _guiHeight - margin_y, _guiWidth, _guiHeight);

			break;

		case positionType.MiddleLeft:

			if (_gui_text != null)
				_gui_text.pixelOffset = new Vector2 (margin_x, screenY * 0.5f);
			if (_gui_texture != null)
				_gui_texture.pixelInset = new Rect (margin_x, screenY * 0.5f - _guiHeight * 0.5f + margin_y, _guiWidth, _guiHeight);

			break;

		case positionType.Middle:

			if (_gui_text != null)
				_gui_text.pixelOffset = new Vector2 (screenX * 0.5f + margin_x, screenY * 0.5f + margin_y);
			if (_gui_texture != null)
				_gui_texture.pixelInset = new Rect (screenX * 0.5f - _guiWidth * 0.5f + margin_x, screenY * 0.5f - _guiHeight * 0.5f + margin_y, _guiWidth, _guiHeight);

			break;

		case positionType.MiddleRight:

			if (_gui_text != null)
				_gui_text.pixelOffset = new Vector2 (screenX - margin_x, screenY * 0.5f + margin_y);
			if (_gui_texture != null)
				_gui_texture.pixelInset = new Rect (screenX - margin_x - _guiWidth, screenY * 0.5f - _guiHeight * 0.5f + margin_y, _guiWidth, _guiHeight);

			break;

		case positionType.BottomLeft:

			if (_gui_text != null)
				_gui_text.pixelOffset = new Vector2 (margin_x, margin_y);

			if (_gui_texture != null)
				_gui_texture.pixelInset = new Rect (margin_x, margin_y, _guiWidth, _guiHeight);

			break;

		case positionType.BottomMiddle:

			if (_gui_text != null)
				_gui_text.pixelOffset = new Vector2 (screenX * 0.5f + margin_x, margin_y);
			if (_gui_texture != null)
				_gui_texture.pixelInset = new Rect (screenX * 0.5f + margin_x - _guiWidth * 0.5f, margin_y, _guiWidth, _guiHeight);

			break;

		case positionType.BottomRight:

			if (_gui_text != null)
				_gui_text.pixelOffset = new Vector2 (screenX - margin_x, margin_y);
			if (_gui_texture != null)
				_gui_texture.pixelInset = new Rect (screenX - margin_x - _guiWidth, margin_y, _guiWidth, _guiHeight);

			break;
		}
	}
}