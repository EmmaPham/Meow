using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScrolling : MonoBehaviour {
    public float speed = 0.5f;
    private MeshRenderer _renderer;

	// Use this for initialization
	void Start () {
        _renderer = GetComponent<MeshRenderer>();

	}
	
	// Update is called once per frame
	void Update () {

        Scroll();
	}
    void Scroll()
    {
        _renderer.material.mainTextureOffset = new Vector2(0,Time.time * speed);
    }

    


}
