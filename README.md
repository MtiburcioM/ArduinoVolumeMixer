<p align="center">
  <a href="https://github.com/AndrejStojkovic/Arduino-TempControl">
    <img src="/Misc/logo.png" alt="Logo">
  </a>

  <h3 align="center" color="blue">Arduino Volume Mixer</h3>

  <p align="center">
    Windows Volume Mixer but made with Arduino and C#.
  </p>
</p>


## Table of contents

- [Quick start](#quick-start)
- [Schematics](#schematics)
- [Preview](#preview)
- [To-Do](#to-do)
- [Bugs](#bugs)
- [Creators](#creators)
- [License](#license)


## Quick start

What you will need for this project:
- Arduino Uno
- Parts: 5xB10K Potentiometers, Wires
- C# with .NET Framework 4.5+

Steps to make it work:
1. Download the release version from here: https://github.com/AndrejStojkovic/ArduinoVolumeMixer/releases/tag/Release (ArduinoVolumeMixer.rar)
2. Extract the files somewhere.
3. Plug in your Arduino to your PC and set it up according to the schematics.  
4. Upload the sketch from the sketches folder according to the schematic you followed.
5. Then open the ConsoleMixer project in VS or just open the Debug folder and run the program.
6. Enter your 'COMx' from the Arduino (you can find this either in Device Manager or the Arduino IDE program).
7. And voila! It should work.

## Schematics

Here are the schematics for the Arduino.
Schematics were made with Fritzing.

<img src="/Schematic/avm_schem_bb.png" alt="Schematic 1">

## Preview

Here are some pictures of the project.

<img src="/Misc/1.jpg" alt="Preview 1">

This is with a custom case I made for it.
<img src="/Misc/2.jpg" alt="Preview 2">

## To-Do

- Add a way to close app without Task Manager.

## Bugs

- Delay on with audio and potentiometers if you rotate too fast.
- Program can be only closed with Task Manager

## Creators

- [Andrej Stojkovic](https://github.com/AndrejStojkovic)

## License

Code released under the [MIT License](LICENSE.md).

Enjoy :metal:
