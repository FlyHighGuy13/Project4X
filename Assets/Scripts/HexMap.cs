//===============================================================//
//
//  Program/File:     HexMap.cs
//
//  Description:      The HexMap Class Defines The Global Hex Grid
//
//  Author:           Logan Wilkovich
//  Email:            LWilkovich@gmail.com
//  Creation Date:    9 September 2018
//===============================================================//
//=======================//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour {

    //=======================//
	//Use this for initialization
	void Start () {
        generateMap();
	}

    //=======================//
    //Member Variables
    public GameObject mHexPrefab;
    public Material[] mHexMaterials;
    public readonly int mNumRows = 20;
    public readonly int mNumColumns = 40;

    public void generateMap() {
        for (int column = 0; column < mNumColumns; column++) {

            for (int row = 0; row < mNumRows; row++) {

                Hex h = new Hex( column, row );
                Vector3 pos = h.positionFromCamera( 
                    Camera.main.transform.position, 
                    mNumRows, 
                    mNumColumns 
                );

                GameObject hexGameObject = (GameObject)Instantiate(
                    mHexPrefab, 
                    pos,
                    Quaternion.identity,
                    this.transform
                );
                hexGameObject.GetComponent<HexComponent>().mHex = h;

                MeshRenderer mr = hexGameObject.GetComponentInChildren<MeshRenderer>();
                mr.material = mHexMaterials[ Random.Range(0, mHexMaterials.Length) ];
            }
        }
    }
}
