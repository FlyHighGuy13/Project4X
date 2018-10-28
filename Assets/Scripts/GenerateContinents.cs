using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateContinents : HexMap {

	//private int[,] mHexTable;

	public GenerateContinents() {}


	override public void drawMap() {
		base.drawMap();

		int numContinents = 3;
		int continentSpacing = getNumColumns() / numContinents;

		Random.InitState(154325432);
		// Random.InitState(0);

		for (int c = 0; c < numContinents; c++)
		{
			int baseArea = Random.Range(15, 18);
			for (int i = 0; i < baseArea; i++) {
				int range = Random.Range(4, 7);
				int y = Random.Range(range, getNumRows() - range);
				int x = Random.Range(0, 10) - y/2 + (c * continentSpacing);
				elevateArea(x, y, range);
			}
		}
		
		float noiseResolution = 0.05f;
		Vector2 noiseOffset = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
		float noiseScale = 2f;
		for (int column = 0; column < getNumColumns(); column++) {

            for (int row = 0; row < getNumRows(); row++) {
				Hex h = getHexLookup(column, row);
				float n = 
                    Mathf.PerlinNoise( ((float)column/Mathf.Max(getNumColumns(), getNumRows()) / noiseResolution) + noiseOffset.x, 
                        ((float)row/Mathf.Max(getNumColumns(), getNumRows()) / noiseResolution) + noiseOffset.y )
                    - 0.5f;
				h.mElevation += n * noiseScale;
			}
		}

		// Simulate rainfall/moisture (probably just Perlin it for now) and set plains/grasslands + forest 
        noiseResolution = 0.05f;
        noiseOffset = new Vector2( Random.Range(0f, 1f), Random.Range(0f, 1f) ); 

        noiseScale = 2f;

        for (int column = 0; column < getNumColumns(); column++)
        {
            for (int row = 0; row < getNumRows(); row++)
            {
                Hex h = getHexLookup(column, row);
                float n = 
                    Mathf.PerlinNoise( ((float)column/Mathf.Max(getNumColumns(), getNumRows()) / noiseResolution) + noiseOffset.x, 
                        ((float)row/Mathf.Max(getNumColumns(), getNumRows()) / noiseResolution) + noiseOffset.y )
                    - 0.5f;
                h.mMoisture = n * noiseScale;
            }
        }

	}

	public void elevateArea(int x, int y, int range, float baseHeight = 0.8f) {
		Tuple<int, int> originalCordinates = new Tuple<int, int>(x, y);
		originalCordinates = wrapCordinates(originalCordinates);
		Hex origin = getHexLookup(originalCordinates.First, originalCordinates.Second);
		Hex h;
		for (int dx = -range; dx <= range; dx++)
        {
            for (int dy = Mathf.Max(-range, -dx-range); dy <= Mathf.Min(range, -dx+range); dy++)
            {		
					Tuple<int, int> selection = new Tuple<int, int>(x + dx, y + dy);
					selection = wrapCordinates(selection);		
					h = getHexLookup(selection.First, selection.Second);
					h.mElevation = baseHeight * Mathf.Lerp( 1f, 0.25f, Mathf.Pow(distance(origin, h) / range,2f));
					// Debug.Log(h.mElevation);
			}
		}
	}
	public Tuple<int, int> wrapCordinates(Tuple<int, int> selection) {
		if (selection.First < 0) {
			selection.First = getNumColumns() + selection.First;
		}
		else if (selection.First > getNumColumns() - 1) {
			selection.First = selection.First - getNumColumns();
		}
		if (selection.Second < 0) {
			selection.Second = getNumRows() + selection.Second;
		}
		if (selection.Second > getNumRows() - 1) {
			selection.Second = selection.Second - getNumRows();
		}
		return selection;
	}

	public float distance(Hex a, Hex b)
    {
        // WARNING: Probably Wrong for wrapping
        int dQ = Mathf.Abs(a.mLocX - b.mLocX);
        if(a.mAllowWrapEastWest)
        {
            if(dQ > getNumColumns() / 2)
                dQ = getNumColumns() - dQ;
        }

        int dR = Mathf.Abs(a.mLocY - b.mLocY);
        if(a.mAllowWrapNorthSouth)
        {
            if(dR > getNumRows() / 2)
                dR = getNumRows() - dR;
        }

        return  Mathf.Max(dQ, dR, Mathf.Abs(a.mModS - b.mModS));
    }

}
