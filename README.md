# Android-Automated-Test-Suite

####Configuration virutal device and Appium:
1. Create Genymotion devices with a specific model and Android version 	
2. Launch the virtual device
3. Create a node config .json file according to the device capability 
4. Create a .bat file for launch appium from console 
5. Put .json and .bat file in .\Appium\node_modules\.bin folder
6. Launch .bat file
7. Open a browser with the node url ( ex. http://127.0.0.1:4723/wd/hub/status ) and check than the node is running

Example of config is showns on the screenshot: https://www.dropbox.com/s/mgw4tjtm0o9tv1z/node_config_for_virtual_device.png?dl=0

####In order to launch autotests of a specific feature:


1. Open AndroidAppTestSuit folder 
2. Open a command prompt and launch command: runtests.cmd "Google Nexus 6_5.1_http://127.0.0.1:4723" testpath:Feature*Login*
(in double quotes should be specified the device name, Android version, url of launched node )