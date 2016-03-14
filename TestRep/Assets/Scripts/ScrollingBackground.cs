using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

	public Vector2 speed = Vector2.zero;
	public Material[] diffMats;

	private Vector2 offset = Vector2.zero;
	private Material matSettter;
	private Material mat;

	GameObject player;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");

		// Gets the material and gets the material called _MainTex
		mat = GetComponent<Renderer> ().material;

		offset = mat.GetTextureOffset ("_MainTex");
	}

	// Update is called once per frame
	void Update () 
	{
		offset += speed * Time.deltaTime;
		// Sets the material with a timedelay and moves it
		mat.SetTextureOffset ("_MainTex", offset);

	}
}
