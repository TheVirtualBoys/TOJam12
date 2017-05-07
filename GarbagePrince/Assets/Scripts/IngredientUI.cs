using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Button))]
public class IngredientUI : MonoBehaviour {

	public Ingredient data                     = null;
	public GameObject selectedObj              = null;
	private static Combotron combotron         = null;
	private static GameplayController gameplay = null;

	public enum ButtonEvent {
		BUTTON_COMBO,
		BUTTON_GRID,
		BUTTON_FINAL
	}

	private void Start()
	{
		if (combotron == null) {
			combotron = GameObject.Find("ItemHolder").GetComponent<Combotron>();
		}
		if (gameplay == null) {
			gameplay = GameObject.Find("Canvas").GetComponent<GameplayController>();
		}
	}

	public void Clicked(int buttonType)
	{
		if (this.data == null) return;

		switch ((ButtonEvent)buttonType) {
		case ButtonEvent.BUTTON_GRID:
			combotron.AddIngredient(this.data);
			selectedObj.SetActive(true);
			break;
		case ButtonEvent.BUTTON_COMBO:
			combotron.RemoveIngredient(this);
			IngredientGrid.RefreshSelectedStates();
			break;
		case ButtonEvent.BUTTON_FINAL:
			gameplay.SetFinalIngredient(this.data);
			break;
		}
	}

	public void ClearCell()
	{
		if (this.gameObject.transform.childCount > 0) {
			GameObject.Destroy(this.gameObject.transform.GetChild(0).gameObject);
		}
	}

	public GameObject ClearAndInstantiateCell(Ingredient ingredient)
	{
		ClearCell();
		GameObject prefab = Resources.Load<GameObject>(ingredient.prefabName);
		GameObject obj    = Instantiate<GameObject>(prefab, this.gameObject.transform);
		this.data         = ingredient;
		this.selectedObj  = obj.transform.GetChild(1).gameObject;
		return obj;
	}
}
