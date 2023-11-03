using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameMaster : MonoBehaviour{

	public Transform StoryBoardTop_Trans, StoryBoard_Trans, Stacker_Trans, Floor_Trans;
	public GameObject StoryBrave_Prefab;

	private List<StoryCtrl> stackedstories = new List<StoryCtrl>();
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
		stackedstories.Add(story_instance);
	}

	// take out story
	public void TakeoutStory(){
		StoryCtrl story = stackedstories[stackedstories.Count - 1];
		stackedstories.RemoveAt(stackedstories.Count - 1);

		story.transform.DOLocalMove(new Vector3(700,280,0), 0.5f);
	}

	// Press story play button
	public void PlayStory(){
		StartCoroutine(StoryPlayInit());
	}
	public IEnumerator StoryPlayInit(){
		GameObject obj = Instantiate(StoryBrave_Prefab, Stacker_Trans);
		obj.transform.localPosition = new Vector3(0f, 600f, 0f);
		StoryStacking(obj.transform.GetComponent<StoryCtrl>());
		yield return new WaitForSeconds(0.5f);

		Floor_Trans.transform.DOLocalMoveX(0, 0.5f);
		yield return new WaitForSeconds(0.5f);

		// Take out the stories one by one 
		TakeoutStory();
	}
}
