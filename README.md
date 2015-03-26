# MazeGameProjectGit
Maze Game made in Unity for camera angle usability analysis
In order to store data, the RecPosScript contains a string relating to a folder on the machine. As it stands, this is set up to
my personal H drive, and so will require alteration to a path of your local machine in order to save position and rotation data.

The Visualtion function requries the use of MATLAB, and requires the importation of the data recorded as vector columns.
The vector columns should use this naming convention:

for positions1 - column 1 = x
                column 2 = y
                coumn 3 = z

for rotations1 - column 1 = xr
                column 2 = yr
                column 3  = zr
  
Once imported, with the path directory set to the folder containing the visualisation method (MatlabForResVisual) the pathDraw2 function 
should be called in the following manner - pathDraw2(x,y,z,xr,yr,zr)

The animation of the users path and camera rotations can be keyed through using any key.
