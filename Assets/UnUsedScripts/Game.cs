﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game { //don't need ": Monobehaviour" because we are not attaching it to a game object

	public static Game current;
	public Character MineDigger;

	public Game () {
		MineDigger = new Character();
	}

}