using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform targetTransform = null;
    public int zoom = -5;
    
    void Update()
    {
        if(this.targetTransform != null){
            this.transform.position = new Vector3(this.targetTransform.position.x, this.targetTransform.position.y, zoom);
        }
        //transform.position = Vector3.SmoothDamp(transform.position,player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
