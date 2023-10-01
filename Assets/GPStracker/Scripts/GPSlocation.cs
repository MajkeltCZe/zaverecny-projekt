using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSlocation : MonoBehaviour
{
    public Text GPSStatus;
    public Text latitudeValue;
    public Text longitudeValue;
    public Text altitudeValue;
    public Text horizontalAccuracyValue;
    public Text timestampValue;



    void Start()
    {
        StartCoroutine(GPSLoc());
    }

 IEnumerator GPSLoc() {

    if(!Input.location.isEnabledByUser) 
        yield break;

    Input.location.Start();

    int maxWait = 20;
    while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)    {
        yield return new WaitForSeconds(1);
        maxWait--;
    }

if (maxWait < 1) {
    GPSStatus.text = "Time out";
    yield break;
}
if (Input.location.status == LocationServiceStatus.Failed) {
        GPSStatus.text = "Unable to determinate";

    yield break;
}
else {
    GPSStatus.text = "Running";
    InvokeRepeating("UpdateGPSDATA",0.5f,1f);

}
 }


private void UpdateGPSDATE() {
    if(Input.location.status == LocationServiceStatus.Running) {
    GPSStatus.text = "Running";
    latitudeValue.text = Input.location.lastData.latitude.ToString();
    longitudeValue.text = Input.location.lastData.longitude.ToString();
    altitudeValue.text = Input.location.lastData.altitude.ToString();
        horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
        timestampValue.text = Input.location.lastData.timestamp.ToString();



    }
    else {
    GPSStatus.text = "Running";

    }
}

}
