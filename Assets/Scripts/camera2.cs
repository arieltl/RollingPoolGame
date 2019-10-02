using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2 : MonoBehaviour
{
   
   public GameObject player;
   Vector3 baseOffset;
   void Awake()
   {
      
   }

   void Start()
   {
      baseOffset = transform.position - player.transform.position;
   }
}
