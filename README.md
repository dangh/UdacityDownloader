UdacityDownloader
=================

[**Udacity**](http://www.udacity.com) provides great free courses but the download package is only 480p and does not include exercise. So I create this app to help garthering all the course's videos include exercise lecture/answer videos.

After fetched course info from Udacity, you can pass a single video or a full lesson/course to [**Internet Download Manager**](http://www.internetdownloadmanager.com) to download. If you want to download the whole course, the videos will be categorized into lesson folders.

Screenshot:

![UdacityDownloader v0.0.1](https://raw.githubusercontent.com/dangh/UdacityDownloader/master/screenshot.png)

## How to build ##
- Follow this [**SO question**](http://stackoverflow.com/questions/9150466/idm-internet-download-manager-api-using-c) to import IDManLib.dll to your system COM in prior to build the app.
- Build the app using Visual Studio (2013 preferred).

## How to use ##
- Get course info from course URL.
- Right-click on the treeview to enqueue/download the videos.

## Features may be implemented in the not-so-near future ##
- Option to choose video quality to download.
