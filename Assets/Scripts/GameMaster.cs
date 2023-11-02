using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameMaster : MonoBehaviour{

	public Transform StoryBoardTop_Trans, StoryBoard_Trans, Stacker_Trans;

	private int currentstack;

	void Start(){
		foreach(Transform tmp in Stacker_Trans) Destroy(tmp.gameObject);
	}

	public void StoryStacking(StoryCtrl story_instance){
		story_instance.isDragEnable = false;

		story_instance.GetComponent<BoxCollider2D>().enabled = false;
		story_instance.transform.SetParent(Stacker_Trans);
		story_instance.transform.DOLocalMove(new Vector3(Random.Range(-35f, 35f), -390+(50*currentstack), 0), 0.2f);

		currentstack += 1;
	}
}
