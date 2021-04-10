# Netput
Netput is a cross-platform automation library for simulating keyboard and mouse events.

Currently, Windows and Linux* mouse simulation is supported

* I do not have enough experience with X11 at present to implement a solution myself. Thus, LinuxMouseStrategy relies on the xdotool package being installed, and uses that.

# TODO

Implement actual X11 pinvokes in LinuxMouseStrategy, rather than using xdotool

Implement a MacOS IMouseStrategy

Implement IKeyboardStrategy and KeyboardController

# Usage

**If your display is not 1920x1080, `MouseController.Move` must be supplied with your screen resolution.**

```
MouseController controller = new();
controller.Move(100, 100);
controller.LeftClick();
```

