using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PG : MonoBehaviour
{
	private GameObject pg;
	private Material materialColored;
	private int hop = 0;
    
    void Start()
    {
        pg = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pg.name = "Player";
        pg.transform.position += new Vector3(0,3,0);
        pg.AddComponent(typeof(Rigidbody));

        BoxCollider _bc = (BoxCollider)pg.AddComponent(typeof(BoxCollider));
 		_bc.center = Vector3.zero;
 		_bc.size = new Vector3(1.2f, 1.2f, 1.2f);

 		materialColored = new Material(Shader.Find("Diffuse"));
    	materialColored.color = new Color(255,0,0);
        pg.GetComponent<Renderer>().material = materialColored;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W)) pg.transform.position += new Vector3(0,0,0.2f);
        if(Input.GetKey(KeyCode.S)) pg.transform.position -= new Vector3(0,0,0.2f);
        if(Input.GetKey(KeyCode.D)) pg.transform.position += new Vector3(0.2f,0,0);
        if(Input.GetKey(KeyCode.A)) pg.transform.position -= new Vector3(0.2f,0,0);
        if(Input.GetKeyDown("space") && hop == 0){
        	pg.transform.position += new Vector3(0,0.5f,0);
        	hop = 10;
        }
        if(hop > 0) hop--;
    }
}
