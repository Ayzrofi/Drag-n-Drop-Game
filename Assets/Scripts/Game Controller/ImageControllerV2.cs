using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageControllerV2 : MonoBehaviour {
    
    public enum Tags { Item_1, Item_2, Item_3, Item_4, Item_5, Item_6, Item_7, Item_8, Item_9, Item_10 };
    // deklarasi tag baru
    public Tags ItemTag = new Tags();
    public Transform targetParent;
    // ment=yimpan posisi awal image
    Vector3 StartPos;
    // variabel untuk menentukan posisi target
    Vector2 TargetPos;
    // untuk menentukan posisi input pada layar android
    float DeltaX, DeltaY;
    // untuk menentukan apakah jawaban itu sudah terkunci dan apakah sudah complite
    bool IsLocked, IsComplite;

    public AudioClip SFX,WrongAnswerSFX;

    Vector3 StartSize, IdleSize, TargetSize;

    [SerializeField]
    float  ClickedSize;
    Transform Parent;
    [SerializeField]
    [Range(0,5)]
    private float timeToAdd;

    bool IsMoving;
    private void Start()
    {
        // deklarasi posisi awal
        StartPos = transform.position;
        // menentukan tag dari gameobject ini 
        this.gameObject.tag = ItemTag.ToString();
        // deklarasi boolean bahwa pertanyaan ini belum selesai
        IsComplite = false;
        //
        StartSize = transform.localScale;
        IdleSize = new Vector3(StartSize.x * ClickedSize, StartSize.y * ClickedSize, 0);
        // 
        Parent = this.transform.parent;

        if(targetParent == null)
        {
            targetParent = transform.parent.parent.parent;
        }
    }

    private void Update()
    {
        if (IsMoving)
        {
            transform.position = Vector2.Lerp(transform.position, StartPos, 0.1f);
            if(transform.position == StartPos)
            {
                IsMoving = false;
            }
        }
    }

    // menentukan posisi pertanyaan ketika target di sentuh
    private void OnMouseOver()
    {
        if (!IsLocked && !IsComplite)
        {
            DeltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            DeltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
            transform.localScale = IdleSize;
        }
    }
    // kondisi ketika mouse exit
    private void OnMouseExit()
    {
        if (!IsLocked && !IsComplite)
        {
            transform.localScale = StartSize;
        }    
    }
    // kondisi ketika mouse di drag
    private void OnMouseDrag()
    {
        if (!IsComplite)
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(Pos.x - DeltaX, Pos.y - DeltaY);
            transform.SetParent(targetParent);
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
                AnswerComplite(TargetPos,TargetSize);
                //if (GameManajer.TheInstanceOfGameManajer.UsingAnswerSpawnerScript)
                //{
                //    AnswerSpawner.TheInstanceOfAnswerSpawner.SpawnNewAnswer();
                //}
            }
        }
        else
        {
            IsMoving = true;
            //transform.position = StartPos;
            transform.SetParent(Parent);
            GameManajer.TheInstanceOfGameManajer.PlaySfx(WrongAnswerSFX);
        }
    }
    // kondisi ketika image di drag n drop di tempat yg sesuai gan 
    // atau ketika player menyentuh gambar yg sesuai seperti di script TestTag.cs
    // di sini ada parameter Pos yg di ambil dari ontrigger enter bla bla bla
    public void AnswerComplite(Vector2 Pos, Vector3 size)
    {
        transform.position = Pos;
        //Jawaban.instance.createQuestion();
        transform.localScale = size;
        IsComplite = true;
        IsMoving = false;
        GameManajer.TheInstanceOfGameManajer.CreateParticleEffect(this.gameObject);
        GameManajer.TheInstanceOfGameManajer.PlaySfx(SFX);
        GameManajer.TheInstanceOfGameManajer.TimerSlider.value += timeToAdd;
        GameManajer.TheInstanceOfGameManajer.AnswerCounter();
        //this.gameObject.GetComponent<ImageController>().enabled = false;
    }
    //  here we checking if tranform from target collide with the same tag and upgrade boolean IsLocked
    // becoeme true and setting target position with that gameobject
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == this.gameObject.tag)
        {
            TargetPos = obj.transform.position;
            //TargetSize = obj.transform.localScale;
            TargetSize = obj.transform.localScale;
            //Debug.Log(TargetSize);
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
