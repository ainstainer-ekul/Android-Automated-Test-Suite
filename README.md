# Android-Automated-Test-Suite

#### In order to launch Appium via cmd:
1. Open "appium" folder
2. Open command prompt
3. Launch runappium.cmd with following parameters:
- parameter1 - full path to 'appium.js' in installed Appium folder
- parameter2 - full path to .apk file
- parameter3 - api version (ex. Android 5.0 = 21, https://developer.android.com/about/dashboards/index.html )
- parameter4 - device name


###### A result command should look like: 
runappium.cmd "C:\Program Files (x86)\Appium\node_modules\appium\bin\appium.js" "C:\Users\evgeniy.kulikov\Desktop\androidApp\com.soundcloud.android_2017.05.30-beta-674_minAPI16(armeabi,armeabi-v7a,x86)(nodpi)_apkmirror.com.apk" 21 "Google_Nexus_10" 
 

 
 
Example line for running tests via cmd: runtests.cmd "Google Nexus 5_4.4.4" testpath:Feature*Login*