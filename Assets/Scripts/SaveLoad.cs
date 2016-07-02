using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public static class SaveLoad {

	public static List<RoomData> savedRooms = new List<RoomData>();

	public static void save(RoomData rd) {
		savedRooms.Add(rd);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/dungeon.gd");
		bf.Serialize(file, SaveLoad.savedRooms);
		file.Close();
	}

	public static RoomData load() {
		if(File.Exists(Application.persistentDataPath + "/dungeon.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/dungeon.gd", FileMode.Open);
			SaveLoad.savedRooms = (List<RoomData>)bf.Deserialize(file);
			RoomData rd = savedRooms [0];
			file.Close();
			return rd;
		}
		return null;
	}

}
