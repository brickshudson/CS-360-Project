# CS-360-Project
## Building the Project
This project is distributed to consumers in three different formats: Windows executable, MacOS executable, and an in-browser HTML document.
### Build Settings
#### Desktop
1.	In Project Settings navigate to “PC, Mac & Linux Standalone” under Player
2.	Select Resolution And Presentation
3.	Set “Fullscreen Mode” to “Exclusive Fullscreen”
4.	Enable “Run In Background”
#### HTML
1.	In Project Settings navigate to “WebGL” under Player
2.	Select Resolution And Presentation
3.	Set “Default Canvas Width” to 960
4.	Set “Default Canvas Height” to 540
5.	Enable “Run In Background”
6.	Select “Default” preset
7.	Select Publishing Settings
8.	Enable “Decompression Fallback”
### Windows Executable
1.	In Build Settings choose “PC, Mac & Linux Standalone”
2.	Change Target Platform to “Windows”
3.	Confirm build settings
4.	In Build Settings choose “Play and Run”
5.	Publish to GitHub under releases. Upload any folders (as a .zip) that have something in them and do not say “DoNotShip”
### MacOS Executable
1.	In Build Settings choose “PC, Mac & Linux Standalone”
2.	Change Target Platform to “macOS”
3.	Proceed as a Windows Executable
### HTML
#### Build
1.	In Build Settings choose “WebGL”  
**NOTE:** If you cannot see this option, you will need to install the package from Unity Hub.  
**NOTE:** You must select “Switch Platform” to build the project as an HTML page.  
**NOTE:** This will recompile the project. It is highly probable that there will be multiple errors when switching platforms. This will likely be caused by the Discord Integration and any preview packages in use.
2.	Change Code Optimization to “Size”
3.	Confirm build settings
4.	In Project Settings choose “Build and Run”
#### Making It Look Nice
**NOTE:** After every step, it is recommended to save the active document and reload the generated webpage.
**NOTE:** You will be adding files to the TemplateData in the build folder for the changes to work. The following files will need to be manually added: TotalDramaIsland.png, logo.ico, and logo.png. The logo.ico can be created by converting logo.png. Logo.png and TotalDramaIsland.png can be found in resources.
1.	The following changes are in the document “index.html” found in the base folder of the build.  
    + Change the name that appears in the web client’s tab.  
      Change the following line in “index.html”  
            
          <title>Unity WebGL Player | CS 360 Group Project</title>  
       To the line below
            
          <title>CS 360 Group Project</title>
    + Change the favicon to the game’s logo.  
      Change the following line in “index.html”
    
          <link rel="shortcut icon" href="TemplateData/favicon.ico">
      To the line below
    
          <link rel="shortcut icon" href="TemplateData/logo.ico">
    
    +	Import the used font.  
      Add the following lines to the header section in “index.html”

          <link rel="preconnect" href="https://fonts.googleapis.com">
          <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
          <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@700&display=swap" rel="stylesheet">

2.	The following changes are in the document “style.css” found in the TemplateData folder of the build.
      + Add a background to the website.  
        Change the following line in “style.css”
    
            body { padding: 0; margin: 0; }
        To the line below
    
            body { padding: 0; margin: 0; background: url('TotalDramaIsland.png') no-repeat center; background-size: 140%; }
      +	Add a border around the game.  
        Change the following line in “style.css”
    
            #unity-container.unity-desktop { left: 50%; top: 50%; transform: translate(-50%, -50%); }
        To the line below
    
            #unity-container.unity-desktop { left: 50%; top: 50%; transform: translate(-50%, -50%); border: 10px solid white; background-color: white }
      +	Change the ‘loading’ icon from the Unity icon to the game’s logo.  
        Change the following line in “style.css”
    
            #unity-logo { width: 282px; height: 150px; background: url('unity-logo-dark.png') no-repeat center; }
        To the line below
    
            #unity-logo { width: 282px; height: 150px; background: url('logo.png') no-repeat center; background-size: contain }
      + Change the loading bar size to be center.  
        Change the following lines in “style.css”
    
            #unity-progress-bar-empty { width: 141px; height: 18px; margin-top: 10px; background: url('progress-bar-empty-dark.png') no-repeat center; }
            #unity-progress-bar-full { width: 0%; height: 18px; margin-top: 10px; background: url('progress-bar-full-dark.png') no-repeat center; }
        To the lines below
    
            #unity-progress-bar-empty { width: 282px; height: 18px; margin-top: 10px; background: url('progress-bar-empty-dark.png') no-repeat center; background-position: 70.5px; }
            #unity-progress-bar-full { width: 0%; height: 18px; margin-top: 10px; background: url('progress-bar-full-dark.png') no-repeat center; background-position: 70.5px; }
      + Remove the “WebGL Icon”.  
        Remove the line containing the text `url('webgl-logo.png')`
      +	Reformat the “Game Name Bar”  
        Change the following line in “style.css”

            #unity-build-title { float: right; margin-right: 10px; line-height: 38px; font-family: Arial; font-size: 18px }
        To the line below
            
            #unity-build-title { float: left; margin-right: 10px; line-height: 38px; font-family: Roboto; font-size: 18px }
#### Deployment
1.	Upload the folder to GitHub.
**NOTE:** If a build already exists on GitHub, you will need to add the contents of the folder Build of the output of the build process to the Build folder on GitHub. You will then need to replace index.html with the modified output file. This should properly update the hosted build. 
2.	Wait for GitHub pages to register changes and rebuild or create the website.
3.	Enjoy the game.
