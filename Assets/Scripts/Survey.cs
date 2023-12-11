using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using VInspector;
#if UNITY_EDITOR
using VInspector.Libs;
#endif 

public class Survey : MonoBehaviour
{
    [SerializeField] string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSetkvZ8pBj2KHvjx0OFHvPUYsus0z_YJd-RsQ3PmYf51HwiEA/formResponse";
    [SerializeField] private string IDs;
    [SerializeField] private SerializedDictionary<FormField, string> formFieldDictionary;


    public Dictionary<FormField, string> GetFormResultDictionary(ResultData resultData)
    {
        Dictionary<FormField, string> formResultDictionary= new Dictionary<FormField, string>();
        AddUserData(ref formResultDictionary);
        AddResultData(ref formResultDictionary,resultData);
        return formResultDictionary;
    }

    void AddUserData(ref Dictionary<FormField, string> formResultDictionary)
    {
        formResultDictionary.Add(FormField.AdSoyad,MainManager.UserData.Name);
        formResultDictionary.Add(FormField.DogumTarihi,MainManager.UserData.Birthday);
        formResultDictionary.Add(FormField.Cinsiyet,MainManager.UserData.Gender);
        formResultDictionary.Add(FormField.EgitimDurumu,MainManager.UserData.Education);
        formResultDictionary.Add(FormField.GunlukEkran,MainManager.UserData.ScreenTime);
        formResultDictionary.Add(FormField.TelefonKullanma,MainManager.UserData.MobileUsageSkill);
        formResultDictionary.Add(FormField.AktifArac,MainManager.UserData.ActiveDevices);
        formResultDictionary.Add(FormField.KullanimAmaci,MainManager.UserData.UsagePurpose);
        formResultDictionary.Add(FormField.AfaziTuru,MainManager.UserData.AfaziTuru);
        formResultDictionary.Add(FormField.İsimlendirme,MainManager.UserData.SeyDiyor);
        formResultDictionary.Add(FormField.Anlama,MainManager.UserData.DuydugunuAnlamak);
        formResultDictionary.Add(FormField.Konusma,MainManager.UserData.KonusmaktaZorluk);
        formResultDictionary.Add(FormField.Tekrar,MainManager.UserData.KonusmaktaTekrar);
        formResultDictionary.Add(FormField.Okuma,MainManager.UserData.OkumaktaZorluk);
        formResultDictionary.Add(FormField.Yazma,MainManager.UserData.YazmakdaZorluk);
    }
    
    void AddResultData(ref Dictionary<FormField, string> formResultDictionary,ResultData resultData)
    {
        formResultDictionary.Add(FormField.Kategori,QuestionSettings.Category.ToString());
        formResultDictionary.Add(FormField.Bolum,(QuestionSettings.GroupIndex+1).ToString());
        formResultDictionary.Add(FormField.Zorluk,QuestionSettings.Difficulty.ToString());
        formResultDictionary.Add(FormField.Secenek,QuestionSettings.NumberOfOptions.ToString());
        formResultDictionary.Add(FormField.Soru,resultData.QuestionCount.ToString());
        formResultDictionary.Add(FormField.Dogru,resultData.CorrectAnswerCount.ToString());
        formResultDictionary.Add(FormField.Yanlıs,resultData.WrongAnswerCount.ToString());
        formResultDictionary.Add(FormField.DogruYuzde,resultData.ResultPercentage.ToString());
        formResultDictionary.Add(FormField.ToplamSure,resultData.Time.ToString("0.0"));
        formResultDictionary.Add(FormField.SoruSure,resultData.TimePerQuestion.ToString("0.0"));
    }
    
    public void Send(Dictionary<FormField, string> formResult)
    {
        StartCoroutine(Post(formResult));
    }

    IEnumerator Post(Dictionary<FormField,string> formResult)
    {
        WWWForm form = new WWWForm();
        
        foreach (var formField in formResult.Keys)
        {
            if (!string.IsNullOrWhiteSpace(formResult[formField]))
            {
                form.AddField(formFieldDictionary[formField],formResult[formField]);
            }
        }


        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        
        yield return www.SendWebRequest();

    }

    #if UNITY_EDITOR
    [Button] 
    void SetIdsFromString()
    {
        var idList = IDs.Split(",");
        var keyList = formFieldDictionary.Keys.ToArray();
        int index = 0;
        for (int i = 0; i < keyList.Length; i++)
        {
            formFieldDictionary[keyList[i]]=idList[i].Remove(" ");
        }
    }
    #endif 
    
}

public enum FormField
{
    AdSoyad,
    DogumTarihi,
    Cinsiyet,
    EgitimDurumu,
    GunlukEkran,
    TelefonKullanma,
    AktifArac,
    KullanimAmaci,
    AfaziTuru,
    İsimlendirme,
    Anlama,
    Konusma,
    Tekrar,
    Okuma,
    Yazma,
    Kategori,
    Bolum,
    Zorluk,
    Secenek,
    Soru,
    Dogru,
    Yanlıs,
    DogruYuzde,
    ToplamSure,
    SoruSure
}

/*
    entry.844579239,
   entry.922295375,
   entry.1225807529,
   entry.727367391,
   entry.1310028659,
   entry.705927224,
   entry.595952594,
   entry.715494011,
   entry.1039246737,
   entry.305064674,
   entry.611310244,
   entry.2052645728,
   entry.796066047,
   entry.1276427438,
   entry.29559522,
   entry.31556311,
   entry.1904397761,
   entry.2016111283,
   entry.1865851871,
   entry.908454902,
   entry.351897909,
   entry.682637106,
   entry.853806424,
   entry.576702170,
   entry.241200031
   
   */