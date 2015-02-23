using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public enum GamePhase{None, BuildUnit, Order, Play};
	public static GamePhase phase = GamePhase.Order;

	// Use this for initialization
	void Start () 
	{
    
	}
	
	// Update is called once per frame
	void Update () 
	{
	    
	}
}
