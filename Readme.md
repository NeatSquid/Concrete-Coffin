### Game I need to make

* First person,
* Puzzle based,
* Low end graphics,
* Horror

### Inspo

* [The other side](https://youtu.be/uNqU9a8RuzI)
* [Iron lung](https://youtu.be/88HFKqOH_ME)

Both reference games consist of cramped space environments in which the player operates machinery by interacting with
tools, buttons etc. The things break and the player needs to fix them. Telling a story is important as well.
In one game you service a machine in the second one you navigate a vehicle.

In The other side the player performs the task of servicing the machine that removes part of the wall to escape the
oppressive environment.

In Iron lung the player performs the task of navigating the vehicle to set point with a promise of freedom if
successful.

### Under

* Riding these tracks long enough one can be forgiven for believing these narrow underground tunnels are stretching
  forever. Remember to drive the locomotive efficiently on unpowered sections. The old batteries run out of juice almost
  instantly. If you run out of backup power and your locomotive have stopped consider yourself lost.
* Your goal is Station Terminal Alpha. Reach it by any means. Deliver the cargo.

### Dev Notes

* Interior and exterior of the train should be separate scenes.
* Navigation mode - player can run around freely, interact with objects - press buttons, open doors, equip & use
  tools. Interacting with TriggerDriveMode object switches player to driving mode.
* Driving mode should feel like a basic train simulator - by moving the mouse around camera slightly tilts, player can
  interact with objects on the dashboard. To switch back to navigation player just presses interact button again.

### Todo

- [ ] study character controller.
- [x] implement objects interaction.
- [ ] **practical** object interaction implementation.
- [ ] implement driving mode manipulating the character controller.
- [ ] add a CRT screen to the dashboard to display information like wheels slipping, battery charge etc.

![](Assets/RawAss/Train_00_alternative.gif)
![](Assets/RawAss/Train_00.gif)