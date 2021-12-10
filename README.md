# Area-Calculator
Project to calculate the area of a complex shape using the repetition method.

THEORY
The area of an unusually shaped surface can be hard to find. In the lower classes, we did that by dividing the whole surface into smaller squares and then counting each square. Here I have created something similar where squares are replaced by small balls and the tedious counting part is the computer's responsibility.

WORKING
Note that areas in the setup are extruded to give another dimension to convert them into 3D containers. This will not affect the outcome.

We have a known area which is a square of a known side, "a". The unknown area is placed inside the known area. A ball spawner spawns balls at regular intervals, at any random point within the known area. Both known and unknown areas have triggera that trigger when a ball falls inside it.

After sufficient iterations, a ratio of the balls fallen within the unknown area to the known area will remain constant. Now this ratio will the ratio of the area of the known shape to the unknown shape. 
                      
                     Area of the unknown shape = (no. of balls in the unknown area / no. of balls in the known area) * Area of the known shape

Additional to these, the following are also present:
- Two Displays which show the current ratio and the calculated area 
- Three Buttons to start, pause and reset the experiment
- Two other known areas, a smaller square and a circle, to verify the experiment and can be cycled through using 2 buttons. 
- A slider to control the speed of ball spawning
