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
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 5; j++) {	
				// if () {
					
				// }
				Instantiate(HexPrefab,
							new Vector3(i, 0, j),
							Quaternion.identity,
							this.transform);
			}
		}
	}

	// Update is called once per frame
	// void Update () {
		
	// }
}
