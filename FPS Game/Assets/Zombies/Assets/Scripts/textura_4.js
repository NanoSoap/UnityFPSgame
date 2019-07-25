var one : Texture;
var two : Texture;
var three : Texture;

function  Update(){
if (Variable.Four == 1){
GetComponent.<Renderer>().material.mainTexture = one;
}

else if (Variable.Four == 2){
GetComponent.<Renderer>().material.mainTexture = two;
}

else if (Variable.Four == 3){
GetComponent.<Renderer>().material.mainTexture = three;
}

}