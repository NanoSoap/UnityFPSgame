var speed: float = 1.0;
function Update () {
GetComponent.<Camera>().fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * speed;
}