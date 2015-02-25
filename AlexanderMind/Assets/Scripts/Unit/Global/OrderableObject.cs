using UnityEngine;
using System.Collections;

public class OrderableObject : MonoBehaviour 
{
    public delegate void NewUnitSelected(); //When a new unit is selected, unselec last one. 
	public bool _isSelected = false;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
        
	}

}
