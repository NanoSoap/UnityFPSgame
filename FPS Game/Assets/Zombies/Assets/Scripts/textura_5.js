var one : Texture;
var two : Texture;
var three : Texture;

function  Update(){
if (Variable.Five == 1){
GetComponent.<Renderer>().material.mainTexture = one;
}

else if (Variable.Five == 2){
GetComponent.<Renderer>().material.mainTexture = two;
}

else if (Variable.Five == 3){
GetComponent.<Renderer>().material.mainTexture = three;
}

}