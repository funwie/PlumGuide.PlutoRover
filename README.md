## Pluto Rover

A solution that provides capabilities to control a rover on a planet. The solution is a class library with intensive testing.

### Tools used 
C# and .Net core 3.1

### Design

- Use command pattern to handle the rover commands.
- The planet grid is a basic length and width for now. It's used to check the bounds of the planet.
- Obstacles can be added to the grid.
- All changes to the rover immutable. No updates, just new rover in a new state.

### Testing
The implementation was driven by unit tests. All tests are in the `/tests` folder

### Capabilities Implementation
- F,B,R,L commands can be executed by the rover
- Rover can wrap from one edge of the planet to the other
- Obstacle detection 

### Improvements
- Change the rover Turn to use angles (degree) instead of Cardinal. This will enable the rover to perform other turns, not only 90 degrees once.
- Add tests to handle many other cases like the null arguments, collisions, rover moves up to the last possible point and reports the obstacle

### Running the application
Run the tests from visual studio or your preferred IDE Or use `dotnet test` from the command line

