﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour {

	public GameObject introPanel           = null;
	public GameObject mainGame             = null;
	public GameObject combineItem          = null;
	public GameObject selectPresent        = null;
	public SelectionDisplay finalSelection = null;
	public GameObject outroPanel           = null;
	public Ingredient pickedIngredient     = null;

	public void Start()
	{
		this.introPanel.SetActive(true);
	}

	public void CloseIntroPanel()
	{
		this.introPanel.SetActive(false);
		this.mainGame.SetActive(true);
		this.combineItem.SetActive(true);
	}

	public void OnFinalCombination()
	{
		this.mainGame.SetActive(false);
		this.combineItem.SetActive(false);
		this.selectPresent.SetActive(true);
	}

	public void PresentSelected()
	{
		this.selectPresent.SetActive(false);
		this.finalSelection.gameObject.SetActive(true);
	}

	public void SetFinalIngredient(Ingredient ingredient)
	{
		this.pickedIngredient = ingredient;
		this.finalSelection.SetIngredient(ingredient);
	}

	public void FinalPresentDoneDisplay()
	{
		this.finalSelection.gameObject.SetActive(false);
		this.outroPanel.SetActive(true);
	}

	public void CloseOutroPanel()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}