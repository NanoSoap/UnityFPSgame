var one : Texture;
var two : Texture;
var three : Texture;

function  Update(){
if (Variable.One == 1){
GetComponent.<Renderer>().material.mainTexture = one;
}

else if (Variable.One == 2){
GetComponent.<Renderer>().material.mainTexture = two;
}

else if (Variable.One == 3){
GetComponent.<Renderer>().material.mainTexture = three;
}

}