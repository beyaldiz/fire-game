using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    Transform _cam;
    Transform _Player;
    void Start ()
    {
        _cam = GetComponent<Transform>();
	}
	
	void Update ()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        _Player = Player.GetComponent<Transform>();
        scaleCam();
	}
    void scaleCam()
    {
        if(_Player.position.x-_cam.position.x > 4)
            _cam.position = new Vector3(_Player.position.x - 4, _cam.position.y,_cam.position.z);
        
        if(_Player.position.x - _cam.position.x < -4)
            _cam.position = new Vector3(_Player.position.x + 4, _cam.position.y,_cam.position.z);
    }
}
