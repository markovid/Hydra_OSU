﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene("_MainScene");
    }
}
