# RetroConsoleNetplay
Controller logic/interface for streaming online multtplayer for retro consoles.

Initial proof-of-concept version.

Requirements:
1.) (Host) Video capture card/hardware for streaming the video and audio to the other player(s) and PC.

2.) (Host) 1 Arduino Uno per guest player (currently only 1 additional player is supported).
  a.) USB type B cable to connect the Arduino to the PC.
  b.) Homemade adapter or dupoint cables to connect the Arudino IO pins to DB15 connector (more information later, but currently works on systems with DB15 controller ports such as Neo Geo or superguns. Could also be used with other systems via padhacks and such. Analog sticks are not supported)
  
3.) (Host) ControllerServer software
  
4.) (Guest) Xbox 360 controller to connect to PC (Other controllers might work, but are not tested).

5.) (Guest) ControllerClient software
