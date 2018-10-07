using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IronPython.Hosting;


struct PriceAndName
{
	public string name;
	public float price;
}


public class PythonExecuter : MonoBehaviour {
	public string pythonName;
	// Use this for initialization
	void Start ()
	{	
		var engine = Python.CreateEngine();
		engine.Runtime.LoadAssembly(typeof(UnityEngine.GameObject).Assembly);
		var paths = engine.GetSearchPaths();
		paths.Add(Application.dataPath + "/Python/Lib");
		engine.SetSearchPaths(paths);
		engine.ExecuteFile("Assets/Python/json_test.py");

		var valueToCheck = new PriceAndName {name="Billy", price=18.0f};

		var scope = engine.CreateScope();
		var pythonSource = engine.CreateScriptSourceFromFile("Assets/Python/check_jsonschema.py");
		scope.SetVariable("json_to_check", JsonUtility.ToJson(valueToCheck));
		pythonSource.Execute(scope);

	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
