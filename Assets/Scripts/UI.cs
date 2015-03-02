using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

//	Camera camera;

	private Vector2 mousePosition, dragMousePosition;

	private static Texture2D _staticRectTexture;
	private static GUIStyle _staticRectStyle;

	private bool mouseClicked;

	private float dix, diy;

	// Use this for initialization
	void Start () {
//		camera = camera.Find ("Main Camera").camera;
		mouseClicked = false;
		dix = 0;
		dix = 0;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			mouseClicked = true;
//			Debug.Log ("Pressed left click.");
			mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		}
		if (Input.GetMouseButtonUp (0)) {
			mouseClicked = false;
//			Debug.Log("up left click");
			collMehod(Input.mousePosition);
		}
		if(Input.GetMouseButtonDown(1))
			Debug.Log("Pressed right click.");
		if(Input.GetMouseButtonDown(2))
			Debug.Log("Pressed middle click.");

		if (mouseClicked) {
			dragMousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			dix = dragMousePosition.x - mousePosition.x;
			diy = (Screen.height - dragMousePosition.y) - (Screen.height - mousePosition.y);

		} else {
			dix = 0;
			dix = 0;
		}

	}

	void OnGUI(){
		float xx = mousePosition.x, yy = mousePosition.y;
		yy = Screen.height - yy;
		if(mouseClicked)
			GUIDrawRect (new Rect (xx, yy, 0 + dix, 0 + diy), new Color(0, 0, 0, 0.5f));
	}

	void collMehod(Vector3 pos){
		Vector2 wp = Camera.main.ScreenToWorldPoint(pos);
		Ray2D ray = new Ray2D (wp, Vector2.zero);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
		
		if (hit.collider != null) {
			Debug.Log(hit.collider.name);
		}

	}

	public static void GUIDrawRect( Rect position, Color color ){
		if( _staticRectTexture == null )
		{
			_staticRectTexture = new Texture2D( 1, 1 );
		}
		
		if( _staticRectStyle == null )
		{
			_staticRectStyle = new GUIStyle();
		}
		
		_staticRectTexture.SetPixel( 0, 0, color );
		_staticRectTexture.Apply();
		
		_staticRectStyle.normal.background = _staticRectTexture;
		
		GUI.Box( position, GUIContent.none, _staticRectStyle );
		
	}
	
}
