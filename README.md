# SimpleMicOnOff
A tool for Mic On/Off toggling

## Disclamer
It is a very bad code. 
I am not a C# developer or something, I did it just to help myself. But it works fine and stable.
This app uses [SoundVolumeView](https://www.nirsoft.net/utils/sound_volume_view.html).
## How it works

After setup you will be able to toggle your mic by pressing `Ctrl`+`~`.

There icon in your tray displays the status of the mic, red🔴 means mic is muted. Green🟢 means it's not. 

There is also a sound when you switch the state.

At launch the app turns off the mic, so be careful about that.

You can run it at system startup byt using [this](https://support.microsoft.com/en-us/windows/add-an-app-to-run-automatically-at-startup-in-windows-10-150da165-dcd9-7230-517b-cf3c295d89dd) guide from Microsoft.


## Setup
1)  Download [SoundVolumeView](https://www.nirsoft.net/utils/sound_volume_view.html)
2)  Open it and exctract values you need

You need 3 things. 
- The path to exe.
- Command to mute your device
- Command to unmute your device. 

The easiest way to get the last two things is to create shortcut using SoundVolumeView.
Just create shortcut for mute and unmute actions for specific device:

![](https://i.vas3k.club/929a6cf220fca571502a495c1ddc5459dda47dc48760f82ebff38d4699df0aee.jpg)


Then just extract a command from the shortcut properties:


![](https://i.vas3k.club/27d3feddb3174d71b18d71068a31e55482fde529f5ae41895ac3d4ebf36bed36.jpg)


3) Put the values to resources file: 

![](https://i.vas3k.club/e8e811fa343036ceb6d79382d1d637b7c8da44e0514b35eebb3976db01fcbdda.jpg)

4) Then just build!

## Help
This project is bad from many points of view, so you can help me or even rewrite it in any way.
