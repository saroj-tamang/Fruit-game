using UnityEngine;
using System.Collections;

public class LineCreator : MonoBehaviour {

	int vertexCount=0;
	bool mouseDown=false;
	LineRenderer line;



	void Awake(){
		line = GetComponent<LineRenderer> ();



	}

	// Use this for initialization
	void Start () {
		//mouseDown=false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.touchCount > 0) {
				if (Input.GetTouch (0).phase == TouchPhase.Moved) {
					line.SetVertexCount (vertexCount + 1);
					Vector3 mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					line.SetPosition (vertexCount, mousepos);
					vertexCount++;

					BoxCollider2D box = gameObject.AddComponent<BoxCollider2D> ();
					box.transform.position = line.transform.position;
					box.size = new Vector2 (0.2f, 0.2f);


				}
				}
				if (Input.GetTouch (0).phase == TouchPhase.Ended) {

					mouseDown = false;
					vertexCount = 0;
					line.SetVertexCount (0);

					BoxCollider2D[] colliders = GetComponents<BoxCollider2D> ();

					foreach (BoxCollider2D box in colliders) {

						Destroy (box);
						FindObjectOfType<AudioManager>().Play("crash");

					}
				}
			}

		//else if(Application.platform == RuntimePlatform.WindowsPlayer)
		else
		{



		if (Input.GetMouseButtonDown (0)) {

			mouseDown = true;

		}
		if(mouseDown){
			line.SetVertexCount(vertexCount + 1);
			Vector3 mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			line.SetPosition (vertexCount, mousepos);
			vertexCount++;

			BoxCollider2D box = gameObject.AddComponent<BoxCollider2D> ();
			box.transform.position = line.transform.position;
			box.size = new Vector2 (0.2f, 0.2f);


		}
if(Input.GetMouseButtonUp(0)){

			mouseDown=false;
	     	vertexCount=0;
			line.SetVertexCount(0);

		BoxCollider2D[] colliders = GetComponents<BoxCollider2D> ();

			foreach (BoxCollider2D box in colliders) {
				
				Destroy (box);
				FindObjectOfType<AudioManager>().Play("crash");
			}
	}
}
}
}
