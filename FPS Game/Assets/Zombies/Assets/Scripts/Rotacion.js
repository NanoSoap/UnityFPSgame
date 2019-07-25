var speed : float = 1.0;
function Update () {
transform.Rotate(0,speed * Time.deltaTime, 0);
}