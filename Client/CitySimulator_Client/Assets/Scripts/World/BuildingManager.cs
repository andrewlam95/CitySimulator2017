using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Module: BuildingCreation
/// Team: Client
/// Description: Creating building depends on the grid information
/// Author: 
///	 Name: Dongwon(Shawn) Kim   Date: 2017-09-28
///  Name: Andrew Lam			Date: 2017-09-28
/// Modified by:	
///	 Name: Andrew Lam   Change: create, update, destroy building funtions added 	Date: 2017-11-25
///	 Name: Shawn  Kim   Change: Append objects to parent 							Date: 2017-10-20
/// Based on:  N/A
///  https://docs.unity3d.com/ScriptReference/Material-color.html
///  https://docs.unity3d.com/ScriptReference/GameObject.html
///  https://docs.unity3d.com/ScriptReference/Resources.Load.html
/// </summary>
public class BuildingManager : MonoBehaviour {

	public GameObject buildingManager;

	private GameObject[] planes;
	private GameObject buildingObject;

	private Transform planeTransform;

	// Use this for initialization
	void Start () {
		// planeTransform = GameObject.Find("Plane(Clone)").transform;
		buildingManager = GameObject.Find ("BuildingManager");
	}

	// Update is called once per frame
	void Update () {
		// intializeBuildings ();
	}

	// Update builings
	void updateBuildings (string id) {

		// Find the building object with the matching id
		GameObject building = GameObject.Find( id + "(Clone)");
	}

	// Create new building to on given grid location
	public void createBuilding (string GUID, int x, int z, short type, short tier) {

		// Finds the type of the building. eg. Industrial, Residential, Commercial.
		switch(type) 
		{
			// Residental 
			case 1: 
				if(tier == 1) {
				buildingObject = Resources.Load("Models/Building/Completed_Models/residential1") as GameObject; 
				buildingObject.name = GUID;
				instantiateBuilding (buildingObject,
									 x,
									 0,
									 z);
				}

				if(tier == 2) {
				buildingObject = Resources.Load("Models/Building/Completed_Models/residential2") as GameObject;
				buildingObject.name = GUID;
				instantiateBuilding (buildingObject,
									 x,
									 0,
									 z);
				}

				if(tier == 3) {
				buildingObject = Resources.Load("Models/Building/Completed_Models/residential3") as GameObject;
				buildingObject.name = GUID;
				instantiateBuilding (buildingObject,
									 x,
									 0,
									 z);
				}
			break; 

			// Commercial
			case 2:
				if(tier == 1) {
				buildingObject = Resources.Load("Models/Building/Completed_Models/commericial1") as GameObject;
				buildingObject.name = GUID;
				instantiateBuilding (buildingObject,
									 x,
									 0,
									 z);
				}

				if(tier == 2) {
				buildingObject = Resources.Load("Models/Building/Completed_Models/commercial2") as GameObject;
				buildingObject.name = GUID;
				instantiateBuilding (buildingObject,
									 x,
									 0,
									 z);
				}

				if(tier == 3) {
				buildingObject = Resources.Load("Models/Building/Completed_Models/commericial3") as GameObject;
				buildingObject.name = GUID;
				instantiateBuilding (buildingObject,
									 x,
									 0,
									 z);
				}
			break;

			// Industrial
			case 3:
				if(tier == 1) {
				buildingObject = Resources.Load("Models/Building/Completed_Models/industrial1") as GameObject;
				buildingObject.name = GUID;
				instantiateBuilding (buildingObject,
									 x,
									 0,
									 z);
				}

				if(tier == 2) {
				buildingObject = Resources.Load("Models/Building/Completed_Models/industrial2") as GameObject;
				buildingObject.name = GUID;
				instantiateBuilding (buildingObject,
									 x,
									 0,
									 z);
				}

				if(tier == 3) {
				buildingObject = Resources.Load("Models/Building/Completed_Models/industrial3") as GameObject;
				buildingObject.name = GUID;
				instantiateBuilding (buildingObject,
									 x,
									 0,
									 z);
				}
			break;
		}
	}

	// Dispose building 
	public void disposeBuilding (string id) {

		GameObject building = GameObject.Find( id + "(Clone)");
		
		// Animation for destroying building
		//
		// while (building.transform.localScale.y > 0.0) {
		// 	building.transform.localScale -= new Vector3(building.transform.localScale.x * 0.5, 
		// 												building.transform.localScale.y * 0.5, 
		// 												building.transform.localScale.z * 0.5);
		// }

		Destroy(building);
	}

	// initialize building models
	public void intializeBuildings () {
		planes = GameObject.FindGameObjectsWithTag ("plane");
		int x = 0;
		int z = 0;

		// building.localScale = planeTransform.localScale;
		// building.localScale -= new Vector3 (0.25f, 0.20f, 0.15f);

		// industryBuilding.localScale = planeTransform.localScale;
		// industryBuilding.localScale -= new Vector3 (0.15f, 0.35f, 0.30f);

		foreach(GameObject grid in planes) {

			// Residential building models
			if (grid.transform.GetChild(0).GetComponent<TextMesh>().text == "1") {
//				Debug.Log ("find 1: " + grid.transform.position.x + ", " + grid.transform.position.y);

				buildingObject = Resources.Load("Models/Building/Completed_Models/residential2") as GameObject;
				//Creating each cell of grid
				instantiateBuilding(buildingObject, 
									grid.transform.position.x,
									grid.transform.position.y,
									grid.transform.position.z);
			}

			//Commercial building objects
			if (grid.transform.GetChild(0).GetComponent<TextMesh>().text == "3") {
//				Debug.Log ("find 3: " + grid.transform.position.x + ", " + grid.transform.position.y);
				
				buildingObject = Resources.Load("Models/Building/Completed_Models/industrial1") as GameObject;
				instantiateBuilding(buildingObject, 
									grid.transform.position.x,
									grid.transform.position.y,
									grid.transform.position.z);
			}

			z++;
			x++;
		}
	}

	void rotateBuilding(GameObject obj) {
	}


	// Instantiates the building object
	void instantiateBuilding (GameObject obj, float x, float y, float z) {

		//Creating each cell of grid
		Instantiate (obj.transform,
			new Vector3 (x,
						 y,
						 z),
						 Quaternion.identity,
						 buildingManager.transform);
	}
}