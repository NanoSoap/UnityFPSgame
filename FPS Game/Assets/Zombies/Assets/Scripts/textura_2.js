var one : Texture;
var two : Texture;
var three : Texture;

function  Update(){
if (Variable.Two == 1){
GetComponent.<Renderer>().material.mainTexture = one;
}

else if (Variable.Two == 2){
GetComponent.<Renderer>().material.mainTexture = two;
}

else if (Variable.Two == 3){
GetComponent.<Renderer>().material.mainTexture = three;
}

}