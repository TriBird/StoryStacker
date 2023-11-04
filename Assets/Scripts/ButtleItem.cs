using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtleItem : MonoBehaviour{

	

	void Start(){
		
	}

	public void Init_Brave(){
		
		transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("enemy/25a");
	}
}
