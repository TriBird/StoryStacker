using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class StoryCtrl : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler{

	public string story_title = "";
	public string story_description = "";

	public StoryType storytype = StoryType.GetItem;
	public bool isDragEnable = true;
	public GameMaster master;

	private Vector3 beforeDragPosition = new Vector3();
	private Transform LastTriggered_Trans = null;

	void Start(){

	}

	public enum StoryType{
		GetItem,
		Enemy,
		Reward,
	}

	// -------------- //
	// Judge collider //
	// -------------- //

	public void OnTriggerEnter2D(Collider2D other){
		LastTriggered_Trans = other.transform;

		if(transform.parent == master.StoryBoardTop_Trans && other.gameObject.tag == "story"){
			other.transform.localScale = new Vector3(1.2f, 1.2f, 1);
		}
	}

	public void OnTriggerExit2D(Collider2D other){
		LastTriggered_Trans = null;

		if(transform.parent == master.StoryBoardTop_Trans && other.gameObject.tag == "story"){
			other.transform.localScale = new Vector3(1, 1, 1);
		}
	}

	// -------------- //
	// Drag Interface //
	// -------------- //

	public void OnBeginDrag(PointerEventData eventData){
		if(!isDragEnable) return;

		beforeDragPosition = transform.localPosition;
		transform.SetParent(master.StoryBoardTop_Trans);
	}

	public void OnDrag(PointerEventData eventData){
		if(!isDragEnable) return;

		var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0;
		transform.position = pos;
	}

	public void OnEndDrag(PointerEventData eventData)	{
		if(!isDragEnable) return;

		transform.SetParent(master.StoryBoard_Trans);

		if(LastTriggered_Trans is null) return;

		// merge?
		if(LastTriggered_Trans.gameObject.tag == "story"){
			StoryType target_type = LastTriggered_Trans.GetComponent<StoryCtrl>().storytype;

			// item get to enemy
			if(storytype == StoryType.GetItem && target_type == StoryType.Enemy){
				
			}
		}

		// stack!
		if(LastTriggered_Trans.gameObject.tag == "stacker"){
			master.StoryStacking(this);
		}
	}

}
