//===============================================================//
//
//  Program/File:     HexComponet.cs
//
//  Description:      The HexComponet Class Defines The Update For World Wrap
//  Author:           Logan Wilkovich
//  Email:            LWilkovich@gmail.com
//  Creation Date:    9 September 2018
//===============================================================//
//=======================//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexComponent : MonoBehaviour {

    void Start()
    {
        mHexMap = GameObject.FindObjectOfType<HexMap>();
    }

    //=======================//
    //Member Variables
    public Hex mHex;
    HexMap mHexMap;

	void Update () {
		
        if(mHex == null) {
            return;
        }

        this.transform.position = mHex.positionFromCamera(
            Camera.main.transform.position,
            mHexMap.getNumRows(),
            mHexMap.getNumColumns()
        );
	}
}
