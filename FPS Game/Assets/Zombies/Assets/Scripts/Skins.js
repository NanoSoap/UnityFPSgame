var one : GameObject;
var two : GameObject;
var three : GameObject;
var four : GameObject;
var five : GameObject;

function OnGUI () {

if (GUI.Button (Rect (250,60,40,18), "One")) {
      one.GetComponent.<Renderer>().enabled = true;		
      two.GetComponent.<Renderer>().enabled = false;
      three.GetComponent.<Renderer>().enabled = false;
      four.GetComponent.<Renderer>().enabled = false;
      five.GetComponent.<Renderer>().enabled = false;
}


if (GUI.Button (Rect (310,60,40,18), "Two")) {
      one.GetComponent.<Renderer>().enabled = false;		
      two.GetComponent.<Renderer>().enabled = true;
      three.GetComponent.<Renderer>().enabled = false;
      four.GetComponent.<Renderer>().enabled = false;
      five.GetComponent.<Renderer>().enabled = false;
}

if (GUI.Button (Rect (370,60,45,18), "Three")) {
      one.GetComponent.<Renderer>().enabled = false;		
      two.GetComponent.<Renderer>().enabled = false;
      three.GetComponent.<Renderer>().enabled = true;
      four.GetComponent.<Renderer>().enabled = false;
      five.GetComponent.<Renderer>().enabled = false;
}

if (GUI.Button (Rect (430,60,40,18), "Four")) {
      one.GetComponent.<Renderer>().enabled = false;		
      two.GetComponent.<Renderer>().enabled = false;
      three.GetComponent.<Renderer>().enabled = false;
      four.GetComponent.<Renderer>().enabled = true;
      five.GetComponent.<Renderer>().enabled = false;
}

if (GUI.Button (Rect (490,60,40,18), "Five")) {
      one.GetComponent.<Renderer>().enabled = false;		
      two.GetComponent.<Renderer>().enabled = false;
      three.GetComponent.<Renderer>().enabled = false;
      four.GetComponent.<Renderer>().enabled = false;
      five.GetComponent.<Renderer>().enabled = true;
}
}