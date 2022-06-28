# RobotSimulation

Hi team,

A couple of notes for this test

* I decided against writing a test. I realise this wont hold me in great regards, 
however I figured 1-2 hours and had not touched c# in a year. So I rolled with what is there.
* I decided the logic to have a Command Service that does the filtering for valid commands to send to a navigator implementation. 
This way the navigator only has to worry about navigating and it pushes the responsibility back to the sender of the commands, to send only valid commands.
* I thought about reflection for the ExecuteCommands method in Robot.cs, however it felt a little clunky and prone to error. 
My solution does not scale well though if we start to add more commands.
* Some patterns in a real world solution could be a chain of responsibility, where you never know the command coming in and 
then get the chance to do more then just place, turn left/right or move when the command is called upon. For this though, absolute overkill.
* Why didn't I use properties?!?! ... what for? none of the class values are required to be read back out.

Cheers
Matt