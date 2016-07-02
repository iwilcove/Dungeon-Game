using UnityEngine;
using System.Collections;

[System.Serializable]
public class RoomData {

	public int gridSizeX;
	public int gridSizeZ;
	public int[,] gridMap;

	public RoomData(int xSize, int zSize) {

		gridSizeX = xSize;
		gridSizeZ = zSize;

		gridMap = new int[gridSizeX, gridSizeZ];
		for (int x = 0; x < gridSizeX; x++) {
			for (int z = 0; z < gridSizeZ; z++) {
				gridMap [x, z] = 0;
			}
		}

	}

	public int getTile (int x, int z) {
		return gridMap [x, z];
	}
		
	public void setTile (int x, int z, int id) {
		gridMap [x, z] = id;
	}
		
}
