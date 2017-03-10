using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu : MonoBehaviour {
	public int[] cantmenu;
	GameObject botonbase;
	public int menusel = -1, submenusel = -1;

	void Start () {
		Vector2 posicion, posicion2;
		RectTransform rt, rt2;
		GameObject boton;
		Button bt;

		botonbase = transform.GetChild(0).gameObject;
		rt = botonbase.transform as RectTransform;
		posicion = rt.anchoredPosition;
		//CREAMOS LOS MENUS
		for (int i = 0; i < cantmenu.Length; i++){
			int num = i;
			boton = CrearBoton("Menu "+(i+1), posicion);
			bt = boton.GetComponent<Button>();
			bt.onClick.AddListener(() => ClickMenu(num));
			//CREAMOS LOS SUBMENUES
			posicion2 = rt.anchoredPosition;
			posicion2.x += rt.sizeDelta.x;
			for (int j = 0; j < cantmenu[i]; j++){
				int num2 = j;
				boton = CrearBoton("Objeto "+(i+1)+"."+(j+1), posicion2);
				bt = boton.GetComponent<Button>();
				bt.onClick.AddListener(() =>ClickSubMenu(num2));
				boton.SetActive(false);
				posicion2.y -= rt.sizeDelta.y;
			}
			posicion.y -= rt.sizeDelta.y;
		}
		botonbase.SetActive(false);
	}	

	void Update () {

	}

	GameObject CrearBoton(string Nombre, Vector2 posicion){
		GameObject botonclon = Instantiate(botonbase);
		RectTransform rt2 = botonclon.transform as RectTransform;
		botonclon.transform.SetParent(transform);
		rt2.anchoredPosition = posicion;
		botonclon.GetComponentInChildren<Text>().text = Nombre;
		botonclon.name = Nombre;
		return botonclon;
	}

	void EsconderSubMenus(){
		transform.FindChild("Menu "+(menusel+1)).GetComponent<Image>().color = Color.white;
		for (int i = 0; i < cantmenu[menusel]; i++)
			transform.FindChild("Objeto "+(menusel+1)+"."+(i+1)).gameObject.SetActive(false);
	}

	public void ClickMenu(int sel){
		if (menusel >= 0)
			EsconderSubMenus();
		menusel = sel;
		transform.FindChild("Menu "+(menusel+1)).GetComponent<Image>().color = Color.green;
		for (int i = 0; i < cantmenu[sel]; i++)
			transform.FindChild("Objeto "+(sel+1)+"."+(i+1)).gameObject.SetActive(true);
	}

	public void ClickSubMenu(int sel){
		submenusel = sel;
		Debug.Log("Click en Submenu "+(menusel+1)+"."+(submenusel+1));
		//AQUI ES DONDE SE VALIDA QUE ES LO QUE SE VA A REALIZAR SEGUN menusel(0 - cantidad de menus) Y submenusel(0 - cantidad de submenu del menu tal) 
	}
}