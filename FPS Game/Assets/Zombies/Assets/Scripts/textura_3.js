var one : Texture;
var two : Texture;
var three : Texture;

function  Update(){
if (Variable.Three == 1){
GetComponent.<Renderer>().material.mainTexture = one;
}

else if (Variable.Three == 2){
GetComponent.<Renderer>().material.mainTexture = two;
}

else if (Variable.Three == 3){
GetComponent.<Renderer>().material.mainTexture = three;
}

}