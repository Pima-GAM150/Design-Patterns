using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

	public RaycastHit currentHit;

	protected virtual void Update () {
		if( Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out currentHit, Mathf.Infinity, LayerMask.GetMask("Default") ) ) {
			if( Input.GetMouseButtonDown(0) ) {
				IClickable clickedObj = currentHit.collider.GetComponent<IClickable>();

				if( clickedObj != null ) clickedObj.OnClicked(0);
			}

			float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
			if( Mathf.Abs(scrollWheelInput) > 0f ) {
				IScrollable scrolledObj = currentHit.collider.GetComponent<IScrollable>();

				if( scrolledObj != null )  scrolledObj.OnScrolled( scrollWheelInput );
			}
		}
	}
}
