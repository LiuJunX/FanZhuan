using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    Transform target;
    Vector3 offsetFromHero;

	// Use this for initialization
	void Start () {
        target = FindObjectOfType<HeroController> (). transform;
        offsetFromHero = transform. position - target. position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        this. transform. position = new Vector3 ( target. position. x + offsetFromHero. x, 0, target. position. z + offsetFromHero. z );   
	}
}
