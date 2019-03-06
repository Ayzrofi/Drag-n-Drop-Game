using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class AdsManajer : MonoBehaviour {
    public static AdsManajer Instance;
    public string IdAplikasi;
    public string IdBanner;
    public string IdIntertisial;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().initAdmob(IdBanner, IdIntertisial);
        Admob.Instance().loadInterstitial();
        Admob.Instance().initSDK(IdAplikasi);
#endif
    }

    public void ShowBanner()
    {
#if UNITY_EDITOR
        Debug.Log("Banner Show");
#elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER,5);
#endif
    }

    public void ShowIntertisial()
    {
#if UNITY_EDITOR
        Debug.Log("Intertisial Showed");
#elif UNITY_ANDROID
        if (Admob.Instance().isInterstitialReady())
        {
            Admob.Instance().showInterstitial();
        }
        else
        {
            Admob.Instance().loadInterstitial();
        }
#endif
    }

    public void LoadIntertisial()
    {
#if UNITY_EDITOR
        Debug.Log("Intertisial Loaded");
#elif UNITY_ANDROID
        if (!Admob.Instance().isInterstitialReady())
             Admob.Instance().loadInterstitial();
#endif
    }

}
