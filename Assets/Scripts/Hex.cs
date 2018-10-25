//===============================================================//
//
//  Program/File:     Hex.cs
//
//  Description:      The Hex Class Defines The Grid Position
//
//  Author:           Logan Wilkovich
//  Email:            LWilkovich@gmail.com
//  Creation Date:    9 September 2018
//===============================================================//
//=======================//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex {

    public Hex(int mLocX, int r) {
        this.mLocX = mLocX;
        this.mLocY = r;
        this.mModS = -(mLocX + r);
    }

    public readonly int mLocX;  // Column
    public readonly int mLocY;  // Row
    public readonly int mModS;

    public float elevation = -0.5f;

    static readonly float mWidthMultiplier = Mathf.Sqrt(3) / 2;

    float mRadius = 1f;
    public bool mAllowWrapEastWest = true;
    public bool mAllowWrapNorthSouth = false;

    //=======================//
    //Returns The World-Space Position of This Hex
    public Vector3 hexPosition() {
        // float newColumnSpacing = 0f;
        // if (this.mLocY % 2 != 0) {
        //     newColumnSpacing = 1f;
        // }
        return new Vector3(
            hexHorizontalSpacing() * (this.mLocX + this.mLocY/2f),
            0,
            hexVerticalSpacing() * this.mLocY
        );
    }

    public float hexHeight() {
        return mRadius * 2;
    }

    public float hexWidth() {
        return mWidthMultiplier * hexHeight();
    }

    public float hexVerticalSpacing() {
        return hexHeight() * 0.75f;
    }

    public float hexHorizontalSpacing() {
        return hexWidth();
    }

    public Vector3 positionFromCamera( Vector3 cameraPosition, float numRows, float numColumns) {

        float mapHeight = numRows * hexVerticalSpacing();
        float mapWidth  = numColumns * hexHorizontalSpacing();

        Vector3 position = hexPosition();

        position.x -= cameraPosition.x;
        position.z -= cameraPosition.z;

        if(mAllowWrapEastWest) {
            while(position.x < -mapWidth/2) {
                position.x += mapWidth;
            }
            while(position.x >= mapWidth/2) {
                position.x -= mapWidth;
            }
        }
        if(mAllowWrapNorthSouth) {
            while(position.z < -mapHeight/2) {
                position.z += mapHeight;
            }
            while(position.z >= mapHeight/2) {
                position.z -= mapHeight;
            }
        }

        position.x += cameraPosition.x;
        position.z += cameraPosition.z;

        return position;
    }
    
}