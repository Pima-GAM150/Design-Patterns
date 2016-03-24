using UnityEngine;
using System.Collections;

using System;

public class BubbleInput : MouseInput {

	protected override void Update () {
		if( Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out currentHit, Mathf.Infinity, LayerMask.GetMask("Sensors") ) ) {
			if( Input.GetMouseButtonDown(0) ) {
				IClickable clickableComponent = FindFirstHandler<IClickable>( currentHit.collider.gameObject );
				if( clickableComponent != null ) clickableComponent.OnClicked( 0 );
			}

			float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
			if( Mathf.Abs(scrollWheelInput) > 0f ) {
				IScrollable clickableComponent = FindFirstHandler<IScrollable>( currentHit.collider.gameObject );
				if( clickableComponent != null ) clickableComponent.OnScrolled( scrollWheelInput );
			}
		}
	}

	T FindFirstHandler<T>( GameObject goToRecurse ) {
		T handler = goToRecurse.GetComponent<T>();

		if( handler == null ) {
			if( goToRecurse.transform.parent ) return FindFirstHandler<T>( goToRecurse.transform.parent.gameObject );
		}

		return handler;
	}
}