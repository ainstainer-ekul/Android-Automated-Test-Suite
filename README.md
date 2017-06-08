# Android-Automated-Test-Suite

#### In order to launch Appium via cmd:
1. Open "appium" folder
2. Open command prompt
3. Launch runappium.cmd with following parameters

Parameter1 - full path to 'appium.js' in installed Appium folder

Parameter2 - full path to .apk file

Parameter3 - platform version (Android 4.4 = 19, 5.0 = 21, etc. https://developer.android.com/about/dashboards/index.html )

Parameter4 - device name


###### A result command should look like: 
runappium.cmd "C:\Program Files (x86)\Appium\node_modules\appium\bin\appium.js" "C:\Users\evgeniy.kulikov\Desktop\androidApp\com.soundcloud.android_2017.05.30-beta-674_minAPI16(armeabi,armeabi-v7a,x86)(nodpi)_apkmirror.com.apk" 21 "Google_Nexus_10" 
 
