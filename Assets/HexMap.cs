using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		generateMap();
	}
	
	public GameObject HexPrefab;

	public void generateMap() {
		for (float i = 0; i < 10; i++) {
			for (float j = 0; j < 10; j++) {
				float locationX = i;
				float locationY = j;
				float radius = 1f;
				float height = 2;
				float width = ((Mathf.Sqrt(3) / 2) * 2);
				float vert = height * 0.75f;
				float horiz = width;
				if (j % 2 == 1) {
					locationX = (i * width) + (width / 2);
					locationY = (j /2) * 3;
					Debug.Log(j);
					Debug.Log(locationY);
				}
				else { 
					locationX = i * width;
					locationY = j + j / 2;
				}
				Instantiate(HexPrefab,
							new Vector3(locationX, 0, locationY),
							Quaternion.identity,
							this.transform);
			}
		}
	}

	// Update is called once per frame
	// void Update () {
		
	// }
}
