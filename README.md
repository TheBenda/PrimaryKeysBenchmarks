# PrimaryKeysBenchmarks
This project runs is supposed to proof the performance benefits of UUID Version 7 over older versions - at least in the right circumstances.
# Run the project
To run the project, make sure
- that docker is running
- you start the AppHost in Release mode first
- then extract the ConnectionString from the migration project details and paste them in the corresponing DbContext's of the BenchmarksRunner project 
- and create a new solution for the BenchmarksRunner project so that you can configure it while the other solution is running