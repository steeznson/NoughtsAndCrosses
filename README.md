# NoughtsAndCrosses
Small noughts and crosses project to refresh my knowledge of C# (Mono)
# Compile (Linux)
`mcs -target:exe -out:NAndC.exe NoughtsAndCrosses.cs Grid.cs`
If you'd like to play against the computer -
`mcs -target:exe -out:NAndC.exe -define:CPU NoughtsAndCrosses.cs Grid.cs`
# Execute
`mono NAndC.exe`