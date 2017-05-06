using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Button))]
public class IngredientUI : MonoBehaviour {

	public Ingredient data             = null;
	private static Combotron combotron = null;

	private void Start()
	{
		if (combotron == null) {
			combotron = GameObject.Find("ItemHolder").GetComponent<Combotron>();
		}
	}

	public void Clicked(int isGridItem)
	{
		if (isGridItem != 0) {
			combotron.AddIngredient(this.data);
		} else {
			combotron.RemoveIngredient(this);
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
		return obj;
	}
}
