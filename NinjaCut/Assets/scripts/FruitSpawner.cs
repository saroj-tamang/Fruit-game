using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour {
	public GameObject fruit;
	public float maxX;
	public GameObject bombs;

	// Use this for initialization
	void Start () {
		Invoke ("StartSpawning", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartSpawning(){

		InvokeRepeating ("SpawnFruitGroups", 1, 6f);


	}
	public void StopSpawning(){
		CancelInvoke ("SpawnFruitGroups");
		StopCoroutine ("SpawnFruit");


	}





	public void SpawnFruitGroups(){
		StartCoroutine ("SpawnFruit");
		SpawnBombs ();
	}
		
	IEnumerator SpawnFruit()
	{


		for (int i = 0; i < 5; i++) {

			float Rand = Random.Range (-maxX, maxX);
			Vector3 pos = new Vector3 (Rand, transform.position.y, 0);
			GameObject f = Instantiate (fruit, pos, Quaternion.identity) as GameObject;
			f.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20f), ForceMode2D.Impulse);
			f.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-20f,20f));


			yield return new WaitForSeconds (0.5f);

		}
	}
	void SpawnBombs(){

		float Rand = Random.Range (-maxX, maxX);
		Vector3 pos = new Vector3 (Rand, transform.position.y, 0);
		GameObject b = Instantiate (bombs, pos, Quaternion.identity) as GameObject;
		b.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20f), ForceMode2D.Impulse);
		b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-50f,50f));


	}

}
