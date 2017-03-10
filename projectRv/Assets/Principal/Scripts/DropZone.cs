using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log("OnPointerEnter");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.placeholderParent = this.transform;
		}
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log("OnPointerExit");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null && d.placeholderParent==this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}
	}
	
	public void OnDrop(PointerEventData eventData) {

        Vector3 pos = Input.mousePosition;

        //if (img.rect.Contains(img.InverseTransformPoint(Input.mousePosition)){ }
        Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name + " Mouse Position " + pos);

        // eventData.pointerDrag: represent the object in movement.
        Debug.Log(eventData.pointerDrag.transform.position + "   :) ");
        
        //gameObject: represent to panel.

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && gameObject.GetComponent<RectTransform>().rect.Contains(pos))
        {
            print(" Dentro ::: ");
            d.parentToReturnTo = this.transform;
        }

        /*
        print(" xMax: "+ gameObject.GetComponent<RectTransform>().rect.xMax + "xMin: "+
            gameObject.GetComponent<RectTransform>().rect.xMin + "yMax: " +
            gameObject.GetComponent<RectTransform>().rect.yMax + "yMin: " +
            gameObject.GetComponent<RectTransform>().rect.yMin);
        */

        //print(" Height Panel:   " + gameObject.GetComponent<RectTransform>().rect.height*0.374769);
        //print(" MeshRenderer Panel:   " + gameObject.GetComponent<MeshFilter>().mesh.bounds);



    }
}
