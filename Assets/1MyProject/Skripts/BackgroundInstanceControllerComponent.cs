using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInstanceControllerComponent : MonoBehaviour
{
    [SerializeField] private string _createdTag;
    private void Awake()
    {
        GameObject gameObject = GameObject.FindWithTag(this._createdTag);
        if (gameObject != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = this._createdTag;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
