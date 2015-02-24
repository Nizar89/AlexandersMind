using UnityEngine;
using System.Collections;

public class OrderableObject : MonoBehaviour 
{
    public delegate void NewUnitSelected(); //When a new unit is selected, unselec last one. 

	protected ListOrder orders = new ListOrder();


	public bool _isSelected = false;

	// Use this for initialization
	void Start () 
	{
		HandleSquareUnderObject(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameManager.phase == GameManager.GamePhase.Order)
		{
			HandleSelection();
            HandleListOrder();
		}
        
	}

	void HandleSquareUnderObject(bool start = false)
	{
		Ray charles = new Ray(this.transform.position, new Vector3(0,-1,0));
		RaycastHit hit;
		if (Physics.Raycast(charles, out hit))
		{
			if (hit.collider.tag == ListTag.tagSquare)
			{
                SquareBehavior squareUnder = hit.collider.gameObject.GetComponent<SquareBehavior>();
                if (start)
                {
                    orders.AddSquareToList(squareUnder);
                }
                squareUnder.ChangeState(SquareBehavior.StateSquare.UnitOnTop);
			}
			else
			{
				Debug.LogError("No Square under units. Strange behavior may occur.");
			}
		}
	}

	void HandleSelection()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) //Mouse button Down
		{
            Debug.Log("EnterPhase2");
			Ray charles = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;
			Physics.Raycast(charles, out hit);

			if (hit.collider == this.collider)
			{
				_isSelected = true;
			}
		}
		/*else if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)) //mouse button up
		{
			_isSelected = false;
            orders.UnselecAllSquare();
		}*/
	}

	void HandleListOrder()
	{
		if (_isSelected)
		{
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Ray charles = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				RaycastHit[] hits;
				hits = Physics.RaycastAll(charles);
				foreach(RaycastHit hit in hits)
				{
                    if (hit.collider.tag == ListTag.tagSquare && !orders.IsLastElement(hit.collider.gameObject.GetComponent<SquareBehavior>()))
					{
						orders.AddSquareToList(hit.collider.gameObject.GetComponent<SquareBehavior>());
					}
				}
			}
		}
	}
}
