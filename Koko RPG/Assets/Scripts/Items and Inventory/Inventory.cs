using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public GameObject selPage;
	public List<GameObject> objPages = new List<GameObject> ();
	public static Inventory m_instance;
	public Text pageNum;
	private int _pageNum;

	private int pageIndex = 0;

	void Awake() {
		if (m_instance != null) {
			Debug.LogWarning ("More than one instance of Inventory!");
			return;
		}
		m_instance = this;
	}

	public delegate void OnItemChanged();

	public OnItemChanged onItemChangedCallback;

	public int m_space = 48;

	public List<Item> m_items = new List<Item> ();

	public bool Add (Item item) {
		if (!item.isDefaultItem) {
			if (m_items.Count >= m_space) {
				Debug.Log ("Not enough room.");
				return false;
			}
			m_items.Add (item);

			if(onItemChangedCallback != null)
				onItemChangedCallback.Invoke ();
		}

		return true;
	}

	public void Remove (Item item) {
		m_items.Remove (item);

		if(onItemChangedCallback != null)
			onItemChangedCallback.Invoke ();
	}

	void Start()
	{
		selPage = objPages[0];

		// only display page 1
		//DisplaySelectedPage (selPage);
	}

	void Update()
	{
		//test
		if (Input.GetKeyUp(KeyCode.W))
		{
			NextPage();
			Debug.Log ("Next");

		} else if (Input.GetKeyUp(KeyCode.S))
		{
			PreviousPage();
			Debug.Log ("prev");
		}

		_pageNum = pageIndex + 1;
		PageNumberText ();
	}


	private void DisplaySelectedPage(GameObject _page)
	{
		foreach (var p in objPages)
		{
			if (p == _page)
			{
				p.SetActive (true);
			} else
			{
				p.SetActive (false);
			}
		}
	}

	private void NextPage()
	{
		if (pageIndex < 2) {
			pageIndex++;
			selPage = objPages [pageIndex];
		}
		DisplaySelectedPage (selPage);
	}

	private void PreviousPage()
	{
		if (pageIndex > 0)
		{ 
			pageIndex--;
			selPage = objPages[pageIndex];
		}
		DisplaySelectedPage(selPage);

	}

	void PageNumberText()
	{
		pageNum.text = "Page: " + _pageNum.ToString();
	}
}