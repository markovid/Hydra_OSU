﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightFarmer : MonoBehaviour {

    void OnMouseDown()
    {
        Game.current.boss = Game.current.farmer;
        SceneManager.LoadScene("_BattleScene");
    }
}
