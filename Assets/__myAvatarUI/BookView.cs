using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamerTool.UI;
public class BookView : View
{
    public GameObject bookCell;
    public Transform root;//transform root, for 
    List<BookCell> cells = new List<BookCell>();//list of booking cells, including their goals
    private void Awake()
    {
        UpdateCell();
        EventHandler.OnAddBook += UpdateCell;
    }
    private void OnDestroy()
    {
        EventHandler.OnAddBook -= UpdateCell;
    }
    public void RemoveCell(BookCell cell)
    {
        Destroy(cell.gameObject);
        cells.Remove(cell);
    }
    public void UpdateCell()
    {

        foreach (var time in DataModel.Model.BookList)// readed list, get time
        {
            if (!cells.Exists(a => { return a.GetModel() == time; }))
            {
                var cell = Instantiate(bookCell, root);
                cell.GetComponent<BookCell>().SetModel(time);//set the content of the model
                cells.Add(cell.GetComponent<BookCell>());
            }
        }

    }
}
