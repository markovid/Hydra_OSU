﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightCow : MonoBehaviour
{

    void OnMouseDown()
    {
        Game.current.boss = Game.current.cow;
        Game.current.cowDead = true;
        SceneManager.LoadScene("_BattleScene");
    }
}