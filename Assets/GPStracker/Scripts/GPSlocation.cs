
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class GPS : MonoBehaviour
{
   public Text  latitude ;
    public Text      longitude ;
    public Text     altitude;
    public Text       horizontalAccuracy ;
    public Text      timestamp;
    public Text status;

    public bool isUpdating;

    private void Update()   {
        if (!isUpdating)
        {
            StartCoroutine(GetLocation());
            isUpdating = !isUpdating;
        }
    }
    IEnumerator GetLocation()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield return new WaitForSeconds(10);

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 10;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)  {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)  {
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)    {
            yield break;
        }
        else{
            latitude.text = Input.location.lastData.latitude.ToString();
            longitude.text = Input.location.lastData.longitude.ToString();
            altitude.text = Input.location.lastData.altitude+100f.ToString();
            horizontalAccuracy.text =  Input.location.lastData.horizontalAccuracy.ToString();
            timestamp.text =  Input.location.lastData.timestamp.ToString();

             
            if (Input.location.lastData.horizontalAccuracy > 100) {
                status.text = "riziko špatné přesnosti GPS";
            }
            else {
                status.text = " ";
            }



        }

        // Stop service if there is no need to query location updates continuously
        isUpdating = !isUpdating;
        Input.location.Stop();
    }
}