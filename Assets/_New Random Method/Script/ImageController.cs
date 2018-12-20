using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script ini berfungsi untuk mengontroll jawaban agar bisa di drag n drop gitu
public class ImageController : MonoBehaviour {
    // untuk memilih tag agar sesuai dgn tag yg sudah di tentukan
    public enum Tags { Item_1, Item_2, Item_3, Item_4, Item_5, Item_6, Item_7, Item_8, Item_9 };
    // deklarasi tag baru
    public Tags ItemTag = new Tags();
    // ment=yimpan posisi awal image
    Vector2 StartPos;
    // variabel untuk menentukan posisi target
    Vector2 TargetPos;
    // untuk menentukan posisi input pada layar android
    float DeltaX, DeltaY;
    [SerializeField]
    // untuk menentukan apakah jawaban itu sudah terkunci dan apakah sudah complite
    bool IsLocked,IsComplite;

     Vector3 StartSize, currentSize;

    private void Start()
    {
        // deklarasi posisi awal
        StartPos = transform.position;
        // menentukan tag dari gameobject ini 
        this.gameObject.tag = ItemTag.ToString();
        // deklarasi boolean bahwa pertanyaan ini belum selesai
        IsComplite = false;

        StartSize = transform.localScale;
        currentSize = new Vector3(2, 2, 0);
    }
    // menentukan posisi pertanyaan ketika target di sentuh
    private void OnMouseOver()
    {
        if (!IsLocked && !IsComplite)
        {
            DeltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            DeltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
        transform.localScale = currentSize;

    }

    private void OnMouseExit()
    {
        if (!IsLocked && !IsComplite)
            transform.localScale = StartSize;
    }


    private void OnMouseDrag()
    {
        if (!IsComplite)
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(Pos.x - DeltaX, Pos.y - DeltaY);
            //transform.localScale = currentSize;
        }
    }
    // kondisi ketika mouse di lepas
    private void OnMouseUp()
    {
        if (IsLocked)
        {
            if (!IsComplite)
            {
                AnswerComplite(TargetPos);
            }
        }
        else
        {
            transform.position = StartPos;
        }
    }
    // kondisi ketika image di drag n drop di tempat yg sesuai gan 
    // atau ketika player menyentuh gambar yg sesuai seperti di script TestTag.cs
    // di sini ada parameter Pos yg di ambil dari ontrigger enter bla bla bla
    public void AnswerComplite(Vector2 Pos)
    {
        transform.position = Pos;
        //Jawaban.instance.createQuestion();
        Jawaban.Instance.createQuestion();
        transform.localScale = currentSize;
        IsComplite = true;
        
        //this.gameObject.GetComponent<ImageController>().enabled = false;
    }
    //  here we checking if tranform from target collide with the same tag and upgrade boolean IsLocked
    // becoeme true and setting target position with that gameobject
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == this.gameObject.tag)
        {
            TargetPos = obj.transform.position;
            IsLocked = true;
        }
    }
    // if trigger exit we upgrade Islocked to false again
    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == this.gameObject.tag)
            IsLocked = false;
    }
}
