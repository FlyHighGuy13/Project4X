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

public class Tuple<T1, T2>
 {
     public T1 First { get; set; }
     public T2 Second { get; set; }
     public Tuple() {}

     internal Tuple(T1 first, T2 second)
     {
         First = first;
         Second = second;
     }
 }
 
public static class Tuple
{
    public static Tuple<T1, T2> New<T1, T2>(T1 first, T2 second)
    {
        var tuple = new Tuple<T1, T2>(first, second);
        return tuple;
    }
}

public class HexMap : MonoBehaviour {

    //=======================//
	//Use this for initialization
	void Start () {
        drawMap();
        // GenerateContinents generater = new GenerateContinents();
        // Tuple<int, int> test = new Tuple<int, int>();
        // generater.generateLand();
        updateHexRendering();
	}

    //=======================//
    //Member Variables
    // private float mLandTileCount = 0f;
    public GameObject mHexPrefab;
    public Material[] mHexMaterials;
    private static int mRows = 30;
    private static int mColumns = 60;
    private readonly int mNumRows = mRows;
    private readonly int mNumColumns = mColumns;
    private Hex[,] hexTable; 
    private Dictionary<Hex, GameObject> gameObjectLookupTable;
    private Dictionary<GameObject, Hex> hexLookupTable;

    public int getNumRows() {
        return mNumRows;
    }

    public int getNumColumns() {
        return mNumColumns;
    }

    //=======================//
    // drawMap Function Renders Hexes
    virtual public void drawMap() {
        hexTable = new Hex[mColumns, mRows];
        gameObjectLookupTable = new Dictionary<Hex, GameObject>();
        hexLookupTable = new Dictionary<GameObject, Hex>();
        for (int column = 0; column < mNumColumns; column++) {

            for (int row = 0; row < mNumRows; row++) {
                
                Hex h = new Hex(column, row);
                hexTable[column, row] = h;

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

                gameObjectLookupTable[h] = hexGameObject;
                hexLookupTable[hexGameObject] = h;

                hexGameObject.GetComponent<HexComponent>().mHex = h;
                // hexGameObject.GetComponentInChildren<TextMesh>().text = string.Format("{0}, {1}", column, row);

                // MeshRenderer mr = hexGameObject.GetComponentInChildren<MeshRenderer>();
                // mr.material = mHexMaterials[ Random.Range(0, mHexMaterials.Length) ];
                // mr.material = mHexMaterials[ genMap[column,row] ];
            }
        }
    }

    public Hex getHexLookup(int x, int y) {
        // Debug.Log(string.Format("{0}, {1}", x, y));
        return hexTable[x, y];
    } 

    public void updateHexRendering() {
        for (int column = 0; column < mNumColumns; column++) {

            for (int row = 0; row < mNumRows; row++) {

                Hex h = hexTable[column, row];
                GameObject hexGameObject = gameObjectLookupTable[h];
                int renderIndex = 0;
                if (h.elevation < 0f) {
                    renderIndex = 0;
                }
                else if (h.elevation > 0f) {
                    renderIndex = 1;
                }
                if (h.elevation > 1f) {
                    renderIndex = 3;
                }
                if (h.elevation < .4f && h.elevation > 0f) {
                    renderIndex = 2;
                }

                MeshRenderer mr = hexGameObject.GetComponentInChildren<MeshRenderer>();
                mr.material = mHexMaterials[renderIndex];
                hexGameObject.GetComponentInChildren<TextMesh>().text = string.Format("{0}", h.elevation);
            }
        }
    }

}
