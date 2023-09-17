using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsParameter : MonoBehaviour
{

    public static AdsParameter instance = null;

    public string app_key {get;set;}
    public  string g_app_id{get;set;}
    public  string g_banner1{get;set;}
    public  string g_banner2{get;set;}
    public  string g_banner3{get;set;}
    public  string g_inter1{get;set;}
    public  string g_inter2{get;set;}
    public  string g_inter3{get;set;}
    public  string g_native1{get;set;}
    public  string g_native2{get;set;}
    public  string g_native3{get;set;}
    public  string g_rewarded1{get;set;}
    public  string g_rewarded2{get;set;}
    public  string g_rewarded3{get;set;}
    public  string showAds { get;set;}
    public  string show_g_banner1{get;set;}
    public  string show_g_banner2{get;set;}
    public  string show_g_banner3{get;set;}
    public  string show_g_inter1{get;set;}
    public  string show_g_inter2{get;set;}
    public  string show_g_inter3{get;set;}
    public  string show_g_native1{get;set;}
    public  string show_g_rewarded1{get;set;}
    public  string show_g_rewarded2{get;set;}
    public  string show_g_rewarded3{get;set;}
    public  string show_loading{get;set;}
    public  string extraStringPara1{get;set;}
    public  string extraStringPara2{get;set;}
    public  string ad_app_name{get;set;}
    public  string ad_app_url{get;set;}
    public  string ad_banner_url{get;set;}
    public  string ad_dialog_title{get;set;}
    public  string ad_icon_url{get;set;}
    public  string ad_message{get;set;}
    public  string isAds{get;set;}
    public  string isNotification{get;set;}
    public  string isUpdate{get;set;}
    public  string not_dialog_title{get;set;}
    public  string not_message{get;set;}
    public  string not_show_dialog{get;set;}
    public  string update_app_url{get;set;}
    public  string update_dialog_title{get;set;}
    public  string update_message{get;set;}
    public  string update_show_cancel{get;set;}
    public  string update_title{get;set;}
    public  string update_version_name{get;set;}



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
