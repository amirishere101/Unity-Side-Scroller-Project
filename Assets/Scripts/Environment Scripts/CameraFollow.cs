using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
   private Vector3 offset;
   private float smoothTime = 0.1f;
   private Vector3 velocity = Vector3.zero;
   [SerializeField] private Transform target;
   [SerializeField] private int offsetX = 0;
   [SerializeField] private int offsetY = 0;
   [SerializeField] private int zoom = 10;

   void Awake(){
    offset = new Vector3(offsetX, offsetY, zoom * -1);
   }


   void Update(){
    Vector3 targetPosition = target.position + offset;
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
   }
}
