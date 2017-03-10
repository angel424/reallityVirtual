using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

	GameObject placeholder = null;
	//----------->
	public Vector3 initialPosition;
	
	public void OnBeginDrag(PointerEventData eventData) {
        Block block = new Block();

		Debug.Log ("OnBeginDrag");
		
		placeholder = new GameObject();
		placeholder.transform.SetParent( this.transform.parent );
		LayoutElement le = placeholder.AddComponent<LayoutElement>();
		le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex( this.transform.GetSiblingIndex() );
		
		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		this.transform.SetParent( this.transform.parent.parent );
		
		GetComponent<CanvasGroup>().blocksRaycasts = false;

		//---------------->
		initialPosition = this.GetComponent<RectTransform>().position;

        //--------------> Variable of GameObject

        print("center:  " + this.GetComponent<RectTransform>().rect.center);
        print("height:  " + this.GetComponent<RectTransform>().rect.height);
        print("max:  " + this.GetComponent<RectTransform>().rect.max);
        print("min:  " + this.GetComponent<RectTransform>().rect.min);
        print("position:  " + this.GetComponent<RectTransform>().rect.position);
        print("size:  " + this.GetComponent<RectTransform>().rect.size);
        print("width:  " + this.GetComponent<RectTransform>().rect.width);
        print("x: " + this.GetComponent<RectTransform>().rect.x);
        print("xMax:  " + this.GetComponent<RectTransform>().rect.xMax);
        print("xMin:  " + this.GetComponent<RectTransform>().rect.xMin);
        print("y: " + this.GetComponent<RectTransform>().rect.y);
        print("yMax:  " + this.GetComponent<RectTransform>().rect.yMax);
        print("yMin:  " + this.GetComponent<RectTransform>().rect.yMin);

        print(" ");

	}
	
    //When this is in movent 
	public void OnDrag(PointerEventData eventData) {
        //Debug.Log ("OnDrag" + " Mouse Position " + Input.mousePosition + "Block position:  " + this.GetComponent<RectTransform>().rect.position);
        //Debug.Log ()
        this.GetComponent<Block>().updatePoints();

        Debug.Log("Block P1:  " + this.GetComponent<Block>().getP1());
        Debug.Log("Block P2:  " + this.GetComponent<Block>().getP2());

        this.transform.position = eventData.position;

		if(placeholder.transform.parent != placeholderParent)
			placeholder.transform.SetParent(placeholderParent);

		int newSiblingIndex = placeholderParent.childCount;

		for(int i=0; i < placeholderParent.childCount; i++) {
			if(this.transform.position.x < placeholderParent.GetChild(i).position.x) {

				newSiblingIndex = i;

				if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
					newSiblingIndex--;

				break;
			}
		}

		placeholder.transform.SetSiblingIndex(newSiblingIndex);

	}
	
	public void OnEndDrag(PointerEventData eventData) {
		Debug.Log ("OnEndDrag");

		if (parentToReturnTo.gameObject.name != "Hand")
		{
			this.transform.position = initialPosition;
		} 


		this.transform.SetParent( parentToReturnTo );
		this.transform.SetSiblingIndex( placeholder.transform.GetSiblingIndex() );
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		Destroy(placeholder);
	}
	
	
	
}
