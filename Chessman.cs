﻿using UnityEngine;
using System.Collections;

public abstract class Chessman : MonoBehaviour {
    /*
        // Use this for initialization
        void Start () {

        }

        // Update is called once per frame
        void Update () {

        }
    */
    public int CurrentX{set;get;}
    public int CurrentY{set;get;}
    public bool ifWhite;
}