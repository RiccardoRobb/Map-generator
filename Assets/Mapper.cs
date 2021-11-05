using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapper : MonoBehaviour
{
	public class Block{

		public GameObject cube;
		public Material materialColored;
		public Vector3 pos;
    	public Vector3 dim;
    	public int value;
    	private int htl = 0;
    	private int ht = 0;

    	public Block(Vector3 _pos, int _value){
    		cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    		cube.name = "Wall";
    		cube.transform.position = _pos;
    		pos = _pos;
    		value = _value;
    		dim = Vector3.one;
    		
    		BoxCollider _bc = (BoxCollider)cube.AddComponent(typeof(BoxCollider));
 			_bc.center = Vector3.zero;

			Rigidbody _rb = (Rigidbody)cube.AddComponent(typeof(Rigidbody));
			_rb.isKinematic = true;

    		materialColored = new Material(Shader.Find("Diffuse"));
    		materialColored.color = new Color(0,0,255);
        	cube.GetComponent<Renderer>().material = materialColored;
    	}

    	public void up(){
    		if(value >= 3 && value < 9){
    				materialColored.color = Color.yellow;
    				if(ht == htl){
    					cube.transform.localScale += new Vector3(0,1,0);
    					ht++;
    				}
    			} 
        	else if(value >= 9 && value < 22){
    				materialColored.color = Color.green;
    				if(ht != htl){
    					cube.transform.localScale += new Vector3(0,1,0);
    					htl++;
    				}
    			} 
        	else if(value >= 22){
    				materialColored.color = Color.grey;
    				if(ht == htl){
    					cube.transform.localScale += new Vector3(0,1,0);
    					ht++;
    				}
    			} 
        	cube.GetComponent<Renderer>().material = materialColored;
    	}
	}

	public int width;
    public int height;

    public int level;

    private Block[,] map;

    void Upping(){
    	for(int i=1; i<width-1; i++){
	    	for(int j=1; j<height-1; j++){
	    		map[i,j].up();
	    	}
	    }
    }

    void Start(){
    	CreateBase();
    	for(int k=0;k<8;k++){
	    	Smooth();
	    	Upping();
	    }
    }

    void Update(){
    	 if (Input.GetKeyDown("r")){
    	 	print("Restart generation....");
    	 	level = UnityEngine.Random.Range(10, 50);
    	 	CreateBase();
    	 } 
    	 if (Input.GetKeyDown("u")){
    	 	Smooth();
    	 	Upping();
    	 }
    }

    void CreateBase(){
    	print("Starting generation....");
    	map = new Block[width, height];
    	for(int i=0; i<width; i++){
    		for(int j=0; j<height; j++){
    			Vector3 pos = new Vector3(-width/2 + i, 0, -height/2 + j);
    			int value = (UnityEngine.Random.Range(0, 100) < level)?1:0;

    			map[i,j] = new Block( pos, value );
    		}
    	}
    	print("Completed!        level:"+level);
    }

    void Smooth(){
    	for(int i=1; i<width-1; i++){
    		for(int j=1; j<height-1; j++){
    			if(map[i+1, j].value > 0 && map[i-1, j].value > 0 && map[i, j+1].value > 0 && map[i, j-1].value > 0){
    				map[i,j].value += 1;
    				int r = UnityEngine.Random.Range(0, 8);
    				if(r % 2 == 0){
    					map[i+1,j+1].value += 1;
    				}else if(r % 3 == 0){
    					map[i-1,j+1].value += 1;
    				}else if(r % 5 == 0){
    					map[i-1,j-1].value += 1;
    				}else if(r % 7 == 0){
    					map[i+1,j-1].value += 1;
    				}
    			}
    		}
    	}
    }
}
